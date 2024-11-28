using System.Text.Json.Serialization;

namespace WebApiApplication.Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; } 
    }
}
