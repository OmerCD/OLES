using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OLES.Classes.Database;

namespace OLESClass
{
    public class FinishedTest : DbObject
    {
        public string OriginalTestId { get; set; }
        /// <summary>
        /// Questions answered by the student
        /// </summary>
        public List<Test.Question> Questions { get; set; }
        public Student Student { get; set; }
        public bool AnswerQuestion(Test.Question question)
        {
            //todo Send answers to the server
            throw new NotImplementedException();
        }

        public void CheckCorrectness()
        {
            var orignalTest = DbFactory.GenericFactory.TestGenericCRUD.GetOne(OriginalTestId);

        }
    }
}
