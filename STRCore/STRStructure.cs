using System.ComponentModel;
using System.Text;
using STRCore.FEMElements;
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

        public int LastLoadCaseId { get; set; }

        public int LastLoadCombinationId { get; set; }

        public int LastLoadId { get; set; }

        public int LastFEMNodeId { get; set; }

        public int LastFEMBarId { get; set; }


        public List<STRNode> STRNodes { get; set; }

        public List<STRLine> STRLines { get; set; }

        public List<STRRelease> STRReleases { get; set; }

        public List<STRSupport> STRSupports { get; set; } 

        public List<STRSection> STRSections { get; set; }

        public List<STRMaterial> STRMaterials { get; set; }

        public List<STRLoadCase> STRLoadCases { get; set; }

        public List<STRLoadCombination> STRLoadCombinations { get; set; }

        public List<STRLoad> STRLoads { get; set; }
        public List<FEMNode> FEMNodes { get; set; }
        public List<FEMBar> FEMBars { get; set; }

        internal STRStructure()
        {
            STRNodes = [];
            STRLines = [];
            STRReleases = [];
            STRSupports = [];
            STRSections = [];
            STRMaterials = [];
            STRLoadCases = [];
            STRLoadCombinations = [];
            STRLoads = [];
            FEMNodes = [];
            FEMBars = [];

            LastLineId = 1;
            LastNodeId = 1;
            LastMaterialId = 1;
            LastRelesaeId = 1;
            LastSupportId = 1;
            LastSectionId = 1;
            LastLoadCaseId = 1;
            LastLoadCombinationId = 1;
            LastLoadId = 1;
            LastFEMNodeId = 1;
            LastFEMBarId = 1;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Structure:");

            AppendCollectionToStringBuilder(output, "Materials:", STRMaterials);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Releases:", STRReleases);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Supports:", STRSupports);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Sections:", STRSections);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Nodes:", STRNodes);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Lines:", STRLines);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Load Cases:", STRLoadCases);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Load Combinations:", STRLoadCombinations);
            AppendSeparator(output);
            AppendCollectionToStringBuilder(output, "Loads:", STRLoads);

            return output.ToString();
        }

        private void AppendCollectionToStringBuilder<T>(StringBuilder sb, string header, IEnumerable<T> collection)
        {
            sb.AppendLine(header);
            foreach (var item in collection)
            {
                if (item is STRLoadNodal)
                {
                    sb.AppendLine((item as STRLoadNodal)?.ToString());
                }
                else if (item is STRLoadLinearConcentrated)
                {
                    sb.AppendLine((item as STRLoadLinearConcentrated)?.ToString());
                }
                else if (item is STRLoadLinearDistributed)
                {
                    sb.AppendLine((item as STRLoadLinearDistributed)?.ToString());
                }
                else
                {
                    sb.AppendLine(item?.ToString());
                }
            }
        }

        private void AppendSeparator(StringBuilder sb)
        {
            sb.AppendLine(new string('-', 40)); // Adds a separator line of 40 dashes
        }
    }

}

