using System.Text;

namespace STRCore.STRElements
{
    public class STRLoadLinearDistributed:STRLoad
    {
        public double Fx1 { get; set; }
        public double Fy1 { get; set; }
        public double Fz1  { get; set; }
        public double Mx1 { get; set; }
        public double My1 { get; set; }
        public double Mz1 { get; set; }
        /// <summary>
        /// This is the relative location (x/L) of the start of the load from the start with respect to its length
        /// 0 is start
        /// 1 is end
        /// 0.50 is midpoint and so on.
        /// </summary>
        public double RelativeLocation1 { get; set; }

        public double Fx2 { get; set; }

        public double Fy2 { get; set; }

        public double Fz2 { get; set; }

        public double Mx2 { get; set; }
        public double My2 { get; set; }
        public double Mz2 { get; set; }
        /// <summary>
        /// This is the relative location (x/L) of the end of the load from the start with respect to its length
        /// 0 is start
        /// 1 is end
        /// 0.50 is midpoint and so on.
        /// </summary>
        public double RelativeLocation2 { get; set; }

        internal STRLoadLinearDistributed(int id, STRLoadCase loadCase, List<int> appliedOnIds,
            double fx1, double fy1, double fz1, double mx1, double my1, double mz1, double relLoc1,
            double fx2, double fy2, double fz2, double mx2, double my2, double mz2, double relLoc2) 
            : base(id, loadCase, appliedOnIds)
        {
            Fx1 = fx1;
            Fy1 = fy1;
            Fz1 = fz1;
            Mx1 = mx1;
            My1 = my1;
            Mz1 = mz1;
            RelativeLocation1 = relLoc1;
            Fx2 = fx2;
            Fy2 = fy2;
            Fz2 = fz2;
            Mx2 = mx2;
            My2 = my2;
            Mz2 = mz2;
            RelativeLocation2 = relLoc2;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"STRLoadLinearDistributed#{Id} ({LoadCase})")
            .AppendLine($"Fx1 = {Fx1:0.00}")
            .AppendLine($"Fy1 = {Fy1:0.00}")
            .AppendLine($"Fz1 = {Fz1:0.00}")
            .AppendLine($"Mx1 = {Mx1:0.00}")
            .AppendLine($"My1 = {My1:0.00}")
            .AppendLine($"Mz1 = {Mz1:0.00}")
            .AppendLine($"RelLoc1 = {RelativeLocation1:0.00}")
            .AppendLine($"Fx2 = {Fx2:0.00}")
            .AppendLine($"Fy2 = {Fy2:0.00}")
            .AppendLine($"Fz2 = {Fz2:0.00}")
            .AppendLine($"Mx2 = {Mx2:0.00}")
            .AppendLine($"My2 = {My2:0.00}")
            .AppendLine($"Mz2 = {Mz2:0.00}")
            .Append($"RelLoc2 = {RelativeLocation2:0.00}");
            
            return sb.ToString();
        }

    }
}
