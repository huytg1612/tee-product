using Microsoft.AspNetCore.Mvc;
using Product.API.Response;
using Product.Data.UOW;
using System.Net;

namespace Product.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IUnitOfWork _uow;
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Success<T>(T data)
        {
            var result = new ApiResult<T>()
            {
                Code = 200,
                Data = data,
                Message = "",
                Status = "Success"
            };

            return StatusCode((int)HttpStatusCode.OK, result);
        }

        public IActionResult BadRequest<T>(T data, string message = "Error")
        {
            var result = new ApiResult<T>()
            {
                Code = 400,
                Data = data,
                Message = message,
                Status = "Bad request"
            };

            return StatusCode((int)HttpStatusCode.BadRequest, result);
        }
    }
}
