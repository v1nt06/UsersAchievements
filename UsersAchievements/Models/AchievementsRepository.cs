using System;
using System.Collections.Generic;

namespace UsersAchievements.Models
{
    public sealed class AchievementsRepository
    {
        #region Singleton implementation

        private static AchievementsRepository _instance;

        public static AchievementsRepository Instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = new AchievementsRepository();
                _instance.Achievements.Add(new Achievement("Builder")
                {
                    Description = "Buld 10 buildings",
                    Image = "1.png",
                    Id = new Guid("3C64D21B-2455-4E87-9C65-24B01D043C1A")
                });
                _instance.Achievements.Add(new Achievement("Destroyer")
                {
                    Description = "Destroy 10 buildings",
                    Id = new Guid("CF38929F-7F3C-4BC2-B1E7-44524AC1AC01")
                });
                return _instance;
            }
        }

        private AchievementsRepository() { }

        #endregion

        public List<Achievement> Achievements { get; } = new List<Achievement>();
    }
}