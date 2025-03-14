using CSharpFunctionalExtensions;
using MediatR;
using TravelCompassData.Models;
using TravelCompassLogic.TravelCompassDbContext;

namespace TravelCompassApplication.Commands.AddNewCategory
{
    public record AddNewCategoryCommand : IRequest<Result>
    {
        public string CategoryName { get; set; } = string.Empty;

        public class AddNewCategoryCommandHandler : IRequestHandler<AddNewCategoryCommand, Result>
        {
            private readonly ApplicationDbContext _context;
            public AddNewCategoryCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Result> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = Category.Instance(request.CategoryName);
                _context.Categories.Add(category.Value);
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success(category);
            }
        }
    }
}
