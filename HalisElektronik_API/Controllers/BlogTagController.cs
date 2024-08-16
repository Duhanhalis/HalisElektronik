using AutoMapper;
using HalisElektronik.Dto;
using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation.Api.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HalisElektronik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagController : ControllerBase
    {
        private readonly IGenericRepository<BlogsTag> _context;
        private readonly IMapper _mapper;

        public BlogTagController(IGenericRepository<BlogsTag> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("BlogTagList")]
        public IActionResult BlogTagList()
        {
            try
            {
                var model = _mapper.Map<IEnumerable<BlogsTag>, IEnumerable<BlogTagDto>>(_context.GetAll(includeProperties:"Blogs"));
                if (model != null && model.Any())
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound(model);
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpPost("BlogTagCreate")]
        public async Task<IActionResult> BlogTagCreate(BlogTagDto model)
        {
            try
            {
                var create = await _context.AddAsync(_mapper.Map<BlogsTag>(model));
                return Ok("Basarili");
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpPut("BlogTagEdit")]
        public IActionResult BlogTagEdit(BlogTagDto model)
        {
            try
            {
                _context.Update(_mapper.Map<BlogsTag>(model));
                return Ok("Basarili");
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpGet("BlogTagGet/{id}")]
        public async Task<IActionResult> BlogTagGet(int id)
        {
            try
            {
                return Ok(await _context.GetByIdAsync(id));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpDelete("BlogTagDelete/{id}")]
        public async Task<IActionResult> BlogTagDelete(int id)
        {
            try
            {
                var model = await _context.GetByIdAsync(id);
                _context.Delete(model);
                return Ok("Basarili");
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
