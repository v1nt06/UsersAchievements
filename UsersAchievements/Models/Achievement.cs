using System;

namespace UsersAchievements.Models
{
    public sealed class Achievement
    {
        private string _title;

        public Guid Id { get; }

        public string Title
        {
            get => _title;
            set => _title = CheckTitle(value);
        }

        public string Description { get; set; }

        public string Image { get; set; }

        public Achievement(string title)
        {
            Title = CheckTitle(title);
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Title;
        }

        private string CheckTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title shouldn't be empty", nameof(title));
            }

            return title;
        }
    }
}