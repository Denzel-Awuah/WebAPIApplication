namespace WebApiApplication.Models.DTOs
{
    public class AddProductDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
    }
}
