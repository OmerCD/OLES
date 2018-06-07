using System.Collections.Generic;
using System.IO;
using System.Web;

namespace OLESClass
{
    public class Teacher : User
    {
        public List<Test> Tests { get; set; }
        public List<Category> Categories { get; set; }
        public List<Result> PreviousResults { get; set; }
        public Lobby CreateLobby(Test test, int QuestionCount)
        {
            return new Lobby
            {
                Name = "123456",
                Test = test,
                LobbyOwner = _id,
                QuestionPoolCount = QuestionCount
            };//todo give a random name
        }

        public Teacher()
        {
            Tests = new List<Test>();
            Categories = new List<Category>();
            PreviousResults = new List<Result>();
        }
    }
}