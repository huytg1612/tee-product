using Product.Data.Repositories;
using Product.Data.UOW;
using Product.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Services
{
    public class ProductService : BaseService
    {
        public ProductService(IUnitOfWork uow) : base(uow)
        {
        }

        public Product.Data.Models.Product GetBySlug(string slug)
        {
            var repo = _uow.GetService<IProductRepository>();
            var product = repo.Get().FirstOrDefault(c => c.Slug.ToLower() == slug.ToLower());

            return product;
        }

        public int CreateProduct(ProductCreateVMs model)
        {
            try
            {
                var repo = _uow.GetService<IProductRepository>();
                var product = GetBySlug(model.Slug);

                if (product != null)
                {
                    throw new Exception("Slug is already existed");
                }

                var cateRepo = _uow.GetService<ICategoryRepository>();
                var cate = cateRepo.Get().FirstOrDefault(c => c.Id == model.CategoryId);
                if (cate == null)
                {
                    throw new Exception("Category not found");
                }

                product = repo.CreateProduct(model);
                if (product == null)
                {
                    throw new Exception("Create fail");
                }
                _uow.SaveChanges();
                return product.Id;

            }
            catch (Exception ex)
            {
                throw new Exception("Error at ProductService.CreateProduct: " + ex.Message);
            }
        }

        public int UpdateProduct(int id, ProductUpdateVMs model)
        {
            try
            {
                var repo = _uow.GetService<IProductRepository>();
                var product = repo.Get().FirstOrDefault(c => c.Id == id);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                var productBySlug = GetBySlug(model.Slug);
                if (productBySlug != null && productBySlug.Id != product.Id)
                {
                    throw new Exception("Slug is already existed");
                }

                var cateRepo = _uow.GetService<ICategoryRepository>();
                var cate = cateRepo.Get().FirstOrDefault(c => c.Id == model.CategoryId);
                if (cate == null)
                {
                    throw new Exception("Category not found");
                }

                product = repo.UpdateProduct(product, model);
                if (product == null)
                {
                    throw new Exception("Update fail");
                }

                _uow.SaveChanges();
                return product.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error at ProductService.UpdateProduct: " + ex.Message);
            }
        }
    }
}
