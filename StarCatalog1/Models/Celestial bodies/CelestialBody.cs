using System;

namespace StarCatalog1
{
    public abstract class CelestialBody : INameable
    {
        #region Private Fields

        protected string _name;
        protected float _radius;
        protected float _mass;

        #endregion

        #region Public Propereties

        public string Name
        {
            get => _name;
            set
            {
                if (!String.IsNullOrEmpty(value))
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

        public float Mass
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

        protected CelestialBody(string name, float radius, float mass)
        {
            this.Name = name;
            this.Radius = radius;
            this.Mass = mass;
        }
    }
}