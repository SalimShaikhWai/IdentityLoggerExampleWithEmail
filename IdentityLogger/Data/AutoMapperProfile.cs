using AutoMapper;
using Demo63Assignment.Models.DataModel;
using Demo63Assignment.Models.ViewModel;

namespace Demo63Assignment.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Employee, UserViewModel>()
                .ForMember(de => de.DepartmentName, opt => opt.MapFrom(e => e.DepartmentRef.Name))
                .ReverseMap()
                .ForPath(de => de.DepartmentRef.Name, opt => opt.Ignore());

            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        }

    }
}
