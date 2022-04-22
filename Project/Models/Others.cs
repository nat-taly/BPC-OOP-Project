using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Others
    {
        public int Id { get; set; }
        public string? Name { get; set; }

       
        public string? Type { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
