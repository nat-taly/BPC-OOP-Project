using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly WebAppContext _context;

        public ItemsController(WebAppContext context)
        {
            _context = context;
        }

        // GET: Items
        
        public async Task<IActionResult> Index(int pageNumber=1)
        {
            var webAppContext = _context.Item.Include(i => i.Type).Include(i => i.Unit);
            return View(await PaginatedList<Item>.CreateAsync(_context.Item.Include(i => i.Type).Include(i => i.Unit), pageNumber, 10));
            //return View(await webAppContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Type)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {

            ViewData["TypeID"] = new SelectList(_context.Type, "Id", "TypeName");
            ViewData["UnitID"] = new SelectList(_context.Unit, "Id", "UnitName");


            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,Count,Value,Comment,TypeID,UnitID")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeID"] = new SelectList(_context.Type, "Id", "TypeName", item.TypeID);
            ViewData["UnitID"] = new SelectList(_context.Unit, "Id", "UnitName", item.UnitID);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["TypeID"] = new SelectList(_context.Type, "Id", "TypeName", item.TypeID);
            ViewData["UnitID"] = new SelectList(_context.Unit, "Id", "UnitName", item.UnitID);
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,Count,Value,Comment,TypeID,UnitID")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeID"] = new SelectList(_context.Type, "Id", "TypeName", item.TypeID);
            ViewData["UnitID"] = new SelectList(_context.Unit, "Id", "UnitName", item.UnitID);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Type)
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}
