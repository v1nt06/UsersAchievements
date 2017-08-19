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
                if (_instance == null)
                {
                    _instance = new UsersRepository();
                    _instance.Users.Add(new User("Ivan Karimov", new DateTime(1989, 11, 16)));
                    _instance.Users.Add(new User("Sofia Vasileva", new DateTime(1989, 03, 26)));
                }
                return _instance;
            }
        }

        private UsersRepository() { }

        #endregion

        public List<User> Users { get; } = new List<User>();
    }
}