namespace StarCatalog1
{
    public abstract class CelestialBody
    {
        public string Name { get; set; }
        public float Radius { get; set; }
        public float Mass { get; set; }

        protected CelestialBody(string name, float radius, float mass)
        {
            this.Name = name;
            this.Radius = radius;
            this.Mass = mass;
        }
    }
}