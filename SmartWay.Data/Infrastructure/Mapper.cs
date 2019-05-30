//using BusinessEntities;
using System.Collections.Generic;
using AutoMapper;
using SmartWay.Model.Models;


namespace SmartWay.Data.Infrastructure
{
    public class Mapper
    {
        public static List<ApplicationViewModel> applicationViewModelMapper(List<Application> prefList)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Application, ApplicationViewModel>();
            }).CreateMapper().Map<List<Application>, List<ApplicationViewModel>>(prefList);
        }

    }
}
