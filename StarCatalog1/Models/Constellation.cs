using System;
using System.Linq;

namespace StarCatalog1
{
    public class Constellation : INameable
    {
        private string _name;

        // Image!

        public EquatorialCoordinates Coordinates { get; set; }
        public MyCollection<Star> Stars { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                // Only letters and whitespaces are allowed.
                if (!IsValidName(value))
                    throw new ArgumentException("Constellation name must be in latin!");

                _name = value;
            }
        }

        public static bool IsValidName(string name)
        {
            return name.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c));
        }

        public Constellation(string name, EquatorialCoordinates coordinates)
        {
            this.Name = name;
            this.Coordinates = coordinates;
            this.Stars = new MyCollection<Star>();
        }

        public void AddStar(string name, float radius, float mass, float temperature)
        {
            var newStar = new Star(name, radius, mass, temperature);
            this.Stars.Add(newStar);
        }

        public override string ToString()
        {
            var listOfStars = Stars.GetStringOfFields(s => s.Name);

            return $"Name: {Name}\n" +
                    "Coordinates:\n" +
                   $"{Coordinates}\n\n" +
                     "Stars:\n" +
                    listOfStars + '\n';
        }
    }
}