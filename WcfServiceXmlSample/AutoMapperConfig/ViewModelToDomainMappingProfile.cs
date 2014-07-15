using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WcfServicesXmlSample.DO;
using WcfServiceXmlSample.Models;

namespace WcfServiceXmlSample.AutoMapperConfig
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CategoriesViewModel, Category>();
        }
    }
}
