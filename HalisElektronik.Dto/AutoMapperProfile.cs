using AutoMapper;
using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Products
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductEditDto>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            #endregion

            #region Blog
            CreateMap<Models.Blog, BlogDto>().ReverseMap();
            CreateMap<BlogsTag, BlogTagDto>().ReverseMap();
            CreateMap<Models.Blog, BlogEditDto>().ReverseMap();
            #endregion

            #region Images
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<Models.Image, ImageDto>().ReverseMap();
            CreateMap<Models.EntityType, EntityType>().ReverseMap();

            #endregion
            #region Home
            CreateMap<CarouselMain, CarouselMainDto>().ReverseMap();
            CreateMap<CarouselMain, CarouselMainCreateDto>().ReverseMap();

            CreateMap<ContainerMarketing, ContainerMarketingDto>().ReverseMap();
            CreateMap<ContainerMarketing, ContainerMarketingCreateDto>().ReverseMap();

            CreateMap<FeaturetteMain, FeaturetteMainDto>().ReverseMap();
            CreateMap<FeaturetteMain, FeaturetteMainCreateDto>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaCreateDto>().ReverseMap();
            #endregion
            #region Info

            CreateMap<Info, InfoDto>().ReverseMap();
            CreateMap<Info, InfoCreateDto>().ReverseMap();
            #endregion
        }
    }
}
