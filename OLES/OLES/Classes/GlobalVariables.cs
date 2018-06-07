using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OLESClass;

namespace OLES.Classes
{
    public static class GlobalVariables
    {
        public static Queue<Question> CurrentQuestions { get; set; }
        public static Test CurrentTest = new Test();
        public static Dictionary<string, string> UserIdLobbyNameDictionary = new Dictionary<string, string>();
        public static Lobby CurrentLobby = null;

    }
}