namespace TravelCompassApplication.Queries.GetAllCategory
{
    public record GetAllCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

    }
}
