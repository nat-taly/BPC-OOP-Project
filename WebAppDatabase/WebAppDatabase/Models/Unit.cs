using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDatabase.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string UnitName { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
