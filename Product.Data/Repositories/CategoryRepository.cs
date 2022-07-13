using Microsoft.EntityFrameworkCore;
using Product.Data.Models;
using Product.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
        Category CreateCategory(CategoryCreateVMs model);
        Category UpdateCategory(Category entity, CategoryUpdateVMs model);
    }

    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Category CreateCategory(CategoryCreateVMs model)
        {
            var entity = new Category()
            {
                Name = model.Name,
                Description = model.Description,
                Slug = model.Slug
            };

            return Create(entity).Entity;
        }

        public Category UpdateCategory(Category entity, CategoryUpdateVMs model)
        {
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Slug = model.Slug;

            return Update(entity).Entity;
        }
    }
}
