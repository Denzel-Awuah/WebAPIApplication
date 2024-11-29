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
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }


        // GET: api/Instructors
        [HttpGet]
        public IActionResult GetInstructors()
        {
            return Ok(_instructorService.GetAllInstructors());
        }

        // GET: api/Instructors/5
        [HttpGet("{id}")]
        public IActionResult GetInstructor(int id)
        {
            var instructor = _instructorService.GetInstructorById(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }

        // GET: api/Instructors/1/Courses
        [HttpGet("{instructorId}/courses")]
        public IActionResult GetCoursesByInstructorId(int instructorId)
        {
            var instructor = _instructorService.GetInstructorById(instructorId);

            if (instructor == null)
            {
                return NotFound();
            }

            instructor.Courses = _instructorService.GetCoursesByInstructorId(instructorId);

            return Ok(instructor);
        }


        // PUT: api/Instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutInstructor([FromRoute] int id,[FromBody] Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest();
            }

            _instructorService.UpdateInstructor(instructor);
            
            return Ok(instructor);
        }

        // POST: api/Instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostInstructor(Instructor instructor)
        {
            var newInstructor = _instructorService.AddNewInstructor(instructor);

            return CreatedAtAction("GetInstructor", new { id = instructor.Id }, newInstructor);
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            
            if (!InstructorExists(id))
            {
                return NotFound();
            }

            _instructorService.DeleteInstructor(id);

            return NoContent();
        }


        private bool InstructorExists(int id)
        {
            var instructor = _instructorService.GetInstructorById(id);
            if (instructor == null)
                return false;
            return true;
        }
    }
}
