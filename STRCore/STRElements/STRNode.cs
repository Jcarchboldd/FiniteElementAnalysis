namespace STRCore.STRElements
{
    public class STRNode
    {
        /// <summary>
        /// Node ID
        /// </summary>

        public int Id { get; set; }
        /// <summary>
        /// The X coordinate of the node
        /// </summary>

        public Double X { get; set; }
        /// <summary>
        /// The Y coordinate of the node
        /// </summary>

        public Double Y { get; set; }
        /// <summary>
        /// The Z coordinate of the node
        /// </summary>

        public Double Z { get; set; }

        /// <summary>
        /// The boundary condition of the node 
        /// </summary>
        public STRSupport? Support { get; set; }

        internal STRNode(int id, Double x, Double y, Double z)
        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"STRNode {Id}: ({X.ToString("0.00")}, {Y.ToString("0.00")}, {Z.ToString("0.00")})";
        }
    }

    
}
