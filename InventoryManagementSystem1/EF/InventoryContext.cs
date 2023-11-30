using InventoryManagementSystem1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem1.EF
{
    public class InventoryContext : DbContext
    {
        public InventoryContext():base("ConnSt")
        {

        }

        public DbSet<InvoiceSummary> InvoiceSummarys { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}