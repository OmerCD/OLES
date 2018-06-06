using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using OLESClass;

namespace OLES.Classes
{
    public class CustomAuth : IPrincipal
    {
        public string Role { get; set; }
        public User User { get; set; }

        public bool IsInRole(string role)
        {
            return role == Role;
        }

        public IIdentity Identity { get; }

        public CustomAuth(User user)
        {
            Identity = new GenericIdentity(user.UserName);
            switch (user)
            {
                case Teacher _:
                    Role = "Lecturer";
                    break;
                case Student _:
                    Role = "Student";
                    break;
            }
            FormsAuthentication.SetAuthCookie(user.UserName,true);
            User = user;
        }
    }
}