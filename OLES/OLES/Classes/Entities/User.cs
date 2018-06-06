using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using OLES.Controllers;
using System.Web;


namespace OLESClass
{
    public enum UserRole
    {
        Lecturer,
        Student
    }
    public class User : DbObject
    {
        [Display(Name = "User Name",Prompt = "User Name")]
        [Required(ErrorMessage = "Please Enter a User Name")]
        [Remote("IsUniqueUserName","Register",ErrorMessage = "This User Name is already taken")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter The Password")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Password should be between 6-25")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter a E-mail Adress")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [Remote("IsUniqueEmail", "Register", ErrorMessage = "This E-mail is already taken")]
        public string EMail { get; set; }
        public UserRole UserRole { get; set; }
        public bool ConfirmLogin(string userName, string password)
        {
            return (string.Equals(userName, UserName, StringComparison.CurrentCultureIgnoreCase) && Password == password);
        }
        /// <summary>
        /// User is automatically assumed to be a student since, lecturer shall be inserted beforehand.
        /// </summary>
        public User()
        {
            UserRole = UserRole.Student;
        }
    }
}