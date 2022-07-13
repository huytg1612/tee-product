using Product.Data.Models;
using Product.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Extension
{
    public static class CategoryExtension
    {
        public static IQueryable<Category> Filter(IQueryable<Category> qs, CategoryFilterVMs filter)
        {
            if(filter.Search != null && filter.Search != "")
            {
                qs = qs.Where(c => c.Name.ToLower().Contains(filter.Search.ToLower()));
            }
            if (filter.Slug != null && filter.Slug != "")
            {
                qs = qs.Where(c => c.Slug == filter.Slug);
            }

            return qs;
        }

        public static IQueryable<Category> Sort(IQueryable<Category> qs, CategorySortBy sortBy)
        {
            switch (sortBy.SortField)
            {
                case CategorySortField.Name:
                    qs = qs.OrderBy(c => c.Name);
                    break;
                case CategorySortField.Slug:
                    qs = qs.OrderBy(c => c.Slug);
                    break;
            }

            if(sortBy.SortDirection == SortDirection.DESC)
            {
                qs = qs.Reverse();
            }

            return qs;
        }

        public static Tuple<IQueryable<Category>, int> GetData(this IQueryable<Category> qs, CategoryFilterVMs filter, CategorySortBy sortBy, Pagination pagination)
        {
            qs = Filter(qs, filter);
            int totalPage = 1;
            if (qs.Count() % pagination.PageSize == 0)
            {
                totalPage = qs.Count() / pagination.PageSize;
            }
            else
            {
                totalPage = (qs.Count() / pagination.PageSize) + 1;
            }
            qs = Sort(qs, sortBy);
            qs = BaseExtension.Paginate(qs, pagination);

            return new Tuple<IQueryable<Category>, int>(qs, totalPage);
        }
    }
}
