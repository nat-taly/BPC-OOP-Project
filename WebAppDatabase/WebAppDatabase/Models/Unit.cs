using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDatabase.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
