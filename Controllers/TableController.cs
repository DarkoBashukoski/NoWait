using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoWait.Data;

namespace NoWait.Controllers {
    public class TableController : Controller {
        private readonly NoWaitContext _context;

        public TableController(NoWaitContext context) {
            _context = context;
        }

        // GET: Table
        public async Task<IActionResult> Index() {
            return _context.Tables != null
                ? View(await _context.Tables.ToListAsync())
                : Problem("Entity set 'NoWaitContext.Tables'  is null.");
        }

        // POST: Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Tables == null) {
                return Problem("Entity set 'NoWaitContext.Tables'  is null.");
            }

            var table = await _context.Tables.FindAsync(id);
            if (table != null) {
                _context.Tables.Remove(table);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableExists(int id) {
            return (_context.Tables?.Any(e => e.TableId == id)).GetValueOrDefault();
        }
    }
}