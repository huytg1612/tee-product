using Product.Data.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Services
{

    public class BaseService
    {
        protected IUnitOfWork _uow;
        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
