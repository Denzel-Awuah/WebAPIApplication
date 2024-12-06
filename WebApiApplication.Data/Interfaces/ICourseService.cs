using WebApiApplication.Models;

namespace WebApiApplication.Interfaces
{
    public interface ICourseService
    {
        public List<Course> GetAllCourses();
        public Course AddCourse(Course course);
        public void DeleteCourse(Course course);
        public Course GetCourseById(int id);
        public Course GetCourseByIdInstructor(int id);
        public Course UpdateCourse(Course course);
    }
}
