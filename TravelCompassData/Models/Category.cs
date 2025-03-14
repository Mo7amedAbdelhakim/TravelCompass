using CSharpFunctionalExtensions;

namespace TravelCompassData.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public static Result<Category> Instance(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return Result.Failure<Category>("Name Can't be Null");
            }
            var category = new Category { CategoryName = Name };
            return Result.Success(category);
        }

    }
}
