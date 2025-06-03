using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhnDay07.Models;

namespace PhnDay07.Controllers
{
    public class PhnEmployeeController : Controller
    {
        // Mock Data:
        private static List<PhnEmployee> phnListEmployee = new List<PhnEmployee>()
        {
            new PhnEmployee
            {
                PhnId = 23001122,
                PhnName = "Pham Hoang Nam",
                PhnBirthDay = new DateTime(1979, 5, 25),
                PhnEmail = "ngoisao1432@gmail.com",
                PhnPhone = "0369405630",
                PhnSalary = 1345000m,
                PhnStatus = true
            },
            new PhnEmployee
            {
                PhnId = 2,
                PhnName = "Nguyen Thi Hanh",
                PhnBirthDay = new DateTime(1992, 8, 15),
                PhnEmail = "dkkk@example.com",
                PhnPhone = "0899230003",
                PhnSalary = 13500000m,
                PhnStatus = true
            },
            new PhnEmployee
            {
                PhnId = 3,
                PhnName = "Lê Văn Quang",
                PhnBirthDay = new DateTime(1988, 3, 22),
                PhnEmail = "levanquangg@example.com",
                PhnPhone = "0934560038",
                PhnSalary = 10000000m,
                PhnStatus = false
            },
            new PhnEmployee
            {
                PhnId = 4,
                PhnName = "Phan Trang Dung",
                PhnBirthDay = new DateTime(1995, 11, 5),
                PhnEmail = "phantrangd@example.com",
                PhnPhone = "0976533334",
                PhnSalary = 15000000m,
                PhnStatus = true
            },
            new PhnEmployee
            {
                PhnId = 5,
                PhnName = "Đỗ Văn Quang",
                PhnBirthDay = new DateTime(1991, 7, 18),
                PhnEmail = "dovanq@example.com",
                PhnPhone = "0981122334",
                PhnSalary = 11000000m,
                PhnStatus = false
            }
        };

        // GET: PhnEmployeeController
        public ActionResult PhnIndex()
        {
            return View(phnListEmployee);
        }

        // GET: PhnEmployeeController/PhnDetails/5
        public ActionResult PhnDetails(int id)
        {
            var phnEmployee = phnListEmployee.FirstOrDefault(x => x.PhnId == id);
            return View(phnEmployee);
        }

        // GET: PhnEmployeeController/PhnCreate
        public ActionResult PhnCreate()
        {
            var phnEmployee = new PhnEmployee();
            return View(phnEmployee);
        }

        // POST: PhnEmployeeController/PhnCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhnCreate(PhnEmployee phnModel)
        {
            try
            {
                phnModel.PhnId = phnListEmployee.Max(x => x.PhnId) + 1;
                phnListEmployee.Add(phnModel);
                return RedirectToAction(nameof(PhnIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhnEmployeeController/PhnEdit/5
        public ActionResult PhnEdit(int id)
        {
            var phnEmployee = phnListEmployee.FirstOrDefault(x => x.PhnId == id);
            return View(phnEmployee);
        }

        // POST: PhnEmployeeController/PhnEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhnEdit(int id, PhnEmployee phnModel)
        {
            try
            {
                for (int i = 0; i < phnListEmployee.Count(); i++)
                {
                    if (phnListEmployee[i].PhnId == id)
                    {
                        phnListEmployee[i] = phnModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(PhnIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhnEmployeeController/PhnDelete/5
        public ActionResult PhnDelete(int id)
        {
            var employee = phnListEmployee.FirstOrDefault(x => x.PhnId == id);
            return View(employee);
        }

        // POST: PhnEmployeeController/PhnDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhnDelete(int id, IFormCollection collection)
        {
            try
            {
                var employee = phnListEmployee.FirstOrDefault(x => x.PhnId == id);
                if (employee != null)
                {
                    phnListEmployee.Remove(employee);
                }
                return RedirectToAction(nameof(PhnIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
