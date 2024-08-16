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
    public class InfoController : ControllerBase
    {
        private readonly IGenericRepository<Info> _context;
        private readonly IMapper _mapper;
        public InfoController(IGenericRepository<Info> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("InfoList")]
        public IActionResult InfoList()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Info>, IEnumerable<InfoDto>>(_context.GetAll()));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpGet("InfoGet/{id}")]
        public IActionResult InfoGet(int id)
        {
            try
            {
                var model = _mapper.Map<InfoDto>(_context.GetById(id));
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

        [HttpPut("InfoEdit")]
        public IActionResult InfoEdit(InfoCreateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(_mapper.Map<Info>(model));
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

        [HttpPost("InfoCreate")]
        public async Task<IActionResult> InfoCreate(InfoCreateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddAsync(_mapper.Map<Info>(model));
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

        [HttpDelete("InfoDelete/{id}")]
        public async Task<IActionResult> InfoDeleteAsync(int id)
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
