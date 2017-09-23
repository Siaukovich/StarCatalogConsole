using System;

namespace StarCatalog1
{
    public class Planet : CelestialBody
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

        #region Helpers

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Radius: {Radius}\n" +
                   $"Mass: {Mass}\n" +
                   $"Period around planets axis: {SiderealDay}\n" +
                   $"Period around host star: {SiderealYear}\n" +
                   $"Host star: {HostStar}\n" +
                   $"Radius of orbit: {OrbitRadius}";
        }

        #endregion
    }
}