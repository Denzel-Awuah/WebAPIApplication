using WebApiApplication.Models;

namespace WebApiApplication.Interfaces
{
    public interface IInstructorService
    {
        public List<Instructor> GetAllInstructors();
        public Instructor GetInstructorById(int id);
        public List<Course> GetCoursesByInstructorId(int id);
        public Instructor AddNewInstructor(Instructor instructor);
        public Instructor UpdateInstructor(Instructor instructor);
        public void DeleteInstructor(int id);
    }
}
