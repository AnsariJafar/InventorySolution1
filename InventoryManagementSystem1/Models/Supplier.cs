using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem1.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        public string SupplierName { get; set; }
    }
}