using System.Collections.Generic;

namespace OLESClass
{
    public class Lobby : DbObject
    {
        public string Name { get; set; }
        public List<Student> WaitingStudents { get; set; }
        public Test Test { get; set; }
        public int WaitingCount => WaitingStudents.Count;
        public int MaximumStudentCount { get; set; }
        public int Time { get; set; }
        public int QuestionPoolCount { get; set; }

        public bool AddStudent(Student student)
        {
            if (WaitingStudents.Contains(student)) return false;
            WaitingStudents.Add(student);
            return true;

        }

        public bool StartExam()
        {
            //todo Put exam system here
            return false;
        }
    }
}