using System.ComponentModel.DataAnnotations;

namespace OLESClass
{
    public class Category : DbObject
    {
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please enter a name for category")]
        [MinLength(2,ErrorMessage = "Please enter minimum of 2 characters")]
        [MaxLength(25,ErrorMessage ="You are only allowed to enter up to 25 characters")]
        public string Name { get; set; }
    }
}