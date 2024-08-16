
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
    public class HomeController : ControllerBase
    {
        private readonly IGenericRepository<FeaturetteMain> _context;
        private readonly IGenericRepository<CarouselMain> _carouselMain;
        private readonly IGenericRepository<ContainerMarketing> _containerMarketing;
        private readonly IGenericRepository<SocialMedia> _socialMedia;
        private readonly IGenericRepository<Image> _image;

        private readonly IMapper _mapper;
        public HomeController(IGenericRepository<FeaturetteMain> context, IMapper mapper, IGenericRepository<CarouselMain> carouselMain, IGenericRepository<ContainerMarketing> containerMarketing, IGenericRepository<SocialMedia> socialMedia, IGenericRepository<Image> image)
        {
            _context = context;
            _mapper = mapper;
            _carouselMain = carouselMain;
            _containerMarketing = containerMarketing;
            _socialMedia = socialMedia;
            _image = image;
        }

        #region FeaturetteMain

        [HttpGet("FeaturetteMainList")]
        public IActionResult FeaturetteMainList()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<FeaturetteMain>, IEnumerable<FeaturetteMainDto>>(_context.GetAll(includeProperties: "Images")));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpGet("FeaturetteMainGet/{id}")]
        public IActionResult FeaturetteMainGet(int id)
        {
            try
            {
                var model = _context.GetById(id);

                var modelImage = _image.GetById(model.ImageId);

                if (model != null)
                {
                    return Ok(_mapper.Map<FeaturetteMainDto>(new FeaturetteMain()
                    {
                        ImageId = model.ImageId,
                        Description = model.Description,
                        FeaturetteMainId = model.FeaturetteMainId,
                        Images = modelImage,
                        Title = model.Title
                    }));
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

        [HttpPut("FeaturetteMainEdit")]
        public IActionResult FeaturetteMainEdit(FeaturetteMainDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(_mapper.Map<FeaturetteMain>(model));
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

        [HttpPost("FeaturetteMainCreate")]
        public async Task<IActionResult> FeaturetteMainCreate(FeaturetteMainCreateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.AddAsync(_mapper.Map<FeaturetteMain>(model));
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

        [HttpDelete("FeaturetteMainDelete/{id}")]
        public async Task<IActionResult> FeaturetteMainDeleteAsync(int id)
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
        #endregion

        #region CarouselMain

        [HttpGet("CarouselMainList")]
        public IActionResult CarouselMainList()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<CarouselMain>, IEnumerable<CarouselMainDto>>(_carouselMain.GetAll(includeProperties: "Images")));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpGet("CarouselMainGet/{id}")]
        public IActionResult CarouselMainGet(int id)
        {
            try
            {
                var model = _carouselMain.GetById(id);

                var modelImage = _image.GetById(model.ImageId);
                if (model != null)
                {
                    return Ok(_mapper.Map<CarouselMainDto>(new CarouselMain()
                    {
                        Title = model.Title,
                        Images = modelImage,
                        Description = model.Description,
                        ImageId = model.ImageId,
                        BtnTitle = model.BtnTitle,
                        BtnUrl = model.BtnUrl,
                        CarouselMainId = model.CarouselMainId
                    }));
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

        [HttpPut("CarouselMainEdit")]
        public IActionResult CarouselMainEdit(CarouselMainDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carouselMain.Update(_mapper.Map<CarouselMain>(model));
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

        [HttpPost("CarouselMainCreate")]
        public async Task<IActionResult> CarouselMainCreate(CarouselMainCreateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _carouselMain.AddAsync(_mapper.Map<CarouselMain>(model));
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

        [HttpDelete("CarouselMainDelete/{id}")]
        public async Task<IActionResult> CarouselMainDeleteAsync(int id)
        {
            try
            {
                var model = await _carouselMain.GetByIdAsync(id);
                if (model != null)
                {
                    _carouselMain.Delete(model);
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
        #endregion

        #region ContainerMarketing
        [HttpGet("ContainerMarketingList")]
        public IActionResult ContainerMarketingList()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<ContainerMarketing>, IEnumerable<ContainerMarketingDto>>(_containerMarketing.GetAll(includeProperties: "Images")));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpGet("ContainerMarketingGet/{id}")]
        public IActionResult ContainerMarketingGet(int id)
        {
            try
            {
                var model = _containerMarketing.GetById(id);
                var modelImage = _image.GetById(model.ImageId);
                if (model != null)
                {
                    return Ok(_mapper.Map<ContainerMarketingDto>(new ContainerMarketing()
                    {
                        ImageId = model.ImageId,
                        Description = model.Description,
                        Images = modelImage,
                        Title = model.Title,
                        ContainerMarketingId = model.ContainerMarketingId
                    }));
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

        [HttpPut("ContainerMarketingEdit")]
        public IActionResult ContainerMarketingEdit(ContainerMarketingDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _containerMarketing.Update(_mapper.Map<ContainerMarketing>(model));
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

        [HttpPost("ContainerMarketingCreate")]
        public async Task<IActionResult> ContainerMarketingCreate(ContainerMarketingCreateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _containerMarketing.AddAsync(_mapper.Map<ContainerMarketing>(model));
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

        [HttpDelete("ContainerMarketingDelete/{id}")]
        public async Task<IActionResult> ContainerMarketingDeleteAsync(int id)
        {
            try
            {
                var model = await _containerMarketing.GetByIdAsync(id);
                if (model != null)
                {
                    _containerMarketing.Delete(model);
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
        #endregion

        #region SocialMedia
        [HttpGet("SocialMediaList")]
        public IActionResult SocialMediaList()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<SocialMedia>, IEnumerable<SocialMediaDto>>(_socialMedia.GetAll(includeProperties: "Images")));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpGet("SocialMediaGet/{id}")]
        public IActionResult SocialMediaGet(int id)
        {
            try
            {
                var model = _socialMedia.GetById(id);

                var modelImage = _image.GetById(model.ImageId);
                if (model != null)
                {
                    return Ok(_mapper.Map<SocialMediaDto>(new SocialMedia()
                    {
                        Title = model.Title,
                        Images = modelImage,
                        ImageId = model.ImageId,
                        Link = model.Link,
                        SocialMediaId = model.SocialMediaId
                    }));
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

        [HttpPut("SocialMediaEdit")]
        public IActionResult SocialMediaEdit(SocialMediaDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _socialMedia.Update(_mapper.Map<SocialMedia>(model));
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

        [HttpPost("SocialMediaCreate")]
        public async Task<IActionResult> SocialMediaCreate(SocialMediaCreateDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _socialMedia.AddAsync(_mapper.Map<SocialMedia>(model));
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

        [HttpDelete("SocialMediaDelete/{id}")]
        public async Task<IActionResult> SocialMediaDeleteAsync(int id)
        {
            try
            {
                var model = await _socialMedia.GetByIdAsync(id);
                if (model != null)
                {
                    _socialMedia.Delete(model);
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
        #endregion
    }
}
