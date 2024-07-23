using System.ComponentModel;
using System.Text;
using STRCore.STRElements;

namespace STRCore
{
    public class STRStructure
    {
        public int LastNodeId { get; set; }

        public int LastLineId { get; set; }

        public int LastMaterialId { get; set; }

        public int LastRelesaeId { get; set; }

        public int LastSectionId { get; set; }

        public int LastSupportId { get; set; }

        public List<STRNode> STRNodes { get; set; }

        public List<STRLine> STRLines { get; set; }

        public List<STRRelease> STRReleases { get; set; }

        public List<STRSupport> STRSupports { get; set; } 

        public List<STRSection> STRSections { get; set; }

        public List<STRMaterial> STRMaterials { get; set; }

        internal STRStructure()
        {
            STRNodes = [];
            STRLines = [];
            STRReleases = [];
            STRSupports = [];
            STRSections = [];
            STRMaterials = [];

            LastLineId = 0;
            LastNodeId = 0;
            LastMaterialId = 0;
            LastRelesaeId = 0;
            LastSupportId = 0;
            LastSectionId = 0;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Structure:");
            
            output.AppendLine("Materials:");
            foreach (var material in STRMaterials)
            {
                output.AppendLine(material.ToString());
            }

            output.AppendLine("Releases:");
            foreach (var release in STRReleases)
            {
                output.AppendLine(release.ToString());
            }

            output.AppendLine("Supports:");
            foreach (var support in STRSupports)
            {
                output.AppendLine(support.ToString());
            }

            return output.ToString();
        }
    }

}

