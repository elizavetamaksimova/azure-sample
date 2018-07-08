using AzurePlayArea.Data.Model;

namespace AzurePlayArea.BL.Models
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            
        }

        public ProductEntity(Product product)
        {
            if (product == null)
            {
                return;
            }

            Id = product.Id;
            Title = product.Title;
            Description = product.Description;
            Price = product.Price;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Number { get; set; }

        public string ImageName { get; set; }
    }
}
