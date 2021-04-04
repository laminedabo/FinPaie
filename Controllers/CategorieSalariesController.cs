using FinPaie.Data;
using FinPaie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FinPaie.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CategorieSalariesController : Controller
    {
        private readonly CategorieSalarieContext _context;

        public CategorieSalariesController(CategorieSalarieContext context)
        {
            _context = context;
        }

        // GET: CategorieSalaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategorieSalarie.ToListAsync());
        }

        // GET: CategorieSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieSalarie = await _context.CategorieSalarie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieSalarie == null)
            {
                return NotFound();
            }

            return View(categorieSalarie);
        }

        // GET: CategorieSalaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategorieSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Libelle,SalaireDeBase")] CategorieSalarie categorieSalarie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorieSalarie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorieSalarie);
        }

        // GET: CategorieSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieSalarie = await _context.CategorieSalarie.FindAsync(id);
            if (categorieSalarie == null)
            {
                return NotFound();
            }
            return View(categorieSalarie);
        }

        // POST: CategorieSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Libelle,SalaireDeBase")] CategorieSalarie categorieSalarie)
        {
            if (id != categorieSalarie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorieSalarie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieSalarieExists(categorieSalarie.Id))
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
            return View(categorieSalarie);
        }

        // GET: CategorieSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieSalarie = await _context.CategorieSalarie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieSalarie == null)
            {
                return NotFound();
            }

            return View(categorieSalarie);
        }

        // POST: CategorieSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorieSalarie = await _context.CategorieSalarie.FindAsync(id);
            _context.CategorieSalarie.Remove(categorieSalarie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieSalarieExists(int id)
        {
            return _context.CategorieSalarie.Any(e => e.Id == id);
        }
    }
}
