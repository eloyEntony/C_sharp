using Student.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.BLL.Services
{
    interface IStudentService
    {
        IEnumerable<StudentDTO> GetStudents();
        void AddStudent(StudentDTO student);
    }
}
