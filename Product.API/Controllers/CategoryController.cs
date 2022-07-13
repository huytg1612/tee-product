using Microsoft.AspNetCore.Mvc;
using Product.API.Response;
using Product.Data.Services;
using Product.Data.UOW;
using Product.Data.ViewModels;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(ApiResult<PaginationResult<CategoryGeneralModel>>))]
        public IActionResult Get([FromQuery] CategoryFilterVMs filter, [FromQuery] CategorySortBy sortBy, [FromQuery] Pagination pagination)
        {
            try
            {
                var service = _uow.GetService<CategoryServices>();
                var result = service.GetData(filter, pagination, sortBy);
                var response = new PaginationResult<CategoryGeneralModel>()
                {
                    CurrentPage = result.Page,
                    TotalPage = result.TotalPage,
                    Data = result.Data
                };
                return Success(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(ApiResult<int>))]
        public IActionResult Create(CategoryCreateVMs model)
        {
            try
            {
                var service = _uow.GetService<CategoryServices>();
                var result = service.CreateCategory(model);
                return Success(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesDefaultResponseType(typeof(ApiResult<int>))]
        public IActionResult Update(int id, CategoryUpdateVMs model)
        {
            try
            {
                var service = _uow.GetService<CategoryServices>();
                var result = service.UpdateCategory(id, model);
                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
