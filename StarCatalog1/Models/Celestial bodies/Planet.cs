using System;

namespace StarCatalog
{
    public class Planet : CelestialBody, IEquatable<Planet>
    {
        #region Propereties

        /// <summary>
        /// Period of rotation around planets own axis in seconds.
        /// </summary>
        public float SiderealDay { get; set; }

        /// <summary>
        /// Period of ratation around the host star in seconds.
        /// </summary>
        public float SiderealYear { get; set; }

        public Star HostStar { get; set; }
        public float OrbitRadius { get; set; }

        #endregion

        #region Constructor

        public Planet(string name, float radius, float mass, float siderealDay, 
            float siderealYear, Star hostStar, float orbitRadius) 
            : base(name, radius, mass)
        {
            this.SiderealDay = siderealDay;
            this.SiderealYear = siderealYear;
            this.HostStar = hostStar;
            this.OrbitRadius = orbitRadius;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return base.ToString() +
                   $"Period around planets axis in seconds: {SiderealDay}\n" +
                   $"Period around host star in seconds: {SiderealYear}\n" +
                   $"Host star: {HostStar}\n" +
                   $"Radius of orbit in metres: {OrbitRadius}\n";
        }

        public bool Equals(Planet other)
        {
            return base.Equals(other) &&
                   SiderealDay.Equals(other.SiderealDay) && 
                   SiderealYear.Equals(other.SiderealYear) && 
                   Equals(HostStar, other.HostStar) && 
                   OrbitRadius.Equals(other.OrbitRadius);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return obj is Planet p &&
                   this.Equals(p);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = SiderealDay.GetHashCode();
                hashCode = (hashCode * 397) ^ SiderealYear.GetHashCode();
                hashCode = (hashCode * 397) ^ (HostStar != null ? HostStar.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrbitRadius.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}