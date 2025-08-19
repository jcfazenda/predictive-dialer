﻿using AutoMapper;

namespace Services.Domain.Mapping
{
    public static class MapperConfigurationExpressionExtensions
    {
        public static void ConfigureApplicationProfiles(this IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.AddProfile(new DomainToViewModelProfile());

        }
    }
}
