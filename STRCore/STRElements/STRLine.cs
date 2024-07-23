using System.ComponentModel;

namespace STRCore.STRElements
{
    public class STRLine
    {
        /// <summary>
        /// Line ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The start node of the line
        /// </summary>
        public STRNode StartNode { get; set; }

        /// <summary>
        /// The end node of the line
        /// </summary>
        public STRNode EndNode { get; set; }

        /// <summary>
        /// The section of the line
        /// </summary>
        public STRSection? Section { get; set; }

        /// <summary>
        /// The cross section of the line
        /// </summary>
        public STRMaterial? Material { get; set; }

        /// <summary>
        /// The length of the line
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// The release (e.g internal hinges) of the line
        /// </summary>
        public STRRelease? Release { get; set; }

        /// <summary>
        /// The Center of Gravity of the line
        /// </summary>
        public double[]? CG { get; set; }

        /// <summary>
        /// Local X-Axis unit vector
        /// </summary>
        
        public double[] _vx = new double[3];
        private double[] Vx
        {
            get => _vx;
            set
            {
                _vx = value;
            }
        }
        

        /// <summary>
        /// Local Y-Axis unit vector 
        /// </summary>
        public double[] _vy = new double[3];
        private double[] Vy
        {
            get => _vy;
            set
            {
                _vy = value;
            }
        }

        /// <summary>
        /// Local Z-Axis unit vector
        /// </summary>
        public double[] _vz = new double[3];
        private double[] Vz
        {
            get => _vz;
            set
            {
                _vz = value;
            }
        }

        internal STRLine(int id, STRNode startNode, STRNode endNode)
        {
            Id = id;
            StartNode = startNode;
            EndNode = endNode;
            Refresh();
        }

        public void Refresh()
        {
            CG = new double[3];
            CG[0] = (EndNode.X + StartNode.X) / 2.0;
            CG[1] = (EndNode.Y + StartNode.Y) / 2.0;
            CG[2] = (EndNode.Z + StartNode.Z) / 2.0;

            _vx = new double[3];
            _vx[0] = EndNode.X - StartNode.X;
            _vx[1] = EndNode.Y - StartNode.Y;
            _vx[2] = EndNode.Z - StartNode.Z;

            Length = Helpers.Vector.Length(_vx);

            Helpers.Vector.Normalize(ref _vx);

            bool isParallelToZ = false;

            if (Math.Abs(_vx[0]) < Global.Constants.Epsilon && Math.Abs(_vx[1]) < Global.Constants.Epsilon)
            {
                isParallelToZ = true;
            }

            if(!isParallelToZ)
            {
                double[] globalZ = [0, 0, 1];
                Vy = Helpers.Vector.CrossProduct(globalZ, _vx);
                Helpers.Vector.Normalize(ref _vy);
                Vz = Helpers.Vector.CrossProduct(_vx, _vy);
                Helpers.Vector.Normalize(ref _vz);

            }
            else
            {
                _vy = [0, 1, 0];
                _vz = Helpers.Vector.CrossProduct(_vx, _vy);
                Helpers.Vector.Normalize(ref _vz);
            }
        }

        public override string ToString()
        {
            return $"STRLine {Id}: ({StartNode} - {EndNode}){Environment.NewLine}" +
                   $"Length: {Length:0.00}{Environment.NewLine}" +
                   $"vx: {Vx?[0]:0.00}, {Vx?[1]:0.00}, {Vx?[2]:0.00}{Environment.NewLine}" +
                   $"vy: {Vy?[0]:0.00}, {Vy?[1]:0.00}, {Vy?[2]:0.00}{Environment.NewLine}" +
                   $"vz: {Vz?[0]:0.00}, {Vz?[1]:0.00}, {Vz?[2]:0.00}";
        }
    }
}
