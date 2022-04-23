using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Statistics
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Type> Types { get; set; }
    }
}
