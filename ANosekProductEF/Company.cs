using System;
using System.Collections.Generic;
using System.Text;

namespace ANosekProductEF
{
    abstract class Company
    {
        public int CompanyID { get; set; }
        public String CompanyName { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
    }
}
