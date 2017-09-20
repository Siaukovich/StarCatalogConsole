using System;

namespace StarCatalog1
{
    public class Star : CelestialBody
    {
        #region Propereties

        public float Luminosity { get; set; }
        public StarType Type { get; set; }
        public MyCollection<Planet> Planets { get; set; }

        #endregion

        #region Constructor

        public Star(string name, float radius, float mass, float luminosity, MyCollection<Planet> planets) 
            : base(name, radius, mass)
        {
            this.Luminosity = luminosity;
            this.Planets = planets;
            SetType();
        }

        #endregion

        #region Helpers

        private void SetType()
        {
            var temperature = this.Luminosity / (4 * Math.PI * this.Radius * this.Radius);

            if (temperature <= 2400)
                this.Type = StarType.M;
            else if (temperature <= 5200)
                this.Type = StarType.K;
            else if (temperature <= 6000)
                this.Type = StarType.G;
            else if (temperature <= 7500)
                this.Type = StarType.F;
            else if (temperature <= 10_000)
                this.Type = StarType.A;
            else if (temperature <= 30_000)
                this.Type = StarType.B;
            else
                this.Type = StarType.O;
        }

        #endregion
    }
}