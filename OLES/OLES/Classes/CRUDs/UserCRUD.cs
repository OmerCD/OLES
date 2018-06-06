using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OLES.Classes.Database;
using OLESClass;

namespace OLES.Classes.CRUDs
{
    public class UserCRUD : CRUD<User>
    {
        public User CheckLogin(User user)
        {

            var filter = new BsonDocument { { "UserName", user.UserName }, { "Password", user.Password } };
            var cursor = Table.FindSync(filter);
            cursor.MoveNext();
            var batch = cursor.Current;
            var entity = batch.FirstOrDefault();
            if (entity != null)
            {
                if (entity.TryGetValue("UserRole", out var bson))
                {
                    UserRole role = (UserRole) bson.ToInt32();
                    switch (role)
                    {
                        case UserRole.Lecturer:
                            return BsonSerializer.Deserialize<Teacher>(entity);
                        case UserRole.Student:
                            return BsonSerializer.Deserialize<Student>(entity);
                        default:
                            return null;
                    }
                }
            }

            return null;
        }

        public bool CheckColumn(string column,string value)
        {
            var filter = new BsonDocument{{column, value } };
            var cursor = Table.FindSync(filter);
            cursor.MoveNext();
            var batch = cursor.Current;
            var entity = batch.FirstOrDefault();
            return entity != null;
        }
        public override User GetOne(string userId)
        {
            var filter = new BsonDocument { { "_id", userId } };
            var cursor = Table.FindSync(filter);
            cursor.MoveNext();
            var batch = cursor.Current;
            var entity = batch.FirstOrDefault();
            if (entity != null)
            {
                if (entity.TryGetValue("UserRole", out var bson))
                {
                    UserRole role = (UserRole)bson.ToInt32();
                    switch (role)
                    {
                        case UserRole.Lecturer:
                            return BsonSerializer.Deserialize<Teacher>(entity);
                        case UserRole.Student:
                            return BsonSerializer.Deserialize<Student>(entity);
                        default:
                            return null;
                    }
                }
            }

            return null;
        }
    }
}