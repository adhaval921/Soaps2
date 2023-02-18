using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSoaps.Models;
using Soaps.Data;

namespace Soaps.Controllers
{
    public class SoapsController : Controller
    {
        private readonly SoapsContext _context;

        public SoapsController(SoapsContext context)
        {
            _context = context;
        }

        // GET: Soaps
        public async Task<IActionResult> Index(string soapType, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.soap
                                            orderby m.Type
                                            select m.Type;

            var soapS = from m in _context.soap
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                soapS = soapS.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(soapType))
            {
                soapS = soapS.Where(x => x.Type == soapType);
            }

            var soapTypeVM = new SoapTypeViewModel
            {
                Type = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Soaps = await soapS.ToListAsync()
            };

            return View(soapTypeVM);
        }

        // GET: Soaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soap = await _context.soap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soap == null)
            {
                return NotFound();
            }

            return View(soap);
        }

        // GET: Soaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Company,ReleaseDate,Type,Colour,Price,Rating")] soap soap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soap);
        }

        // GET: Soaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soap = await _context.soap.FindAsync(id);
            if (soap == null)
            {
                return NotFound();
            }
            return View(soap);
        }

        // POST: Soaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Company,ReleaseDate,Type,Colour,Price,Rating")] soap soap)
        {
            if (id != soap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!soapExists(soap.Id))
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
            return View(soap);
        }

        // GET: Soaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soap = await _context.soap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soap == null)
            {
                return NotFound();
            }

            return View(soap);
        }

        // POST: Soaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soap = await _context.soap.FindAsync(id);
            _context.soap.Remove(soap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool soapExists(int id)
        {
            return _context.soap.Any(e => e.Id == id);
        }
    }
}
