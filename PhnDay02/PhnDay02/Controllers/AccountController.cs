using Microsoft.AspNetCore.Mvc;
using YourProjectName.Models;
using System.Collections.Generic;
using System.Linq;

namespace YourProjectName.Controllers
{
    public class AccountController : Controller
    {
        private List<AccountViewModel> GetAccounts()
        {
            return new List<AccountViewModel>
            {
                new AccountViewModel { Id = 1, Name = "Nguyễn Văn A", Description = "Thành viên tích cực", AvatarPath = "~/Avatar/p1.png" },
                new AccountViewModel { Id = 2, Name = "Trần Thị B", Description = "Quản trị viên", AvatarPath = "~/Avatar/p2.png" },
                new AccountViewModel { Id = 3, Name = "Lê Văn C", Description = "Khách mới", AvatarPath = "~/Avatar/p3.png" }
            };
        }

        public IActionResult Index()
        {
            var accounts = GetAccounts();
            return View(accounts);
        }

        public IActionResult Profile(int id)
        {
            var account = GetAccounts().FirstOrDefault(a => a.Id == id);
            if (account == null)
                return NotFound();

            return View(account);
        }
    }
}

