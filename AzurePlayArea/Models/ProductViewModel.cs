using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AzurePlayArea.BL.Models;

namespace AzurePlayArea.Models
{
    public class ProductViewModel
    {
        public List<ProductEntity> Products { get; set; }

        public Product NewProduct { get; set; }
    }
}