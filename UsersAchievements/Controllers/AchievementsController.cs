using System;
using System.Linq;
using System.Web.Mvc;
using UsersAchievements.Models;

namespace UsersAchievements.Controllers
{
    public class AchievementsController : Controller
    {
        // GET: Achievements
        public ActionResult Index()
        {
            return View(AchievementsRepository.Instance.Achievements);
        }

        // GET: Achievements/Remove
        public ActionResult Remove(Guid id)
        {
            var achievements = AchievementsRepository.Instance.Achievements;
            achievements.Remove(achievements.Single(a => a.Id == id));
            return RedirectToAction("Index");
        }

        //GET: Achievements/Add
        public ActionResult Add(string title, string description)
        {
            AchievementsRepository.Instance.Achievements.Add(new Achievement(title) { Description = description });
            return RedirectToAction("Index");
        }
    }
}