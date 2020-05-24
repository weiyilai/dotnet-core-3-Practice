using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Api.ApiModels;
using Practice.Core.Entities;
using Practice.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            List<Course> entity = await _courseRepository.GetAllAsync<Course>();
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
            CourseDTO course = CourseDTO.FromCourse(await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id));

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
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
            Course model = new Course()
            {
                Title = course.Title,
                Credits = 1,
                DepartmentID = 1
            };
            _courseRepository.Add(model);
            return CreatedAtAction(nameof(Get), new { id = model.CourseID }, model);
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
            Course model = await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id);
            model.Title = course.Title;
            model.Credits = course.Credits;
            _courseRepository.Update(model);

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
            Course model = await _courseRepository.GetSingleAsync<Course>(t => t.CourseID == id);
            _courseRepository.Delete(model);

            return NoContent();
        }
    }
}
