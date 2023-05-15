using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile() {

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<PersonnelSeniority, PersonnelWithPersonnelSeniorityDto>();
            CreateMap<Personnel, PersonnelDto>().ReverseMap();
            CreateMap<Watch, WatchDto>().ReverseMap();
            CreateMap<PersonnelSeniority, PersonnelSeniorityDto>().ReverseMap();
            CreateMap<CanceledWatch, CanceledWatchDto>().ReverseMap();
            CreateMap<Personnel, PersonnelWithPersonnelSeniorityDto>();
            CreateMap<Watch, WatchWithPersonnelsDto>();
            CreateMap<Personnel, PersonnelWithWatchDto>();
        }
    }
}
