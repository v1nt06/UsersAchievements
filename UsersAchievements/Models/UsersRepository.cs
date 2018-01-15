using System;
using System.Collections.Generic;

namespace UsersAchievements.Models
{
    public sealed class UsersRepository
    {
        #region Singleton implementation

        private static UsersRepository _instance;

        public static UsersRepository Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new UsersRepository();
                _instance.Users.Add(new User("Ivan Karimov", new DateTime(1989, 11, 16))
                {
                    Photo = "1.png",
                    Id = new Guid("A9AB38F1-7634-409B-BE11-7E4F3F3E5E11")
                });
                _instance.Users.Add(new User("Sofia Vasileva", new DateTime(1989, 03, 26))
                {
                    Id = new Guid("B972D15B-57F2-4A91-A852-C92AC8B602DD")
                });
                return _instance;
            }
        }

        private UsersRepository() { }

        #endregion

        public List<User> Users { get; } = new List<User>();
    }
}