using System.Text;

namespace STRCore.STRElements
{
    public class STRLoadNodal:STRLoad
    {
        public double Fx { get; set; }

        public double Fy { get; set; }

        public double Fz { get; set; }

        public double Mx { get; set; }

        public double My { get; set; }

        public double Mz { get; set; }
        internal STRLoadNodal(int id, STRLoadCase loadCase, List<int> appliedOnIds, double fx, double fy, double fz, double mx, double my, double mz):base(id, loadCase, appliedOnIds)
        {
            Fx= fx;
            Fy= fy;
            Fz= fz;
            Mx = mx;
            My = my;
            Mz = mz;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"STRLoadNodal#{Id} ({LoadCase})")
            .AppendLine($"Fx = {Fx:0.00}")
            .AppendLine($"Fy = {Fy:0.00}")
            .AppendLine($"Fz = {Fz:0.00}")
            .AppendLine($"Mx = {Mx:0.00}")
            .AppendLine($"My = {My:0.00}")
            .Append($"Mz = {Mz:0.00}");

            return sb.ToString();
        }
    }
}
