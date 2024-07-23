namespace STRCore.STRElements
{
    public class STRRelease
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        /// <summary>
        /// Starting spring in the x.
        /// </summary>
        public double KUxStart { get; set; }

        /// <summary>
        /// Starting spring in the y.
        /// </summary>
        public double KUyStart { get; set; }

        /// <summary>
        /// Starting spring in the z.
        /// </summary>
        public double KUzStart { get; set; }

        /// <summary>
        /// Starting spring in the rx.
        /// </summary>
        public double KRxStart { get; set; }

        /// <summary>
        /// Starting spring in the ry.
        /// </summary>
        public double KRyStart { get; set; }

        /// <summary>
        /// Starting spring in the rz.
        /// </summary>
        public double KRzStart { get; set; } 

        /// <summary>
        /// Ending spring in the x.
        /// </summary>
        public double KUxEnd { get; set; }

        /// <summary>
        /// Ending spring in the y.
        /// </summary>
        public double KUyEnd { get; set; }

        /// <summary>
        /// Ending spring in the z.
        /// </summary>
        public double KUzEnd { get; set; }

        /// <summary>
        /// Ending spring in the rx.
        /// </summary>
        public double KRxEnd { get; set; }

        /// <summary>
        /// Ending spring in the ry.
        /// </summary>
        public double KRyEnd { get; set; }

        /// <summary>
        /// Ending spring in the rz.
        /// </summary>
        public double KRzEnd { get; set; }

        internal STRRelease(int id, string? name, double kUxStart, double kUyStart, double kUzStart, double kRxStart, double kRyStart, double kRzStart, double kUxEnd, double kUyEnd, double kUzEnd, double kRxEnd, double kRyEnd, double kRzEnd)
        {
            Id = id;
            Name = name;
            KUxStart = kUxStart;
            KUyStart = kUyStart;
            KUzStart = kUzStart;
            KRxStart = kRxStart;
            KRyStart = kRyStart;
            KRzStart = kRzStart;
            KUxEnd = kUxEnd;
            KUyEnd = kUyEnd;
            KUzEnd = kUzEnd;
            KRxEnd = kRxEnd;
            KRyEnd = kRyEnd;
            KRzEnd = kRzEnd;
        }

        public override string ToString()
        {
            return "STRRelease: " + Id + " " + Name;
        }
    }
}
