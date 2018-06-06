using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using OLES.Classes.CRUDs;
using OLESClass;

namespace OLES.Classes.Database
{
    public struct DbFactory
    {
        public static async Task<bool> SetConnection(string serverIP)
        {
            var port = "27017";
            if (serverIP.Contains(":"))
            {
                var split = serverIP.Split(':');
                port = split[1];
                serverIP = split[0];
            }

            _client = new MongoClient($"mongodb://{serverIP}:{port}");
            try
            {
                await Database.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
            }
            catch (TimeoutException)
            {
                return false;
            }

            return true;
        }

        //public static IMongoClient Client = new MongoClient("mongodb://mustafarumeli:2dDfShKEX9rbc6e2eHxedLaouu8glHyZE9Ghz5PauBTfBkhpIWhvZuwxsgal1bnhQ2ZIQdIgjxDSrfT6XjS9YA==@mustafarumeli.documents.azure.com:10255/?ssl=true&replicaSet=globaldb");
        private static IMongoClient _client;
        private static IMongoDatabase _database;

        public static IMongoDatabase Database => _database ?? (_database = _client.GetDatabase("OLESDatabase"));

        private static IMongoCollection<BsonDocument> _teacher;
        private static IMongoCollection<BsonDocument> _student;
        private static IMongoCollection<BsonDocument> _test;
        private static IMongoCollection<BsonDocument> _lobby;
        private static IMongoCollection<BsonDocument> _user;


        public static IMongoCollection<BsonDocument> User => _user ??
                                                              (_user = Database.GetCollection<BsonDocument>(typeof(User).Name));
        public static IMongoCollection<BsonDocument> Lobby => _lobby ??
            (_lobby = Database.GetCollection<BsonDocument>(typeof(Lobby).Name));
        public static IMongoCollection<BsonDocument> Test =>
            _test ?? (_test = Database.GetCollection<BsonDocument>(typeof(Test).Name));
        public static IMongoCollection<BsonDocument> Student =>
            _student ?? (_student = Database.GetCollection<BsonDocument>(typeof(User).Name));
        public static IMongoCollection<BsonDocument> Teacher =>
            _teacher ?? (_teacher = Database.GetCollection<BsonDocument>(typeof(User).Name));


        private static UserCRUD _userCRUD;
        private static TeacherCRUD _teacherCRUD;
        private static StudentCRUD _studentCRUD;
        public static TeacherCRUD TeacherCRUD => _teacherCRUD ?? (_teacherCRUD = new TeacherCRUD());
        public static StudentCRUD StudentCRUD => _studentCRUD ?? (_studentCRUD = new StudentCRUD());
        public static UserCRUD UserCRUD => _userCRUD ?? (_userCRUD = new UserCRUD());

        public static dynamic GetCRUD(Type type)
        {
            return typeof(DbFactory).GetProperty(type.Name + "CRUD")?.GetValue(null) ?? typeof(DbFactory.GenericFactory).GetProperty(type.Name + "GenericCRUD").GetValue(null);
        }


        public struct GenericFactory
        {
            private static CRUD<Teacher> _teacherGenericCRUD;
            private static CRUD<Student> _studentGenericCRUD;
            private static CRUD<Test> _testGenericCRUD;
            private static CRUD<Lobby> _lobbyGenericCRUD;

            public static CRUD<Lobby> LobbyGenericCRUD =>
                _lobbyGenericCRUD ?? (_lobbyGenericCRUD = new CRUD<Lobby>());
            public static CRUD<Test> TestGenericCRUD =>
                _testGenericCRUD ?? (_testGenericCRUD = new CRUD<Test>());
            public static CRUD<Student> StudentGenericCRUD =>
                _studentGenericCRUD ?? (_studentGenericCRUD = new CRUD<Student>());
            public static CRUD<Teacher> TeacherGenericCRUD =>
                _teacherGenericCRUD ?? (_teacherGenericCRUD = new CRUD<Teacher>(DbFactory.Teacher));

        }
    }
}
