using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InventoryManagement.Models
{
    public class InventoryDBContext : DbContext
    {
        public DbSet<Inventory> Inventories{ get; set; }
    }
}