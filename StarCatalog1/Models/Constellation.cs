using System;
using System.Linq;

namespace StarCatalog1
{
    public class Constellation
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
                var valueIsValid = value.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c));
                if (!valueIsValid)
                    throw new ArgumentException("Constellation name must be in latin!");

                _name = value;
            }
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
                    listOfStars;
        }
    }
}