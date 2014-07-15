using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using WcfServicesXmlSample.DO;
using WcfServiceXmlSample.Models;

namespace WcfServiceXmlSample.AutoMapperConfig
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get 
            { 
                return "DomainToViewModelMappings"; 
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoriesViewModel>();
         
        }
    }
}
