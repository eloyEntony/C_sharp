using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.XML
{
    class Student
    {
        public int Id { get; set; }
        public string Name;
        public int Mark;

        public static Student[] GetAllStudents()
        {
            Student []students = new Student[1];

            students[0] = new Student
            {
                Id = 1,
                Name = "Bob",
                Mark = 10
            };

            return students;
        }
    }
}
