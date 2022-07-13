using Product.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Extension
{
    public static class BaseExtension
    {
        public static IQueryable<T> Paginate<T>(IQueryable<T> qs, Pagination pagination)
        {
            if(pagination.Page < 1)
            {
                pagination.Page = 1;
            }
            if(pagination.PageSize < 0)
            {
                pagination.PageSize = 0;
            }

            qs = qs.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize);

            return qs;
        }
    }
}
