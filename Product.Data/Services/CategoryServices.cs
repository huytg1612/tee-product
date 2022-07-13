using Product.Data.Models;
using Product.Data.Repositories;
using Product.Data.UOW;
using Product.Data.ViewModels;
using Product.Data.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Services
{
    public class CategoryServices : BaseService
    {
        public CategoryServices(IUnitOfWork uow) : base(uow)
        {
        }

        public CategoryResponseList GetData(CategoryFilterVMs filter, Pagination pagination, CategorySortBy sortBy)
        {
            var repo = _uow.GetService<ICategoryRepository>();
            var extension = repo.Get().GetData(filter, sortBy, pagination);

            var categories = extension.Item1;
            var data = new List<CategoryGeneralModel>();
            foreach(var cate in categories.ToList())
            {
                var productModel = new List<ProductGeneralVMs>();

                if(cate.Products != null)
                {
                    foreach (var product in cate.Products)
                    {
                        productModel.Add(new ProductGeneralVMs()
                        {
                            Description = product.Description,
                            Id = product.Id,
                            Name = product.Name,
                            Slug = product.Slug,
                        });
                    }
                }

                data.Add(new CategoryGeneralModel
                {
                    Description = cate.Description,
                    Id = cate.Id,
                    Slug = cate.Slug,
                    Name = cate.Name,
                    Products = productModel
                });
            }

            var result = new CategoryResponseList()
            {
                Page = pagination.Page,
                TotalPage = extension.Item2,
                Data = data
            };

            return result;
        }
        public Category GetBySlug(string slug)
        {
            var repo = _uow.GetService<ICategoryRepository>();
            var cate = repo.Get().FirstOrDefault(c => c.Slug.ToLower() == slug.ToLower());

            return cate;
        }

        public int CreateCategory(CategoryCreateVMs model)
        {
            try
            {
                var repo = _uow.GetService<ICategoryRepository>();
                var cate = GetBySlug(model.Slug);

                if(cate != null)
                {
                    throw new Exception("Slug is already existed");
                }

                cate = repo.CreateCategory(model);
                if(cate == null)
                {
                    throw new Exception("Create fail");
                }
                _uow.SaveChanges();
                return cate.Id;

            }catch (Exception ex)
            {
                throw new Exception("Error at CategoryService.CreateCategory: " + ex.Message);
            }
        }

        public int UpdateCategory(int id, CategoryUpdateVMs model)
        {
            try
            {
                var repo = _uow.GetService<ICategoryRepository>();
                var cate = repo.Get().FirstOrDefault(c => c.Id == id);
                if(cate == null)
                {
                    throw new Exception("Category not found");
                }
                var cateBySlug = GetBySlug(model.Slug);
                if(cateBySlug != null && cateBySlug.Id != cate.Id)
                {
                    throw new Exception("Slug is already existed");
                }

                cate = repo.UpdateCategory(cate, model);
                if(cate == null)
                {
                    throw new Exception("Update fail");
                }

                _uow.SaveChanges();
                return cate.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error at CategoryService.UpdateCategory: " + ex.Message);
            }
        }
    }
}
