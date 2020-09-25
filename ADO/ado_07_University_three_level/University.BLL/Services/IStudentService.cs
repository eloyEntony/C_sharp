using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BLL.Model;

namespace University.BLL.Services
{
   public interface IStudentService
    {
        IEnumerable<StudentDTO> GetStudents();
        void AddStudent(StudentDTO student);
        void DeleteStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
    }
}
