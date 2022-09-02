using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteSinqia.Models;

namespace TesteSinqia.Controllers
{
    public class PontoTuristicoModelsController : Controller
    {
        private readonly Context _context;

        public PontoTuristicoModelsController(Context context)
        {
            _context = context;
        }

        // GET: PontoTuristicoModels
        public async Task<IActionResult> Index()
        {
              return _context.PontoTuristicoModels != null ? 
                          View(await _context.PontoTuristicoModels.ToListAsync()) :
                          Problem("Entity set 'Context.PontoTuristicoModels'  is null.");
        }

        // GET: PontoTuristicoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PontoTuristicoModels == null)
            {
                return NotFound();
            }

            var pontoTuristicoModel = await _context.PontoTuristicoModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristicoModel == null)
            {
                return NotFound();
            }

            return View(pontoTuristicoModel);
        }

        // GET: PontoTuristicoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PontoTuristicoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Localizacao")] PontoTuristicoModel pontoTuristicoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoTuristicoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pontoTuristicoModel);
        }

        // GET: PontoTuristicoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PontoTuristicoModels == null)
            {
                return NotFound();
            }

            var pontoTuristicoModel = await _context.PontoTuristicoModels.FindAsync(id);
            if (pontoTuristicoModel == null)
            {
                return NotFound();
            }
            return View(pontoTuristicoModel);
        }

        // POST: PontoTuristicoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Localizacao")] PontoTuristicoModel pontoTuristicoModel)
        {
            if (id != pontoTuristicoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoTuristicoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoTuristicoModelExists(pontoTuristicoModel.Id))
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
            return View(pontoTuristicoModel);
        }

        // GET: PontoTuristicoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PontoTuristicoModels == null)
            {
                return NotFound();
            }

            var pontoTuristicoModel = await _context.PontoTuristicoModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristicoModel == null)
            {
                return NotFound();
            }

            return View(pontoTuristicoModel);
        }

        // POST: PontoTuristicoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PontoTuristicoModels == null)
            {
                return Problem("Entity set 'Context.PontoTuristicoModels'  is null.");
            }
            var pontoTuristicoModel = await _context.PontoTuristicoModels.FindAsync(id);
            if (pontoTuristicoModel != null)
            {
                _context.PontoTuristicoModels.Remove(pontoTuristicoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoTuristicoModelExists(int id)
        {
          return (_context.PontoTuristicoModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
