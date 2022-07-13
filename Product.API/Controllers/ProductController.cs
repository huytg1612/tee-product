using Microsoft.AspNetCore.Mvc;
using Product.API.Response;
using Product.Data.Services;
using Product.Data.UOW;
using Product.Data.ViewModels;

namespace Product.API.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ApiResult<int>))]
        public IActionResult Create(ProductCreateVMs model)
        {
            try
            {
                var repo = _uow.GetService<ProductService>();
                var result = repo.CreateProduct(model);
                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesDefaultResponseType(typeof(ApiResult<int>))]
        public IActionResult Update(int id, ProductUpdateVMs model)
        {
            try
            {
                var repo = _uow.GetService<ProductService>();
                var result = repo.UpdateProduct(id, model);
                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
