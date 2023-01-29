using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.net_core_CRUD.Data;

namespace Asp.net_core_CRUD.Models
{
    public class booksController : Controller
    {
        private readonly Aspnet_core_CRUDContext _context;

        public booksController(Aspnet_core_CRUDContext context)
        {
            _context = context;
        }

        // GET: books
        public async Task<IActionResult> Index()
        {
              return _context.books != null ? 
                          View(await _context.books.ToListAsync()) :
                          Problem("Entity set 'Aspnet_core_CRUDContext.books'  is null.");
        }

        // GET: books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Language,Author,PublishDate,AvailableCopies")] books books)
        {
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }

        // GET: books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var books = await _context.books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Language,Author,PublishDate,AvailableCopies")] books books)
        {
            if (id != books.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!booksExists(books.ID))
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
            return View(books);
        }

        // GET: books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var books = await _context.books
                .FirstOrDefaultAsync(m => m.ID == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.books == null)
            {
                return Problem("Entity set 'Aspnet_core_CRUDContext.books'  is null.");
            }
            var books = await _context.books.FindAsync(id);
            if (books != null)
            {
                _context.books.Remove(books);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool booksExists(int id)
        {
          return (_context.books?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
