using System.Text;
using Global;

namespace STRCore.STRElements
{
    public class STRSupport
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double KUx { get; set; }

        public double KUy { get; set; }

        public double KUz { get; set; }

        public double KRx { get; set; }

        public double KRy { get; set; }

        public double KRz { get; set; }

        public double Ux { get; set; }

        public double Uy { get; set; }

        public double Uz { get; set; }

        public double Rx { get; set; }

        public double Ry { get; set; }

        public double Rz { get; set; }

        public bool IsUxActive { get; set; }

        public bool IsUyActive { get; set; }

        public bool IsUzActive { get; set; }

        public bool IsRxActive { get; set; }

        public bool IsRyActive { get; set; }

        public bool IsRzActive { get; set; }

        internal STRSupport(int id, string name, bool isUxActive, bool isUyActive, bool isUzActive, bool isRxActive, bool isRyActive, bool isRzActive)
        {
            Id = id;
            Name = name;
            IsUxActive = isUxActive;
            IsUyActive = isUyActive;
            IsUzActive = isUzActive;
            IsRxActive = isRxActive;
            IsRyActive = isRyActive;
            IsRzActive = isRzActive;

            Refresh();
        }

        public override string ToString()
        {
            var output = new StringBuilder($"STRSupport: {Name} with Id: {Id} ");
            output.Append(IsUxActive ? "Y" : "N");
            output.Append(IsUyActive ? "Y" : "N");
            output.Append(IsUzActive ? "Y" : "N");
            output.Append(IsRxActive ? "Y" : "N");
            output.Append(IsRyActive ? "Y" : "N");
            output.Append(IsRzActive ? "Y" : "N");
            return output.ToString();
        }

        internal void Refresh()
        {
            KUx = IsUxActive ? Constants.RigidKU : Constants.FreeKU;
            KUy = IsUyActive ? Constants.RigidKU : Constants.FreeKU;
            KUz = IsUzActive ? Constants.RigidKU : Constants.FreeKU;
            KRx = IsRxActive ? Constants.RigidKR : Constants.FreeKR;
            KRy = IsRyActive ? Constants.RigidKR : Constants.FreeKR;
            KRz = IsRzActive ? Constants.RigidKR : Constants.FreeKR;
        }
    }
}