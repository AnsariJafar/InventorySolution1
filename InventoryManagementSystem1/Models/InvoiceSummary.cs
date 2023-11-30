using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem1.Models
{
    public class InvoiceSummary
    {
        public InvoiceSummary()
        {
            this.EntryDate = DateTime.Now;
        }
        [Key]
        public int EntryID { get; set; }
        [Required]

        public int SupplierId { get; set; }

        [Required]
        public string PurchaseOrderNumber { get; set; }
        [DataType(DataType.Date)]
        [Required]

        public DateTime EntryDate { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime InvoiceDate { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal AmountInGST { get; set; }
        [Required]
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]

        public string Notes { get; set; }
    }
}