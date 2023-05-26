using AutoMapper;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayer.Service.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {

            var config = new MapperConfiguration(cfg =>
            {

                cfg.Internal().MethodMappingEnabled = false;
                cfg.AddProfile<DtoMapper>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}