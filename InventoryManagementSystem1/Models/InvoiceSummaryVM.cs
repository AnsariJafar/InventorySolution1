using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem1.Models
{
    public class InvoiceSummaryVM
    {
        public int EntryId { get; set; }

        public string EntryDate { get; set; }

        public string InvoiceNumber { get; set; }

        public string InvoiceAmount { get; set; }

        public string InvoiceDate { get; set; }

        public string OrderNumber { get; set; }

        public string SupplierName { get; set; }
    }
}