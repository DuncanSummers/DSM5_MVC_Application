using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM5.Models
{
    public class CategoryListItem
    {
        public int CategoryID
        {
            get; set;
        }
        public string CategoryName
        {
            get; set;
        }
        public string[] Subcategories
        {
            get; set;
        }
     }
}
