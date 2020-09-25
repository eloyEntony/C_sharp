using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using University.BLL.Model;
using University.DAL.Entityes;

namespace University.BLL.Utils
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentDTO>()
                  .ForMember(x => x.Group, opt => opt
                  .MapFrom(x => x.Groups.Name));

            CreateMap<StudentDTO, Student>()
                .ForMember(x => x.Groups, opt => opt
                .MapFrom(x => new Groups { Name = x.Group }));

            CreateMap<Groups, GroupsDTO>();
            CreateMap<GroupsDTO, Groups>();

        }
    }
}
