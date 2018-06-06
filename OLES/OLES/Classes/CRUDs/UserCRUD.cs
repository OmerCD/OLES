using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using OLESClass;

namespace OLES.Classes.CRUDs
{
    public class UserCRUD : CRUD<User>
    {
        public User CheckLogin(string userName, string password)
        {
            var filter = new BsonDocument { { "UserName", userName }, { "Password", password } };
            return GetOne(filter);
        }
    }
}