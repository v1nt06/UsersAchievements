using System;
using System.Web.Mvc;
using UsersAchievements.Models;

namespace UsersAchievements.Helpers
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var birthdateString = request.Form.Get("Birthdate");
            var birthdate = Convert.ToDateTime(birthdateString);
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Form.Get("Name"),
                Birthdate = birthdate
            };
            return user;
        }
    }
}