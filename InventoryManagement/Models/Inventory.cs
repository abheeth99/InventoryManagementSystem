using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int noUnits { get; set; }
        public int price { get; set; }
        public reOrderLevel orderLevel { get; set; }
    }
}