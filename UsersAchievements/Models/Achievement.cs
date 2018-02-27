using System;
using System.ComponentModel.DataAnnotations;

namespace UsersAchievements.Models
{
    public sealed class Achievement
    {
        public Guid Id { get; set; }

        [Required]
        [RegularExpression(@"[A-z0-9\s-]{2,50}")]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public string Image { get; set; }

        public Achievement() { }

        public Achievement(string title)
        {
            Title = title;
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
