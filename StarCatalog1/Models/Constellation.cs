using System;
using System.Linq;

namespace StarCatalog
{
    public class Constellation : INameable, IEquatable<Constellation>
    {
        #region Private Field

        private string _name;

        #endregion

        #region Public Propereties

        public EquatorialCoordinates Coordinates { get; set; }
        public MyCollection<Star> Stars { get; set; }
        // TODO: Image

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

        #endregion

        #region Constructor

        public Constellation(string name, EquatorialCoordinates coordinates)
        {
            this.Name = name;
            this.Coordinates = coordinates;
            this.Stars = new MyCollection<Star>();
        }

        #endregion

        #region Helpers

        public void AddStar(string name, float radius, float mass, float temperature)
        {
            var newStar = new Star(name, radius, mass, temperature);
            this.Stars.Add(newStar);
        }

        public static bool IsValidName(string name)
        {
            return name.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c));
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            var listOfStars = Stars.GetStringOfFields(s => s.ToString());

            return $"Name: {Name}\n" +
                    "Coordinates:\n" +
                   $"{Coordinates}\n\n" +
                    "Stars:\n" +
                    listOfStars;
        }

        public bool Equals(Constellation other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;
                   
            return this.Name.Equals(other.Name) &&
                   this.Coordinates.Equals(other.Coordinates);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Constellation c &&  
                   Equals(c);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Coordinates != null ? Coordinates.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Stars != null ? Stars.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}