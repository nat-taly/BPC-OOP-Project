using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
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

        public int TypeID { get; set; }
        public int UnitID { get; set; }

        public virtual Type Type { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
