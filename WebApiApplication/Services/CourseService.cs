using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;

namespace WebApiApplication.Service
{
    public class CourseService : ICourseService
    {

        private readonly ApplicationDbContext _dbContext;

        public CourseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course AddCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return course;
        }

        public void DeleteCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _dbContext.Courses.Find(id);
        }

        public Course GetCourseByIdInstructor(int id)
        {
            var course = _dbContext.Courses.Include(c => c.Instructor).First(courseInfo => courseInfo.Id == id);

            return course;
        }

        public Course UpdateCourse(Course course)
        {
            _dbContext.Entry(course).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return course;
        }
    }
}
