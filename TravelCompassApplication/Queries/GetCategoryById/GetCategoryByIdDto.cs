namespace TravelCompassApplication.Queries.GetCategoryById
{
    public record GetCategoryByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
