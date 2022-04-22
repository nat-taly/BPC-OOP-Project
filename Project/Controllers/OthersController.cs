using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class OthersController : Controller
    {
        private readonly ProjectContext _context;

        public OthersController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Others
        public async Task<IActionResult> Index()
        {
            return View(await _context.Others.ToListAsync());
        }

        // GET: Others/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var others = await _context.Others
                .FirstOrDefaultAsync(m => m.Id == id);
            if (others == null)
            {
                return NotFound();
            }

            return View(others);
        }

        // GET: Others/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Others/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Quantity,Price")] Others others)
        {
            if (ModelState.IsValid)
            {
                _context.Add(others);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(others);
        }

        // GET: Others/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var others = await _context.Others.FindAsync(id);
            if (others == null)
            {
                return NotFound();
            }
            return View(others);
        }

        // POST: Others/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Quantity,Price")] Others others)
        {
            if (id != others.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(others);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OthersExists(others.Id))
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
            return View(others);
        }

        // GET: Others/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var others = await _context.Others
                .FirstOrDefaultAsync(m => m.Id == id);
            if (others == null)
            {
                return NotFound();
            }

            return View(others);
        }

        // POST: Others/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var others = await _context.Others.FindAsync(id);
            _context.Others.Remove(others);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OthersExists(int id)
        {
            return _context.Others.Any(e => e.Id == id);
        }
    }
}
