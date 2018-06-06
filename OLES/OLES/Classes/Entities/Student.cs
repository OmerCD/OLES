using System.Collections.Generic;

namespace OLESClass
{
    public class Student : User
    {
        public List<StudentResult> PrevStudentResults { get; set; }

        public Student()
        {
            PrevStudentResults = new List<StudentResult>();
        }
    }
    public class StudentResult
    {
        public Test Test { get; set; }
        public double Percentage { get; set; }

    }
}