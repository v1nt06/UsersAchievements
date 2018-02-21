using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UsersAchievements.Helpers;
using UsersAchievements.Models;
using IOFile = System.IO.File;

namespace UsersAchievements.Controllers
{
    public class UsersController : Controller
    {
        private List<User> Users => UsersRepository.Instance.Users;

        // GET: Users
        public ActionResult Index()
        {
            return View(Users);
        }

        // GET: Users/Delete
        public ActionResult Delete(Guid id)
        {
            Users.Remove(Users.Single(u => u.Id == id));
            return RedirectToAction("Index");
        }


        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Users/Edit
        public ActionResult Edit(Guid id)
        {
            return View(Users.Single(u => u.Id == id));
        }

        // GET: Users/GetUsersList
        public ActionResult GetUsersList()
        {
            var usersString = "";
            foreach (var user in Users)
            {
                usersString += user + Environment.NewLine;
            }

            return File(Encoding.UTF8.GetBytes(usersString), "application/octet-stream", "users_list.txt");
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(UserModelBinder))]User model)
        {
            ModelState.Clear();
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                Users.Add(model);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        // POST: Users/SaveChanges
        public ActionResult SaveChanges(Guid id, string name, DateTime? birthdate, HttpPostedFileBase photo, string deletePhoto)
        {
            var user = Users.Single(u => u.Id == id);
            user.Name = name;
            user.SetBirthdate(birthdate);
            if (photo != null)
            {
                user.Photo = user.Id + ".png";
                using (var stream = IOFile.Create(HttpContext.Server.MapPath($"~/Content/Photos/{user.Id}.png")))
                {
                    photo.InputStream.Seek(0, SeekOrigin.Begin);
                    photo.InputStream.CopyTo(stream);
                }
            }

            if (!string.IsNullOrEmpty(deletePhoto) && deletePhoto == "on")
            {
                user.Photo = null;
            }

            return RedirectToAction("Index");
        }
    }
}
