using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        public int NoUnits { get; set; }
        public decimal Price { get; set; }
        [Range(0,2, ErrorMessage = "Invalid Status")]
        public reOrderLevel OrderLevel { get; set; }
    }
}