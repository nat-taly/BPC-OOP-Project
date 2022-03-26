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
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Count { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }

       
        public int TypeID { get; set; }
        public ItemsType ItemsType { get; set; }
        public int UnitID { get; set; }
        public Unit Unit { get; set; }

        /*
        [ForeignKey("TypeID")]
        [NotMapped]
        public virtual string TypeName { get; set; }
        //public string TypeID { get; set; }

        [ForeignKey("UnitName")]
        public string UnitID { get; set; }
        */

        /*
        public Item(int Id, string ItemName, int Count, string Value, string Comment, string ItemType, string Unit)
        {
            this.Id = Id;
            this.ItemName = ItemName;
            this.Count = Count;
            this.Comment = Comment;
            this.Value = Value;
            this.Unit = Unit;
            this.ItemType = ItemType;
        }
        */
    }
}
