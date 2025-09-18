namespace MyApp.Shared.Models
{
    public class Child
    {
        private string? _name;
        private DateOnly? _birthDate;

        public Child()
        {
        }

        public Child(string name, DateOnly birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string? Name
        {
            get => _name;
            set => _name = value;
        }

        public DateOnly? BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public override string ToString()
        {
            return $"Name: {Name}, birthdate: {BirthDate}";
        }
    }
}
