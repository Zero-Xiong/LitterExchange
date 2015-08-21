using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Zero.Resource;

namespace Zero.Model
{
    public class Category : EntityBase
    {
        [Required(AllowEmptyStrings =false, ErrorMessageResourceName = "CategoryName_NoEmpty", ErrorMessageResourceType = typeof(Message)) ]
        [DisplayName("Category Name")]
        [StringLength(50, ErrorMessageResourceName = "CategoryName_LengthWrong", ErrorMessageResourceType = typeof(Message), MinimumLength = 1)]
        public string CategoryName { get; set; }

        [DisplayName("Category Description")]
        public string CategoryDescription { get; set; }

        [DisplayName("Validate")]
        public bool IsEnabled { get; set; }
    }
}
