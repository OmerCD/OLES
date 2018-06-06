using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace OLESClass
{
    public class StudentCRUD: CRUD<Student>
    {
        public override bool Insert(Student entity)
        {
            var filter = new BsonDocument{{"UserName",entity.UserName}};
            if (GetOne(filter)==null)
            {
                return base.Insert(entity);
            }
            return false;
        }
    }
}
