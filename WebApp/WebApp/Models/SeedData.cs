using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebAppContext>>()))
            {
                
                if (context.Item.Any() && context.Unit.Any() && context.Type.Any())
                {
                    return;   // DB has been seeded
                }
                
                Type[] types = { 
                    new Type() { TypeName = "Resistor" },
                    new Type() { TypeName = "Capacitor" },
                    new Type() { TypeName = "Diode" }
                };
                foreach (Type t in types) {
                    if (!context.Type.Any(s => s.TypeName == t.TypeName))
                    {
                        context.Type.Add(t);
                    }
                }
                context.SaveChanges();

                Unit[] units = {
                    new Unit { UnitName = "mF" },
                    new Unit { UnitName = "uF" },
                    new Unit { UnitName = "nF" },
                    new Unit { UnitName = "R" },
                    new Unit { UnitName = "V" }
                };
                foreach (Unit u in units)
                {
                    if (!context.Unit.Any(s => s.UnitName == u.UnitName))
                    {
                        context.Unit.Add(u);
                    }
                }
                context.SaveChanges();
                
                
                int typeID_R = 30;
                int typeID_C = 31;
                int typeID_D = 32;

                int unitID_R = 34;
                int unitID_V = 35;
                int unitID_uF = 32;
                int unitID_nF = 31;

                Item[] items = {
                    new Item { ItemName = "AZ23C4V7-7-F",    Count = 23, Value = "4.7", Comment = "", TypeID = typeID_D, UnitID = unitID_V },
                    new Item { ItemName = "AZ23C3V3-7-F",    Count = 34, Value = "3.3", Comment = "", TypeID = typeID_D, UnitID = unitID_V },
                    new Item { ItemName = "BZB84-B3V3,215",  Count = 48, Value = "3.3", Comment = "", TypeID = typeID_D, UnitID = unitID_V },
                    new Item { ItemName = "BZB984-C12,115",  Count = 91, Value = "12",  Comment = "", TypeID = typeID_D, UnitID = unitID_V },
                    new Item { ItemName = "BZB984-C5V6,115", Count = 23, Value = "5.6", Comment = "", TypeID = typeID_D, UnitID = unitID_V },
                    new Item { ItemName = "BZB984-C15,115",  Count = 34, Value = "15",  Comment = "", TypeID = typeID_D, UnitID = unitID_V },
                    new Item { ItemName = "BZB84-C18,215",   Count = 48, Value = "18",  Comment = "", TypeID = typeID_D, UnitID = unitID_V },
                    new Item { ItemName = "BZB84-C18,215",   Count = 91, Value = "18",  Comment = "", TypeID = typeID_D, UnitID = unitID_V },

                    new Item { ItemName = "1R",   Count = 48, Value = "1.0",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "1R2",  Count = 52, Value = "1.2",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "1R5",  Count = 98, Value = "1.5",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "1R8",  Count = 47, Value = "1.8",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "2R2",  Count = 36, Value = "2.2",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "2R7",  Count = 24, Value = "2.7",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "3R3",  Count = 50, Value = "3.3",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "3R9",  Count = 11, Value = "3.9",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "4R7",  Count = 36, Value = "4.7",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "5R6",  Count = 24, Value = "5.6",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "6R8",  Count = 50, Value = "6.8",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },
                    new Item { ItemName = "8R2",  Count = 11, Value = "8.2",  Comment = "", TypeID = typeID_R, UnitID = unitID_R },

                    new Item { ItemName = "100u",  Count = 48, Value = "100",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "120u",  Count = 52, Value = "120",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "150u",  Count = 98, Value = "150",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "180u",  Count = 47, Value = "180",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "220u",  Count = 36, Value = "220",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "270u",  Count = 24, Value = "270",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "330u",  Count = 50, Value = "330",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "390u",  Count = 11, Value = "390",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "470u",  Count = 36, Value = "470",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "560u",  Count = 24, Value = "560",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "680u",  Count = 50, Value = "680",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                    new Item { ItemName = "820u",  Count = 11, Value = "820",  Comment = "", TypeID = typeID_C, UnitID = unitID_uF },
                   
                    new Item { ItemName = "100n",  Count = 48, Value = "100",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "120n",  Count = 52, Value = "120",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "150n",  Count = 98, Value = "150",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "180n",  Count = 47, Value = "180",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "220n",  Count = 36, Value = "220",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "270n",  Count = 24, Value = "270",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "330n",  Count = 50, Value = "330",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "390n",  Count = 11, Value = "390",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "470n",  Count = 36, Value = "470",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "560n",  Count = 24, Value = "560",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "680n",  Count = 50, Value = "680",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                    new Item { ItemName = "820n",  Count = 11, Value = "820",  Comment = "", TypeID = typeID_C, UnitID = unitID_nF },
                };
                foreach (Item i in items)
                {
                    if (!context.Item.Any(s => s.ItemName == i.ItemName))
                    {
                        context.Item.Add(i);
                    }
                }
                context.SaveChanges();
                
            }
        }
    }
}
