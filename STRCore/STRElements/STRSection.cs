namespace STRCore.STRElements
{
    public class STRSection
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Area { get; set; }

        public double InertiaX { get; set; }

        public double InertiaY { get; set; }

        public double InertiaZ { get; set; }

        internal STRSection(int id, string name, double area, double inertiaX, double inertiaY, double inertiaZ)
        {
            Id = id;
            Name = name;
            Area = area;
            InertiaX = inertiaX;
            InertiaY = inertiaY;
            InertiaZ = inertiaZ;
        }

        public override string ToString()
        {
            return $"Section: {Name}, Area: {Area:0.00}";
        }
    }
}

