using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;

namespace WebApiApplication.Service
{
    public class InstructorService : IInstructorService
    {

        private readonly ApplicationDbContext _dbContext;

        public InstructorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Instructor AddNewInstructor(Instructor instructor)
        {
            _dbContext.Instructors.Add(instructor);
            _dbContext.SaveChanges();
            return instructor;
        }

        public List<Instructor> GetAllInstructors()
        {
            return _dbContext.Instructors.ToList();
        }

        public Instructor GetInstructorById(int id)
        {
            var instructor = _dbContext.Instructors.Find(id);
            return instructor;
        }

        public void DeleteInstructor(int id)
        {
            var instructor = GetInstructorById(id);
            _dbContext.Remove(instructor);
            _dbContext.SaveChanges();
        }

        public Instructor UpdateInstructor(Instructor instructor)
        {
            _dbContext.Entry(instructor).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return instructor;
        }

        public List<Course> GetCoursesByInstructorId(int id)
        {
            var courses = _dbContext.Courses.Where(val => val.InstructorId == id).ToList();
            return courses;
        }
    }
}
