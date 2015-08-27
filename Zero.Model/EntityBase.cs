using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Model
{
    public abstract class EntityBase<TId, TDateCreated>
    {
        [Key]
        [ScaffoldColumn(false)]
        public TId Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Created")]
        public TDateCreated DateCreated { get; set; }
    }
}
