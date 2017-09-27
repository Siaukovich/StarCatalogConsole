using System;

namespace StarCatalog
{
    public class Star : CelestialBody, IEquatable<Star>
    {
        #region Private Fields

        private float _temperature;

        #endregion

        #region Propereties

        public new float Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _radius = value;
                SetLuminosity();
            }
        }

        public float Temperature
        {
            get => _temperature;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _temperature = value;
                SetLuminosity();
                SetType();
            }
        }
        public float Luminosity { get; private set; }
        public StarType Type { get; private set; }
        public MyCollection<Planet> Planets { get; set; }

        #endregion

        #region Constructor

        public Star(string name, float radius, float mass, float temperature) 
            : base(name, radius, mass)
        {
            this.Temperature = temperature;
            this.Planets = new MyCollection<Planet>();
        }

        #endregion

        #region Custom Methods

        public void AddPlanet(string name, float radius, float mass,
            float siderealDay, float siderealYear, float orbitRadius)
        {
            var newPlanet = new Planet(name, radius, mass, siderealDay, siderealYear, this, orbitRadius);
            Planets.Add(newPlanet);
        }

        #endregion

        #region Helpers

        private void SetLuminosity()
        {
            const float sigma = 5.67e-8f;
            this.Luminosity = (float) (4 * Math.PI * Math.Pow(this.Radius, 2) * 
                sigma * Math.Pow(this.Temperature, 4));
        }

        private void SetType()
        {
            if (this.Temperature <= 2400)
                this.Type = StarType.M;
            else if (this.Temperature <= 5200)
                this.Type = StarType.K;
            else if (this.Temperature <= 6000)
                this.Type = StarType.G;
            else if (this.Temperature <= 7500)
                this.Type = StarType.F;
            else if (this.Temperature <= 10_000)
                this.Type = StarType.A;
            else if (this.Temperature <= 30_000)
                this.Type = StarType.B;
            else
                this.Type = StarType.O;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            var planets = Planets.GetStringOfFields(p => p.ToString());

            return base.ToString() +
                   $"Temprature in Kelvins: {Temperature}\n" +
                   $"Luminosity in Watts: {Luminosity}\n" +
                   $"Type: {Type}\n" +
                    "Planets:\n" +
                    planets;
        }

        public bool Equals(Star other)
        {
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && 
                   this.Radius.Equals(other.Radius) && 
                   this.Luminosity.Equals(other.Luminosity) && 
                   Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Star s &&
                   this.Equals(s);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ Temperature.GetHashCode();
                hashCode = (hashCode * 397) ^ Luminosity.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Type;
                hashCode = (hashCode * 397) ^ (Planets != null ? Planets.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}