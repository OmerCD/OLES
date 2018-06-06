using System.Collections.Generic;

namespace OLESClass
{
    public class Teacher : User
    {
        public List<Test> Tests { get; set; }
        public List<Category> Categories { get; set; }
        public List<Result> PreviousResults { get; set; }
        public Lobby CreateLobby(string lobbyName, Test test)
        {
            return new Lobby { Name = lobbyName, Test = test };
        }
    }
}