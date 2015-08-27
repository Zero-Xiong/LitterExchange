using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Resource;

namespace Zero.Model
{
    public class Item : EntityBase<Guid, DateTime>
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "ItemTitle_NoEmpty", ErrorMessageResourceType = typeof(Message))]
        [StringLength(50, ErrorMessageResourceName = "ItemTitle_LengthWrong", ErrorMessageResourceType = typeof(Message), MinimumLength = 1)]
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
