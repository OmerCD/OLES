using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OLESClass
{
    public class Test : DbObject
    {
        public List<Question> Questions { get; set; }
        [Display(Name = "Test Name")]
        [Required(ErrorMessage = "Please enter a name for test")]
        [MinLength(3, ErrorMessage = "Please enter minimum of 3 characters")]
        [MaxLength(25, ErrorMessage = "You are only allowed to enter up to 25 characters")]
        public string Name { get; set; }
        [Display(Name = "Time Amount (minutes)")]
        [Required(ErrorMessage = "Please enter a time for test")]
        [Range(5, 240, ErrorMessage = "Time should be between 5 and 240 minutes")]
        public int Time { get; set; }
        [Display(Name = "Number of questions per exam")]
        [Required(ErrorMessage = "Please enter a number")]
        [Range(3, 250, ErrorMessage = "Number should be between 3 and 250")]
        public int QuestionPoolCount { get; set; }

        public Test()
        {
            Questions = new List<Question>();
        }
    }
    public class Question : DbObject
    {
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select a category")]
        public Category Category { get; set; }
        [Display(Name = "Question")]
        [Required(ErrorMessage = "Please enter a question")]
        public string QuestionString { get; set; }
        public byte[] Picture { get; set; }
        public List<Answer> Answers { get; set; }

        public Question():base()
        {
            Answers = new List<Answer>();
        }
    }
    public class Answer : DbObject
    {
        public Answer(string answerText, bool checkedVariable)
        {
            AnswerText = answerText;
            Checked = checkedVariable;
        }

        [Display(Name = "Answer")]
        [Required(ErrorMessage = "Please enter an answer")]
        public string AnswerText { get; set; }
        public byte[] Picture { get; set; }
        [Display(Name = "Is Correct")]
        public bool Checked { get; set; }
    }
}