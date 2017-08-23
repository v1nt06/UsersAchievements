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
                if (_instance == null)
                {
                    _instance = new AchievementsRepository();
                    _instance.Achievements.Add(new Achievement("Builder") { Description = "Buld 10 buildings", Image = "1.png"});
                    _instance.Achievements.Add(new Achievement("Destroyer") { Description = "Destroy 10 buildings" });
                }
                return _instance;
            }
        }

        private AchievementsRepository() { }

        #endregion

        public List<Achievement> Achievements { get; } = new List<Achievement>();
    }
}