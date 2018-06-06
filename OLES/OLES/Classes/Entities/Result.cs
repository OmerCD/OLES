using System.Collections.Generic;

namespace OLESClass
{
    public class Result
    {
        public List<QuestionIndex> Questions { get; set; }

        public struct QuestionIndex
        {
            public Test.Question Question { get; set; }
            public List<StudentAnswerIndex> StudentAnswerIndices { get; set; }
        }
        public struct StudentAnswerIndex
        {
            public Student Student { get; set; }
            public int[] Answers { get; set; }
        }
    }
}