using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practice.Api.ApiModels;
using Practice.Core.Entities;
using Practice.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await _courseRepository.GetAllAsync<Course>();
            return Ok(entity.Select(CourseDTO.FromCourse));
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Get(int id)
        {
            var t = await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id);

            if (t == null)
            {
                return NotFound();
            }

            return Ok(CourseDTO.FromCourse(t));
        }

        // POST api/<CourseController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public IActionResult Post([FromBody] CourseDTO course)
        {
            var t = new Course()
            {
                Title = course.Title,
                Credits = 1,
                DepartmentID = 1
            };
            _courseRepository.Add<Course>(t);
            return Created("/api/Course/" + t.CourseID, t);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseDTO course)
        {
            var t = await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id);
            t.Title = course.Title;
            t.Credits = course.Credits;
            _courseRepository.Update<Course>(t);

            return Ok();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id);
            _courseRepository.Delete<Course>(t);

            return Ok();
        }
    }
}
