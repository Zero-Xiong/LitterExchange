using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Model;

namespace Zero.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public CategoryList Category { get; set; }

        public IList<Item> Items { get; set; }
    }
}
