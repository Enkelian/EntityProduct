using System;
using System.Collections.Generic;
using System.Text;

    namespace ANosekProductEF
    {
        class Supplier: Company
        {
        public String BankAccountNumber { get; set; }
        public virtual List<Product> Products { get; set; } //ex III

        }
    }
