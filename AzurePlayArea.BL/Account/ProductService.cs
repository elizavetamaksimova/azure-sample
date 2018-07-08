using System.Collections.Generic;
using System.Linq;
using AzurePlayArea.Data.DataAccess;
using AzurePlayArea.BL.Models;
using AzurePlayArea.Data.Model;
using Newtonsoft.Json;
using FileInfo = AzurePlayArea.Data.Model.FileInfo;

namespace AzurePlayArea.BL.Account
{
    public class ProductService
    {
        private readonly ProductDataAccess _productDataAccess;
        private readonly BlobStorageDataAccess _storageDataAccess;
        private readonly QueueStorageDataAccess _queueDataAccess;

        public ProductService()
        {
            _productDataAccess = new ProductDataAccess();
            _storageDataAccess = new BlobStorageDataAccess();
            _queueDataAccess = new QueueStorageDataAccess();
        }

        public List<ProductEntity> GetAllProducts()
        {
            List<Product> products = _productDataAccess.GetAllProducts();
            return products.Select(p => new ProductEntity(p) { ImageName = _storageDataAccess.GetBlobSas(p.BlobPath) }).ToList();
        }

        public void InsertProduct(ProductEntity product, byte[] file, string fileName)
        {
            string blobPath = _storageDataAccess.Upload(file, fileName);

            if (product != null)
            {
                _productDataAccess.InsertProduct(
                    new Product
                    {
                        BlobPath = fileName,
                        Description = product.Description,
                        Price = product.Price,
                        Title = product.Title
                    });
            }

            FileInfo fileInfo = new FileInfo
            {
                ProcessingType = ProcessingType.Compressing,
                BlobPath = blobPath
            };

            var serializedMessageContent = JsonConvert.SerializeObject(fileInfo);

            _queueDataAccess.AddMessage(serializedMessageContent);
        }
    }
}
