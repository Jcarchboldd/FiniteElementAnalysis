using STRCore.STRElements;

namespace STRCore.FEMElements
{
    public class FEMNode
    {
        public int Id { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public bool IsMasterNode { get; set; }
        public bool IsSupportNode { get; set; }
        public STRNode? CorrespondingSTRNode { get; set; }
        public FEMNode? MasterFEMNode { get; set; }
        public FEMNode? SlaveFEMNode { get; set; }
        public bool IsSlaveNode { get; set; }

        internal FEMNode(int id, double x, double y, double z)
        {
            Id= id;
            X = x;
            Y = y;
            Z = z;
            IsMasterNode = false;
            IsSupportNode = false;
            MasterFEMNode = null;
            CorrespondingSTRNode = null;
            IsSlaveNode = false;
        }
    }
}