using System;

namespace UsersAchievements.Models
{
    public sealed class User
    {
        #region Fields

        private string _name;

        #endregion

        #region Properties

        public Guid Id { get; }

        public string Name
        {
            get => _name;
            set => _name = CheckName(value);
        }

        public DateTime Birthdate { get; private set; }

        public int Age => CalculateAge();

        public string Photo { get; set; }

        #endregion

        #region Methods

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

        private DateTime CheckBirthdate(DateTime? birthdate)
        {
            if (birthdate == null || birthdate > DateTime.Now)
            {
                throw new ArgumentException("Birthdate should be lesser or equal current date", nameof(birthdate));
            }

            return birthdate.Value;
        }

        #endregion
    }
}
