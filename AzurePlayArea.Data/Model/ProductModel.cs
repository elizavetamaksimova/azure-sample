namespace AzurePlayArea.Data.Model
{
    using System.Data.Entity;

    public partial class ProductModel : DbContext
    {
        public ProductModel()
            : base("name=AzurePlayAreaDBModel")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
