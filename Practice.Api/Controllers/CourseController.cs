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
    /// <summary>
    /// Course Api
    /// </summary>
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
        /// <summary>
        /// 取得所有Course資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await _courseRepository.GetAllAsync<Course>();
            return Ok(entity.Select(CourseDTO.FromCourse));
        }

        // GET api/<CourseController>/5
        /// <summary>
        /// 取得指定的Course資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
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
        /// <summary>
        /// 新增Course資料
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
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
            return CreatedAtAction(nameof(Get), new { id = t.CourseID }, t);
        }

        // PUT api/<CourseController>/5
        /// <summary>
        /// 更新Course資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Put(int id, [FromBody] CourseDTO course)
        {
            var t = await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id);
            t.Title = course.Title;
            t.Credits = course.Credits;
            _courseRepository.Update<Course>(t);

            return NoContent();
        }

        // DELETE api/<CourseController>/5
        /// <summary>
        /// 刪除指定的Course資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            var t = await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id);
            _courseRepository.Delete<Course>(t);

            return NoContent();
        }
    }
}
