using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.UI.WebControls;
using MongoDB.Bson.Serialization.Serializers;
using OLES.Classes;

namespace OLESClass
{
    public class Lobby : DbObject
    {
        [Display(Name = "Lobby Name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Lobby name length should be between 3-25")]
        public string Name { get; set; }
        public List<Student> WaitingStudents { get; set; }
        public Test Test { get; set; }
        public int WaitingCount => WaitingStudents.Count;
        [Display(Name = "Maximum Number of Students")]
        public int MaximumStudentCount { get; set; }
        [Display(Name = "Time Amount (minutes)")]
        [Required(ErrorMessage = "Please enter a time for test")]
        [Range(5, 240, ErrorMessage = "Time should be between 5 and 240 minutes")]
        public int Time { get; set; }
        [Display(Name = "Number of questions per exam")]
        [Required(ErrorMessage = "Please enter a number")]
        [Range(3, 250, ErrorMessage = "Number should be between 3 and 250")]
        public int QuestionPoolCount { get; set; }
        public string LobbyOWner { get; set; }
        /// <summary>
        /// If current lobby does not contain the given student, this method will add student to the waiting list of the lobby
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool AddStudent(Student student)
        {
            if (WaitingStudents.Contains(student)) return false;
            student.EnteredLobby = this;
            WaitingStudents.Add(student);
            return true;

        }

        public Queue<Question> AssignTests()
        {
            if (Test.Questions.Count < QuestionPoolCount)
            {
                //todo throw exception
            }
            Random random = new Random();

            Queue<Question> questions = new Queue<Question>();
            HashSet<int> popedQuestions = new HashSet<int>();
            int j = 0;
            while (j < QuestionPoolCount)
            {
                var ranNum = random.Next(QuestionPoolCount);
                if (!popedQuestions.Contains(ranNum))
                {
                    popedQuestions.Add(ranNum);
                    questions.Enqueue(Test.Questions[ranNum]);
                    j++;
                }
            }

            return questions;
        }
        public bool AssignGlobalQuestionVariable()
        {
            GlobalVariables.CurrentQuestions = AssignTests();
            return false;
        }
    }
}