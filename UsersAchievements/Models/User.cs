using System;

namespace UsersAchievements.Models
{
    public sealed class User
    {
        private string _name;

        public Guid Id { get; }
        public string Name
        {
            get => _name;
            set => _name = CheckName(value);
        }

        public DateTime Birthdate { get; }

        public int Age => CalculateAge();

        public User(string name, DateTime? birthdate)
        {
            Id = Guid.NewGuid();
            Name = name;
            if (birthdate == null || birthdate > DateTime.Now)
            {
                throw  new ArgumentException("Birthdate should be lesser or equal current date", nameof(birthdate));
            }
            Birthdate = birthdate.Value;
        }

        public override string ToString()
        {
            return Name;
        }

        private int CalculateAge()
        {
            var zeroTime = new DateTime(1, 1, 1);
            return (zeroTime + (DateTime.Now - Birthdate)).Year - 1;
        }

        private string CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name shouldn't be empty", nameof(name));
            }

            return name;
        }
    }
}