using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data;

namespace Services.MapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Company, CompanyInfoDto>();
            CreateMap<CompanyInfoDto, Company>();

            CreateMap<Departament, DepartamentDto>();
            CreateMap<DepartamentDto, Departament>()
                .ForMember(e => e.CreatedDate, p=> p.MapFrom(f => DateTime.Now))
                .ForMember(e => e.UpdatedDate, p => p.MapFrom(f => DateTime.Now));

            CreateMap<Division, DivisionDto>();
            CreateMap<DivisionDto, Division>();
        }
    }
}
