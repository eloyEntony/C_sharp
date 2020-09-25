using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BLL.Model;
using University.DAL;
using University.DAL.Repository;

namespace University.BLL.Services
{
    public class StudentService: IStudentService
    {
        private readonly IGenericRepository<Student> repoS;
        private readonly IGenericRepository<Groups> repoG;
        private readonly IMapper mapper;
        public StudentService( IGenericRepository<Student> _repoS,
                                 IGenericRepository<Groups> _repoG,
                                 IMapper _mapper)
        {
            repoS = _repoS;
            repoG = _repoG;
            mapper = _mapper;
        }

        public void AddStudent(StudentDTO student)
        {
            var addStudent = mapper.Map<Student>(student);
            
            repoS.Create(addStudent);
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            var students = repoS.GetAll().ToList();
          
            var model = mapper.Map<ICollection<StudentDTO>>(students);
            return model;
        }
    }
}
