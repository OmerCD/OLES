using System;

namespace OLESClass
{
    public class User : DbObject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }

        public bool ConfirmLogin(string userName, string password)
        {
            return (string.Equals(userName, UserName, StringComparison.CurrentCultureIgnoreCase) && Password == password);
        }
    }
}