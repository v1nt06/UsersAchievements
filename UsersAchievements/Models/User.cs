using System;
using System.ComponentModel.DataAnnotations;
using UsersAchievements.Helpers;

namespace UsersAchievements.Models
{
    public sealed class User
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Birthdate]
        public DateTime Birthdate { get; set; }

        public int Age => CalculateAge();

        public string Photo { get; set; }

        public User() { }

        public User(string name, DateTime? birthdate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Birthdate = CheckBirthdate(birthdate);
        }

        public override string ToString()
        {
            return Name;
        }

        public void SetBirthdate(DateTime? birthdate)
        {
            Birthdate = CheckBirthdate(birthdate);
        }

        private int CalculateAge()
        {
            if (Birthdate >= DateTime.Today)
            {
                return 0;
            }

            var zeroTime = new DateTime(1, 1, 1);
            return (zeroTime + (DateTime.Now - Birthdate)).Year - 1;
        }

        private DateTime CheckBirthdate(DateTime? birthdate)
        {
            if (birthdate == null || birthdate > DateTime.Now)
            {
                throw new ArgumentException("Birthdate should be lesser or equal current date", nameof(birthdate));
            }

            return birthdate.Value;
        }
    }
}
