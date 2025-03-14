using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelCompassApplication.Commands.AddNewCategory;
using TravelCompassApplication.Queries.GetAllCategory;

namespace TravelCompass.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;


        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddNewCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddNewCategory(AddNewCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            if (!result.IsSuccess) { return BadRequest(result); }
            return Ok(result.Value);
        }
    }
}
