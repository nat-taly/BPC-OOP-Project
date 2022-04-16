using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using WebAppDatabase.Data;
using WebAppDatabase.Models;

namespace WebAppDatabase.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        /*
        private readonly IConfiguration _configuration;
        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT i.ItemName, i.Count, i.Value, u.UnitName, t.TypeName  FROM Item i
                JOIN Unit u
                ON u.Id = i.UnitID
                JOIN ItemType t
                ON t.Id = i.TypeID;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(MySqlCommand myCommand = new MySqlCommand (query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = string.Format( @"SELECT i.ItemName, i.Count, i.Value, u.UnitName, t.TypeName  FROM Item i
                JOIN Unit u
                ON u.Id = i.UnitID
                JOIN ItemType t
                ON t.Id = i.TypeID
                WHERE i.Id={0};", id);

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DBConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        
        [HttpPost]
        public JsonResult Post(Item item, ItemType itemtype, Unit unit)
        {
            
            string query = string.Format(@"INSERT INTO Item(ItemName, Count, Value, Comment, TypeID, UnitID) 
            VALUES ({0}, {1}, {2}, {3}, 
            (SELECT Id FROM ItemType WHERE TypeName={4}), 
            (SELECT Id FROM Unit WHERE UnitName={5}));", 
            item.ItemName, item.Count, item.Value, item.Comment, itemtype.TypeName, unit.UnitName);
            

       

            MySqlDataReader myReader;
            string sqlDataSource = _configuration.GetConnectionString("DBConnection");
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    
                    myCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                    myCommand.Parameters.AddWithValue("@Count", item.Count);
                    myCommand.Parameters.AddWithValue("@Value", item.Value);
                    myCommand.Parameters.AddWithValue("@Comment", item.Comment);
                    myCommand.Parameters.AddWithValue("@TypeName", itemtype.TypeName);
                    myCommand.Parameters.AddWithValue("@UnitName", unit.UnitName);
                    

                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added succesfully");
        }
        

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = string.Format(@"DELETE FROM Item WHERE Id={0};", id);

         
            string sqlDataSource = _configuration.GetConnectionString("DBConnection");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted succesfuly");
        }

        */



        
        private readonly ApplicationContext _context;

        public ItemsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Items
        // GET ALL ITEMS IN DATABASE
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            return await _context.Item.ToListAsync();
        }

        // GET: api/Items/5
        // GET ITEM WITH ONE SPECIFIC ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // PUT: api/Items/5
        // EDIT EXISTING ITEM WITH ONE ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
        
    }
}
