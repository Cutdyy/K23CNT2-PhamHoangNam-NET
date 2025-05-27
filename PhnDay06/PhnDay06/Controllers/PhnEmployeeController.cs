using Microsoft.AspNetCore.Mvc;
using PhnLab06.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PhnLab06.Controllers
{
    public class PhnEmployeeController : Controller
    {
        private static List<PhnEmployee> phnListEmployee = new List<PhnEmployee>
        {
            new PhnEmployee { PhnId = 1, PhnName = "Phan Minh", PhnBirthDay = new DateTime(2002, 1, 10), PhnEmail = "minh@example.com", PhnPhone = "0123456789", PhnSalary = 5000, PhnStatus = "Sinh viên" },
            new PhnEmployee { PhnId = 2, PhnName = "Nguyen An", PhnBirthDay = new DateTime(2000, 5, 20), PhnEmail = "an@example.com", PhnPhone = "0987654321", PhnSalary = 8000, PhnStatus = "Nhân viên" },
            new PhnEmployee { PhnId = 3, PhnName = "Le Bao", PhnBirthDay = new DateTime(1999, 12, 15), PhnEmail = "bao@example.com", PhnPhone = "0934567890", PhnSalary = 9500, PhnStatus = "Nhân viên" },
            new PhnEmployee { PhnId = 4, PhnName = "Tran Ha", PhnBirthDay = new DateTime(1998, 3, 2), PhnEmail = "ha@example.com", PhnPhone = "0912345678", PhnSalary = 7000, PhnStatus = "Nhân viên" },
            new PhnEmployee { PhnId = 5, PhnName = "Vo Long", PhnBirthDay = new DateTime(2001, 7, 25), PhnEmail = "long@example.com", PhnPhone = "0909090909", PhnSalary = 6000, PhnStatus = "Nhân viên" }
        };

        public IActionResult PhnIndex()
        {
            return View(phnListEmployee);
        }

        [HttpGet]
        public IActionResult PhnCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PhnCreate(PhnEmployee employee)
        {
            if (ModelState.IsValid)
            {
                employee.PhnId = phnListEmployee.Any() ? phnListEmployee.Max(e => e.PhnId) + 1 : 1;
                phnListEmployee.Add(employee);
                return RedirectToAction("PhnIndex");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult PhnEdit(int id)
        {
            var employee = phnListEmployee.FirstOrDefault(e => e.PhnId == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PhnEdit(PhnEmployee employee)
        {
            if (ModelState.IsValid)
            {
                var existing = phnListEmployee.FirstOrDefault(e => e.PhnId == employee.PhnId);
                if (existing != null)
                {
                    existing.PhnName = employee.PhnName;
                    existing.PhnBirthDay = employee.PhnBirthDay;
                    existing.PhnEmail = employee.PhnEmail;
                    existing.PhnPhone = employee.PhnPhone;
                    existing.PhnSalary = employee.PhnSalary;
                    existing.PhnStatus = employee.PhnStatus;
                }
                return RedirectToAction("PhnIndex");
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PhnDelete(int id)
        {
            var employee = phnListEmployee.FirstOrDefault(e => e.PhnId == id);
            if (employee != null)
                phnListEmployee.Remove(employee);
            return RedirectToAction("PhnIndex");
        }
    }
}