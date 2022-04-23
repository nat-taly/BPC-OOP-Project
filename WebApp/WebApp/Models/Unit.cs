using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string UnitName { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
