using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using day11.Models;

namespace day11.Controllers
{
    public class PhnEmployeesController : Controller
    {
        private readonly PhamHoangNam2301900074Context _context;

        public PhnEmployeesController(PhamHoangNam2301900074Context context)
        {
            _context = context;
        }

        // GET: PhnEmployees
        public async Task<IActionResult> PhnIndex()
        {
            return View(await _context.PhnEmployees.ToListAsync());
        }

        // GET: PhnEmployees/Details/5
        public async Task<IActionResult> PhnDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phnEmployee = await _context.PhnEmployees
                .FirstOrDefaultAsync(m => m.PhnEmpId == id);
            if (phnEmployee == null)
            {
                return NotFound();
            }

            return View(phnEmployee);
        }

        // GET: PhnEmployees/Create
        public IActionResult PhnCreate()
        {
            return View();
        }

        // POST: PhnEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PhnCreate([Bind("PhnEmpId,PhnEmpName,PhnEmpLevel,PhnEmpStartDate,PhnEmpStatus")] PhnEmployee phnEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phnEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phnEmployee);
        }

        // GET: PhnEmployees/Edit/5
        public async Task<IActionResult> PhnEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phnEmployee = await _context.PhnEmployees.FindAsync(id);
            if (phnEmployee == null)
            {
                return NotFound();
            }
            return View(phnEmployee);
        }

        // POST: PhnEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PhnEdit(int id, [Bind("PhnEmpId,PhnEmpName,PhnEmpLevel,PhnEmpStartDate,PhnEmpStatus")] PhnEmployee phnEmployee)
        {
            if (id != phnEmployee.PhnEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phnEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhnEmployeeExists(phnEmployee.PhnEmpId))
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
            return View(phnEmployee);
        }

        // GET: PhnEmployees/Delete/5
        public async Task<IActionResult> PhnDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phnEmployee = await _context.PhnEmployees
                .FirstOrDefaultAsync(m => m.PhnEmpId == id);
            if (phnEmployee == null)
            {
                return NotFound();
            }

            return View(phnEmployee);
        }

        // POST: PhnEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phnEmployee = await _context.PhnEmployees.FindAsync(id);
            if (phnEmployee != null)
            {
                _context.PhnEmployees.Remove(phnEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhnEmployeeExists(int id)
        {
            return _context.PhnEmployees.Any(e => e.PhnEmpId == id);
        }
    }
}
