using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoccerMatch_TF.Models;

namespace SoccerMatch_TF.Controllers
{
    public class CallesController : Controller
    {
         AplicacionDbContext _context = new AplicacionDbContext();

       

        // GET: Calles
        //public async Task<IActionResult> Index()
        //{
        //    var aplicacionDbContext = _context.Calle.Include(c => c.CdistritoNavigation);
        //    return View(await aplicacionDbContext.ToListAsync());
        //}


        public IActionResult Index()
        {
            var data = _context.Calle;
            return View(data);
        }

        // GET: Calles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calle = await _context.Calle
                .Include(c => c.CdistritoNavigation)
                .FirstOrDefaultAsync(m => m.Ccalle == id);
            if (calle == null)
            {
                return NotFound();
            }

            return View(calle);
        }

        // GET: Calles/Create
        public IActionResult Create()
        {
            ViewData["Cdistrito"] = new SelectList(_context.Distrito, "Cdistrito", "Ndistrito");
            return View();
        }

        // POST: Calles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ccalle,Ncalle,Cdistrito")] Calle calle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cdistrito"] = new SelectList(_context.Distrito, "Cdistrito", "Ndistrito", calle.Cdistrito);
            return View(calle);
        }

        // GET: Calles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calle = await _context.Calle.FindAsync(id);
            if (calle == null)
            {
                return NotFound();
            }
            ViewData["Cdistrito"] = new SelectList(_context.Distrito, "Cdistrito", "Ndistrito", calle.Cdistrito);
            return View(calle);
        }

        // POST: Calles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ccalle,Ncalle,Cdistrito")] Calle calle)
        {
            if (id != calle.Ccalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalleExists(calle.Ccalle))
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
            ViewData["Cdistrito"] = new SelectList(_context.Distrito, "Cdistrito", "Ndistrito", calle.Cdistrito);
            return View(calle);
        }

        // GET: Calles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calle = await _context.Calle
                .Include(c => c.CdistritoNavigation)
                .FirstOrDefaultAsync(m => m.Ccalle == id);
            if (calle == null)
            {
                return NotFound();
            }

            return View(calle);
        }

        // POST: Calles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calle = await _context.Calle.FindAsync(id);
            _context.Calle.Remove(calle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalleExists(int id)
        {
            return _context.Calle.Any(e => e.Ccalle == id);
        }
    }
}
