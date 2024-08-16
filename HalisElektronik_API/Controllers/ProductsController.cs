using AutoMapper;
using HalisElektronik.Dto;
using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation;
using HalisElektronik.Repositories.Implementation.Api.Generic;
using HalisElektronik.Repositories.Implementation.Api.Inteface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HalisElektronik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _context;
        private readonly IGenericImageRepository<ProductImage> _productImage;
        private readonly string _imageLibraryPath = Path.Combine(Directory.GetCurrentDirectory(), "ImageLibrary");

        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> context, IMapper mapper, IGenericImageRepository<ProductImage> productImage)
        {
            _context = context;
            _mapper = mapper;
            _productImage = productImage;
        }

        [HttpGet("ProductsList")]
        public IActionResult ProductList()
        {
            try
            {
                IEnumerable<ProductDto> model = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_context.GetAll(includeProperties: "ProductImages,Category"));
                if (model != null)
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [HttpPost("ProductCreate")]
        public async Task<IActionResult> ProductCreate(ProductCreateDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.AddAsync(_mapper.Map<Product>(model));
                    return Ok("Basarili");
                }
                catch (Exception)
                {
                    return BadRequest("Hata");
                    throw new Exception();
                }
            }
            else
            {
                ModelState.AddModelError("", "Hata Model de");
                return BadRequest();
            }


        }
        [HttpGet("ProductGet/{id}")]
        public IActionResult ProductGet(int id)
        {
            var model = _mapper.Map<Product, ProductDto>(_context.GetAll(includeProperties: "ProductImages,Category",
                filter: x => x.ProductId == id).SingleOrDefault());
            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("ProductEdit")]
        public IActionResult ProductEdit(ProductEditDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_mapper.Map<Product>(model));
                    return Ok("Basarili");

                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("ProductDelete/{id}")]
        public IActionResult ProductDelete(int id)
        {
            try
            {
                _context.Delete(_context.GetById(id));
                return Ok("Basarili");
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        #region Product Image

        [HttpGet("ProductImageGetList/{id}")]
        public IActionResult ProductImageGetList(int id)
        {
            try
            {
                
                var model = _productImage.ProductImageGet(id);

                return Ok(model);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpGet("ProductImageGet/{id}")]
        public IActionResult ProductImageGet(int id)
        {
            try
            {

                var model = _productImage.GetById(id);

                return Ok(model);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        [HttpDelete("ProductImageDelete/{id}")]
        public IActionResult ProductImageDelete(int id)
        {
            try
            {
                var model = _productImage.GetById(id);
                if (string.IsNullOrEmpty(model.ImageUrl))
                {
                    BadRequest("Image Bos!");
                }
                var filePath = Path.Combine(_imageLibraryPath, model.ImageUrl);

                if (!System.IO.File.Exists(filePath))
                {
                    NotFound("Image Bulunamadi!.");
                }
                _productImage.ImageDelete(model.ImageUrl);
                _productImage.Delete(model);
                return Ok("Silindi");
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpPost("ProductImageCreateByModel")]
        public async Task<IActionResult> ImageCreateByModel([FromBody] ProductImageDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductImage Image = await _productImage.AddAsync(_mapper.Map<ProductImage>(model));
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

        [HttpGet("ProductsGetList/{id}")]
        public IActionResult ImageGetListById(int id)
        {
            try
            {
                IEnumerable<ProductImage> list = _mapper.Map<IEnumerable<ProductImage>>(_productImage.GetAll(filter: x => x.Id == id));
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
        [HttpPost("ProductImageUpdate")]
        public async Task<IActionResult> ImageUpdateAsync(ProductImageDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productImage.Update(_mapper.Map<ProductImage>(model));
                    return Ok(await _productImage.GetByIdAsync(model.Id));
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
        /// İmage class a bir şey yapmıyorsun sadece class tan url çekip dosyayı siliyorsun.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("ProductImageUpdateDelete/{id}")]
        public IActionResult ImageUpdateDelete(int id)
        {
            try
            {
                var model = _productImage.GetById(id);
                if (string.IsNullOrEmpty(model.ImageUrl))
                {
                    BadRequest("Image Bos!");
                }
                var filePath = Path.Combine(_imageLibraryPath, model.ImageUrl);

                if (!System.IO.File.Exists(filePath))
                {
                    NotFound("Image Bulunamadi!.");
                }
                _productImage.ImageDelete(model.ImageUrl);
                return Ok("Silindi");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
