using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersAchievements.Models;

namespace UsersAchievements.Controllers
{
    public class AchievementsController : Controller
    {
        private List<Achievement> Achievements => AchievementsRepository.Instance.Achievements;

        // GET: Achievements
        public ActionResult Index()
        {
            return View(Achievements);
        }

        // GET: Achievements/Remove
        public ActionResult Remove(Guid id)
        {
            Achievements.Remove(Achievements.Single(a => a.Id == id));
            return RedirectToAction("Index");
        }

        //GET: Achievements/Add
        public ActionResult Add(string title, string description)
        {
            Achievements.Add(new Achievement(title) { Description = description });
            return RedirectToAction("Index");
        }

        //GET: Achievements/Edit
        public ActionResult Edit(Guid id)
        {
            return View(Achievements.Single(a => a.Id == id));
        }

        //POST: Achievements/SaveChanges
        public ActionResult SaveChanges(Guid id, string title, string description, HttpPostedFileBase image, string deleteImage)
        {
            var achievement = Achievements.Single(a => a.Id == id);

            if (image != null)
            {
                achievement.Image = achievement.Id + ".png";
                using (var fileStream =
                    System.IO.File.Create("D:\\Projects\\UsersAchievements\\UsersAchievements\\Content\\Photos\\" +
                                          achievement.Id + ".png"))
                {
                    image.InputStream.Seek(0, SeekOrigin.Begin);
                    image.InputStream.CopyTo(fileStream);
                }
            }

            if (!string.IsNullOrEmpty(deleteImage) && deleteImage == "on")
            {
                achievement.Image = null;
            }

            achievement.Title = title;
            achievement.Description = description;
            return RedirectToAction("Index");
        }
    }
}