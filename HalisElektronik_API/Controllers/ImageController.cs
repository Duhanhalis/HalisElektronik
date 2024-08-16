using AutoMapper;
using HalisElektronik.Dto;
using HalisElektronik.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HalisElektronik.Repositories.Implementation;
using System.Xml.Linq;
using HalisElektronik.Repositories.Implementation.Api.Inteface;
namespace HalisElektronik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IGenericImageRepository<Image> _context;
        private readonly IMapper _mapper;
        private readonly string _imageLibraryPath = Path.Combine(Directory.GetCurrentDirectory(), "ImageLibrary");
        public ImageController(IGenericImageRepository<Image> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("ImageList")]
        public IActionResult ImageList()
        {
            try
            {
                IEnumerable<ImageDto> model = _mapper.Map<IEnumerable<ImageDto>>(_context.GetAll());
                return Ok(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Image id göre çağrılır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ImageGetById/{id}")]
        public async Task<IActionResult> ImageGetById(int id)
        {
            try
            {
                ImageDto model = _mapper.Map<ImageDto>(await _context.GetByIdAsync(id));
                return Ok(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Sadece Class oluşturmak için kullanılır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("ImageCreateByModel")]
        public async Task<IActionResult> ImageCreateByModel([FromBody] ImageDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Image Image = await _context.AddAsync(_mapper.Map<Image>(model));
                    return Ok(Image);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpGet("{id}")]
        public IActionResult ImageGetListById(int id)
        {
            try
            {
                IEnumerable<ImageDto> list = _mapper.Map<IEnumerable<ImageDto>>(_context.GetAll(filter: x => x.Id == id));
                if (list.Any())
                {
                    return Ok(list);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        /// <summary>
        /// Class update etmek için kullanılır.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ImageUpdate")]
        public async Task<IActionResult> ImageUpdateAsync(ImageDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(_mapper.Map<Image>(model));
                    return Ok(await _context.GetByIdAsync(model.Id));
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

        /// <summary>
        /// Hem image hemde class siliyorsun.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpDelete("ImageDelete/{id}")]
        public IActionResult ImageDelete(int id)
        {
            try
            {
                var model = _context.GetById(id);
                if (string.IsNullOrEmpty(model.ImageUrl))
                {
                    BadRequest("Image Bos!");
                }
                var filePath = Path.Combine(_imageLibraryPath, model.ImageUrl);

                if (!System.IO.File.Exists(filePath))
                {
                    NotFound("Image Bulunamadi!.");
                }
                _context.ImageDelete(model.ImageUrl);
                _context.Delete(model);
                return Ok("Silindi");
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        /// <summary>
        /// İmage class a bir şey yapmıyorsun sadece class tan url çekip dosyayı siliyorsun.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("ImageUpdateDelete/{id}")]
        public IActionResult ImageUpdateDelete(int id)
        {
            try
            {
                var model = _context.GetById(id);
                if (string.IsNullOrEmpty(model.ImageUrl))
                {
                    BadRequest("Image Bos!");
                }
                var filePath = Path.Combine(_imageLibraryPath, model.ImageUrl);

                if (!System.IO.File.Exists(filePath))
                {
                    NotFound("Image Bulunamadi!.");
                }
                _context.ImageDelete(model.ImageUrl);
                return Ok("Silindi");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Razor page de kullanılmak üzere geliştirildi.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("GetImageByName/{name}")]
        public IActionResult GetImageByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name parameter is required.");
            }

            var filePath = Path.Combine(_imageLibraryPath, name);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image not found.");
            }

            var imageFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var mimeType = GetMimeType(filePath);

            return File(imageFileStream, mimeType);
        }

        /// <summary>
        /// Fotoğrafı Oluşturmak için kullanılır. Bundan sonra class a göndermen lazım.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        [HttpPost("PhotoCreate")]
        public async Task<IActionResult> PhotoCreate([FromForm] IFormFile model, string name)
        {
            try
            {
                string result = await _context.ImageCreate(model, name);

                return Ok(result);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        private string GetMimeType(string filePath)
        {
            // Bu yöntem basit bir MIME tipi belirleme yöntemi içerir. 
            // Gelişmiş bir yöntem için MimeMapping NuGet paketini kullanabilirsiniz.
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream",
            };
        }

    }
}
