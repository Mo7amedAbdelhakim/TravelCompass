using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelCompassLogic.TravelCompassDbContext;

namespace TravelCompassApplication.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery : IRequest<Result<GetCategoryByIdDto>>
    {
        public int Id { get; set; }
        private class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdDto>>
        {
            private ApplicationDbContext _context;

            public GetCategoryByIdQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Result<GetCategoryByIdDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.Where(x => x.CategoryId == request.Id).Select(x => new GetCategoryByIdDto
                {
                    Id = x.CategoryId,
                    Name = x.CategoryName
                }).FirstOrDefaultAsync();
                if (category == null)
                {
                    return Result.Failure<GetCategoryByIdDto>("Catgeory is Null");
                }
                return Result.Success(category);
            }
        }
    }
}
