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
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _context;
        private readonly IMapper _mapper;
        public CategoryController(IGenericRepository<Category> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("CategoryList")]
        public IActionResult CategoryList()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_context.GetAll()));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpGet("CategoryGet/{id}")]
        public IActionResult CategoryGet(int id)
        {
            try
            {
                var model = _mapper.Map<CategoryDto>(_context.GetById(id));
                if (model != null)
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

                throw;
            }
        }
        [HttpPut("CategoryEdit")]
        public IActionResult CategoryEdit(CategoryEditDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(_mapper.Map<Category>(model));
                    return Ok("Basarili");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("CategoryCreate")]
        public async Task<IActionResult> CategoryCreate(CategoryCreateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddAsync(_mapper.Map<Category>(model));
                    return Ok("Basarili");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("CategoryDelete")]
        public async Task<IActionResult> CategoryDeleteAsync(int id)
        {
            try
            {
                var model = await _context.GetByIdAsync(id);
                if (model != null)
                {
                    _context.Delete(model);
                    return Ok("Basarili");
                }
                else
                {
                    return NotFound(model);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
