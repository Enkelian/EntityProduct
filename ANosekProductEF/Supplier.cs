using System;
using System.Collections.Generic;
using System.Text;

namespace ANosekProductEF
{
    class Supplier
    {
        public int SupplierID { get; set; }
        public String CompanyName { get; set; }
        public String Street { get; set; }

        public String City { get; set; }

        public virtual List<Product> Products { get; set; } //ex III

    }
}
