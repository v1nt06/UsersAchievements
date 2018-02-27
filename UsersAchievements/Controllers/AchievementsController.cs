using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsersAchievements.Models;
using IOFile = System.IO.File;

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

        // GET: Achievements/Delete
        public ActionResult Delete(Guid id)
        {
            Achievements.Remove(Achievements.Single(a => a.Id == id));
            return RedirectToAction("Index");
        }

        //GET: Achievements/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET: Achievements/Edit
        public ActionResult Edit(Guid id)
        {
            return View(Achievements.Single(a => a.Id == id));
        }

        //POST: Achievements/Create
        [HttpPost]
        public ActionResult Create(Achievement model)
        {
            if (ModelState.IsValid)
            {
                Achievements.Add(model);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        //POST: Achievements/SaveChanges
        public ActionResult SaveChanges(Guid id, string title, string description, HttpPostedFileBase image, string deleteImage)
        {
            var achievement = Achievements.Single(a => a.Id == id);

            if (image != null)
            {
                achievement.Image = achievement.Id + ".png";
                using (var stream = IOFile.Create(HttpContext.Server.MapPath($"~/Content/Photos/{achievement.Id}.png")))
                {
                    image.InputStream.Seek(0, SeekOrigin.Begin);
                    image.InputStream.CopyTo(stream);
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