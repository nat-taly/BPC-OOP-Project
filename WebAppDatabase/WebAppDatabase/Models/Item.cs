using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDatabase.Models
{
    
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string ItemName { get; set; }
        public int Count { get; set; }

        [MaxLength(10)]
        public string Value { get; set; }

        [MaxLength(100)]
        public string Comment { get; set; }
        
        public int TypeID { get; }
        public int UnitID { get; }
        
        public ItemType ItemType { get; set; }
        public Unit Unit { get; set; }

        public Item()
        {

        }





    }
}
