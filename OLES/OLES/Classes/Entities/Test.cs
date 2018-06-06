using System.Collections.Generic;

namespace OLESClass
{
    public class Test : DbObject
    {
        public List<Question> Questions { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int QuestionPoolCount { get; set; }
        public class Question : DbObject
        {
            public Category Category { get; set; }
            public string QuestionString { get; set; }
            public byte[] Picture { get; set; }
            public List<Answer> Answers { get; set; }
        }
        public class Answer : DbObject
        {
            public string AnswerText { get; set; }
            public byte[] Picture { get; set; }
            public bool Checked { get; set; }
        }
    }
}