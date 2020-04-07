using System;
using System.Collections.Generic;
using System.Text;

namespace ANosekProductEF
{
    class ProductInvoice
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int InvoiceNumber { get; set; }
        public Invoice Invoice { get; set; }
    }
}
