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

        public Constellation(string name,
            EquatorialCoordinates coordinates, MyCollection<Star> stars)
        {
            this.Name = name;
            this.Coordinates = coordinates;
            this.Stars = stars;
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