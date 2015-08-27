using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Model;

namespace Zero.Web.Core.ViewModels
{
    public class CategoryList
    {
        public string ActivedCategoryId { get; set; }

        public IList<Category> Categories { get; set; }
    }
}
