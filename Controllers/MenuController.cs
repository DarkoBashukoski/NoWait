using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoWait.Data;
using NoWait.Models;

namespace NoWait.Controllers;

public class MenuController : Controller {
    private readonly NoWaitContext _context;

    public MenuController(NoWaitContext context) {
        _context = context;
    }

    // GET: Menu
    public async Task<IActionResult> Index() {
        return View(await _context.MenuItems.ToListAsync());
    }

    // GET: Menu/Details/5
    public async Task<IActionResult> Details(int? id) {
        if (id == null || _context.MenuItems == null) {
            return NotFound();
        }

        var menuItem = await _context.MenuItems
            .FirstOrDefaultAsync(m => m.MenuItemID == id);
        if (menuItem == null) {
            return NotFound();
        }

        return View(menuItem);
    }

    // GET: Menu/Create
    public IActionResult Create() {
        return View();
    }

    // POST: Menu/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult>
        Create([Bind("MenuItemID,Name,Description,Price,foodCategory")] MenuItem menuItem) {
        if (ModelState.IsValid) {
            _context.Add(menuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(menuItem);
    }

    // GET: Menu/Edit/5
    public async Task<IActionResult> Edit(int? id) {
        if (id == null || _context.MenuItems == null) {
            return NotFound();
        }

        var menuItem = await _context.MenuItems.FindAsync(id);
        if (menuItem == null) {
            return NotFound();
        }

        return View(menuItem);
    }

    // POST: Menu/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("MenuItemID,Name,Description,Price,foodCategory")] MenuItem menuItem) {
        if (id != menuItem.MenuItemID) {
            return NotFound();
        }

        if (ModelState.IsValid) {
            try {
                _context.Update(menuItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!MenuItemExists(menuItem.MenuItemID)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(menuItem);
    }

    // GET: Menu/Delete/5
    public async Task<IActionResult> Delete(int? id) {
        if (id == null || _context.MenuItems == null) {
            return NotFound();
        }

        var menuItem = await _context.MenuItems
            .FirstOrDefaultAsync(m => m.MenuItemID == id);
        if (menuItem == null) {
            return NotFound();
        }

        return View(menuItem);
    }

    // POST: Menu/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        if (_context.MenuItems == null) {
            return Problem("Entity set 'NoWaitContext.MenuItems'  is null.");
        }

        var menuItem = await _context.MenuItems.FindAsync(id);
        if (menuItem != null) {
            _context.MenuItems.Remove(menuItem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MenuItemExists(int id) {
        return (_context.MenuItems?.Any(e => e.MenuItemID == id)).GetValueOrDefault();
    }
}