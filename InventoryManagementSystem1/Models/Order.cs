using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem1.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int Supplier_ID { get; set; }
        
        [Required]
        public string OrderNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal OrderAmount { get; set; }
    }
}