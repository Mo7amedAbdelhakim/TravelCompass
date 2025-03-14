using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelCompassLogic.TravelCompassDbContext;

namespace TravelCompassApplication.Queries.GetAllCategory
{
    public record GetAllCategoryQuery : IRequest<Result<List<GetAllCategoryDto>>>
    {
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, Result<List<GetAllCategoryDto>>>
        {
            private readonly ApplicationDbContext _context;

            public GetAllCategoryQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<GetAllCategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
            {
                var Categories = await _context.Categories.Select(x => new GetAllCategoryDto
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName
                }).ToListAsync();
                return Result.Success(Categories);

            }
        }
    }
}
