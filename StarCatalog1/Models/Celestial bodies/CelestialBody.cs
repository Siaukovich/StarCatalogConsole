using System;

namespace StarCatalog
{
    public abstract class CelestialBody : INameable, IEquatable<CelestialBody>
    {
        #region Protected Fields

        protected string _name;
        protected float _radius;
        protected double _mass;

        #endregion

        #region Public Propereties

        public string Name
        {
            get => _name;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be null or empty", nameof(value));

                _name = value;
            }
        }

        public float Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _radius = value;
            }
        }

        public double Mass
        {
            get => _mass;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _mass = value;
            }
        }


        #endregion

        #region Constructor

        protected CelestialBody(string name, float radius, double mass)
        {
            this.Name = name;
            this.Radius = radius;
            this.Mass = mass;
        }
        
        #endregion
        
        #region IEquatable and ToString

        public override bool Equals(object obj)
        {
            return obj is CelestialBody c1 &&
                   this.Name.Equals(c1.Name) &&
                   this.Radius.Equals(c1.Radius) &&
                   this.Mass.Equals(c1.Mass);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _radius.GetHashCode();
                hashCode = (hashCode * 397) ^ _mass.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(CelestialBody other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Name.Equals(other.Name) &&
                   this.Radius.Equals(other.Radius) &&
                   this.Mass.Equals(other.Mass);
        }

        /// <summary>
        /// Return as string values of Name, Radius and Mass.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Raius in meteres: {Radius}\n" +
                   $"Mass in kg: {Mass}\n";
        }

        #endregion
    }
}