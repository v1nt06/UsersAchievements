using System;
using System.Linq;
using System.Web.Mvc;
using UsersAchievements.Models;

namespace UsersAchievements.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View(UsersRepository.Instance.Users);
        }

        // GET: Users/Remove
        public ActionResult Remove(Guid id)
        {
            var users = UsersRepository.Instance.Users;
            users.Remove(users.Single(u => u.Id == id));
            return RedirectToAction("Index");
        }

        // GET: Users/Add
        public ActionResult Add(string name, DateTime? birthdate)
        {
            UsersRepository.Instance.Users.Add(new User(name, birthdate));
            return RedirectToAction("Index");
        }
    }
}