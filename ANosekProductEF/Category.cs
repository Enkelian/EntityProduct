using System;
using System.Collections.Generic;
using System.Text;

namespace ANosekProductEF
{
    class Category
    {
        public int CategoryID { get; set; }
        public String Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
