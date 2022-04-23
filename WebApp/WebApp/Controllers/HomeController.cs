using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAppContext _context;

        public HomeController(WebAppContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Statistics()
        {
            Statistics statistics = new Statistics();
            statistics.Items = await _context.Item.ToListAsync();
            statistics.Types = await _context.Type.ToListAsync();

            return View(statistics);
        }


        public async Task<IActionResult> Search(string searchString)
        {
            //var webAppContext = _context.Item.Include(i => i.Type).Include(i => i.Unit);
            var webAppContext = from m in _context.Item.Include(i => i.Type).Include(i => i.Unit) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                webAppContext = webAppContext.Where(s => s.Type.TypeName!.Contains(searchString));
            }
            return View(await webAppContext.ToListAsync());
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
