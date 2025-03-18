using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelCompassApplication.Commands.AddNewCategory;
using TravelCompassApplication.Queries.GetAllCategory;
using TravelCompassApplication.Queries.GetCategoryById;
using TravelCompassLogic.TravelCompassDbContext;

namespace TravelCompass.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public CategoryController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
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
            return Ok();
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            if (!result.IsSuccess) { return BadRequest(result); }
            return Ok(result.Value);
        }
        [HttpGet("GetCategory")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(GetCategoryByIdDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategory(string name)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery { Name = name });
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result.Value);
            //var subdomain = HttpContext.Items["Subdomain"] as string;
            //// Fetch data from the database based on the subdomain
            //var siteData = _context.Categories.Select(x => x.CategoryName).Where(x => x == subDomain).FirstOrDefault();

        }
    }
}
