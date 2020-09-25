using AutoMapper;
using Student.BLL.Model;
using University.DAL;

using University.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BLL.Services
{
    class StudentService : IStudentService
    {
        private readonly IGenericReository<Student> repoS;
        private readonly IGenericReository<Groups> repoG;
        private readonly IMapper mapper;

        public StudentService( IGenericReository<Student> _repoS,
                               IGenericReository<Groups> _repoG,
                               IMapper _mapper)
        {
            repoS = _repoS;
            repoG = _repoG;
            mapper = _mapper;
        }
        public void AddStudent(StudentDTO student)
        {
            var addStud = mapper.Map<Student>(student);
            repoS.Create(addStud);
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            var students = repoS.GetAll();
            var model = mapper.Map<ICollection<StudentDTO>>(students);
            return model;
        }
    }
}
