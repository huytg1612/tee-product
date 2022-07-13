using Microsoft.EntityFrameworkCore;
using Product.Data.ViewModels;
using Product.Data.Models;

namespace Product.Data.Repositories
{
    public interface IProductRepository : IBaseRepository<Product.Data.Models.Product, int>
    {
        Product.Data.Models.Product CreateProduct(ProductCreateVMs model);
        Product.Data.Models.Product UpdateProduct(Product.Data.Models.Product entity, ProductUpdateVMs model);
    }

    public class ProductRepository : BaseRepository<Product.Data.Models.Product, int>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Product.Data.Models.Product CreateProduct(ProductCreateVMs model)
        {
            var entity = new Product.Data.Models.Product()
            {
                Name = model.Name,
                Description = model.Description,
                Slug = model.Slug,
                CategoryId = model.CategoryId,
            };

            return Create(entity).Entity;
        }

        public Product.Data.Models.Product UpdateProduct(Product.Data.Models.Product entity, ProductUpdateVMs model)
        {
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Slug = model.Slug;
            entity.CategoryId = model.CategoryId;

            return Update(entity).Entity;
        }
    }
}
