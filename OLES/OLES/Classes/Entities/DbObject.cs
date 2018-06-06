using System;
using System.Web.Mvc;

namespace OLESClass
{
    public abstract class DbObject : IDisposable
    {
        // ReSharper disable once InconsistentNaming
        [HiddenInput(DisplayValue = false)]
        public string _id { get; set; }
        public DateTime CreationDate { get; protected set; }
        public byte IsDeleted { get; protected set; }
        protected DbObject()
        {
            _id = Guid.NewGuid().ToString();
            IsDeleted = 0;
            CreationDate = DateTime.Now;
        }
        public void Delete()
        {
            IsDeleted = 1;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
