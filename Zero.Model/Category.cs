using System.Collections.Generic;
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
        public string Name { get; set; }

        [DisplayName("Category Description")]
        public string Description { get; set; }

        [DisplayName("Validate")]
        public bool IsEnabled { get; set; }

        [Range(0, 100, ErrorMessageResourceName = "CategorySequence_RangeWrong", ErrorMessageResourceType = typeof(Message))]
        public int Sequence { get; set; }


        public virtual ICollection<Item> Items { get; set; }
    }
}
