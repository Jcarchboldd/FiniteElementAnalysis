﻿namespace STRCore.STRElements
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

        /// <summary>
        /// A flag that determines if the node was defined by the user, or by the analysis system running
        /// </summary>
        public bool IsAutoGenerated { get; set; }

        internal STRNode(int id, double x, double y, double z)
        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"STRNode {Id}: ({X:0.00}, {Y:0.00}, {Z:0.00}) - Support: {(Support == null ? "Free" : Support.Name)}";
        }
    }

    
}
