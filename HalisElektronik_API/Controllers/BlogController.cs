using AutoMapper;
using HalisElektronik.Dto;
using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation.Api.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HalisElektronik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IGenericRepository<HalisElektronik.Models.Blog> _context;
        private readonly IMapper _mapper;
        public BlogController(IGenericRepository<HalisElektronik.Models.Blog> context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;
        }

        #region Blog
        [HttpGet("BlogList")]
        public IActionResult BlogList()
        {
            try
            {
                var model = _mapper.Map<IEnumerable<HalisElektronik.Models.Blog>, IEnumerable<BlogDto>>(_context.GetAll(includeProperties: "Tags,BlogImage"));
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

                throw;
            }
        }

        [HttpGet("BlogGetAsync/{id}")]
        public IActionResult BlogGetAsync(int id)
        {
            try
            {
                var model = _mapper.Map<BlogDto>(_context.GetAll(filter: x => x.BlogId == id, includeProperties: "Tags,BlogImage").SingleOrDefault());
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

                throw new Exception();
            }
        }

        [HttpPost("BlogCreate")]
        public async Task<IActionResult> BlogCreate(BlogDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddAsync(_mapper.Map<HalisElektronik.Models.Blog>(model));
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

        [HttpPut("BlogEdit")]
        public IActionResult BlogEdit(BlogEditDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(_mapper.Map<HalisElektronik.Models.Blog>(model));
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

        [HttpDelete("BlogDelete/{id}")]
        public async Task<IActionResult> BlogDeleteAsync(int id)
        {
            try
            {
                var model = await _context.GetByIdAsync(id);
                _context.Delete(model);
                return Ok("Basarili");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        
    }
}

