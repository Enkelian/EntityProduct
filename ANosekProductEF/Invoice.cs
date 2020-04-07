using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ANosekProductEF
{
    class Invoice
    {
        [Key]
        public int InvoiceNumber { get; set; }
        public int Quantity { get; set; }
        public List<ProductInvoice> ProductInvoices { get; set; }
    }
}
