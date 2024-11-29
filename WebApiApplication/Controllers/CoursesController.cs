using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        // GET: api/Courses
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(_courseService.GetAllCourses());
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public IActionResult GetCourseById([FromRoute] int id)
        {
            var course = _courseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // GET: api/Courses/5/instructor
        [HttpGet("{id}/Instructor")]
        public IActionResult GetCourseInstructor([FromRoute] int id)
        {
            var course = _courseService.GetCourseByIdInstructor(id);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateCourseById([FromRoute] int id, [FromBody] Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _courseService.UpdateCourse(course);

            return Ok(course);
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateNewCourse([FromBody] Course course)
        {
            _courseService.AddCourse(course);
           
            return CreatedAtAction("GetCourseById", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCourseById([FromRoute] int id)
        {
            var course =  _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            _courseService.DeleteCourse(course);

            return Ok(course);
        }

        private bool CourseExists([FromRoute] int id)
        {
            var course = _courseService.GetCourseById(id);
            if(course == null)
            {
                return false;
            }
            return true;
        }
    }
}
