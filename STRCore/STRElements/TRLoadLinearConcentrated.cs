using System.Text;

namespace STRCore.STRElements
{
    public class STRLoadLinearConcentrated:STRLoad
    {
        public double Fx { get; set; }
        public double Fy { get; set; }
        public double Fz { get; set; }
        public double Mx { get; set; }
        public double My { get; set; }
        public double Mz { get; set; }
        /// <summary>
        /// This is the relative location (x/L) of the load from the start with respect to its length
        /// 0 is start
        /// 1 is end
        /// 0.50 is midpoint and so on.
        /// </summary>
        public double RelativeLocation {get; set;}

        internal STRLoadLinearConcentrated(int id, STRLoadCase loadCase, List<int> appliedOnIds, double fx, double fy, double fz, double mx, double my, double mz, double relLoc) : base(id, loadCase, appliedOnIds)
        {
            Fx = fx;
            Fy = fy;
            Fz = fz;
            Mx = mx;
            My = my;
            Mz = mz;
            RelativeLocation = relLoc;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"STRLoadLinearConcentrated#{Id} ({LoadCase})")
            .AppendLine($"Fx = {Fx:0.00}")
            .AppendLine($"Fy = {Fy:0.00}")
            .AppendLine($"Fz = {Fz:0.00}")
            .AppendLine($"Mx = {Mx:0.00}")
            .AppendLine($"My = {My:0.00}")
            .AppendLine($"Mz = {Mz:0.00}")
            .Append($"RelLoc = {RelativeLocation:0.00}");
            
            return sb.ToString();
        }

    }
}
