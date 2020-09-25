using AutoMapper;
using Student.BLL.Model;
using Student.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Utils
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
        }
    }
}
