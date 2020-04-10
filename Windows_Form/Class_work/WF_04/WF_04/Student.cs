using System;

namespace WF_04
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string Hobby { get; set; }

        public override string ToString()
        {
            return $" {Name} _ {Surname} _ {Birthday.ToShortDateString()} _ {Gender} _ {Hobby}";
        }

        public Student() { }
    }
}
