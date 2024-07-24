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

        public int LastLoadCaseId { get; set; }

        public int LastLoadCombinationId { get; set; }

        public int LastLoadId { get; set; }

        public List<STRNode> STRNodes { get; set; }

        public List<STRLine> STRLines { get; set; }

        public List<STRRelease> STRReleases { get; set; }

        public List<STRSupport> STRSupports { get; set; } 

        public List<STRSection> STRSections { get; set; }

        public List<STRMaterial> STRMaterials { get; set; }

        public List<STRLoadCase> STRLoadCases { get; set; }

        public List<STRLoadCombination> STRLoadCombinations { get; set; }

        public List<STRLoad> STRLoads { get; set; }

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

            LastLineId = 1;
            LastNodeId = 1;
            LastMaterialId = 1;
            LastRelesaeId = 1;
            LastSupportId = 1;
            LastSectionId = 1;
            LastLoadCaseId = 1;
            LastLoadCombinationId = 1;
            LastLoadId = 1;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Structure:");

            AppendCollectionToStringBuilder(output, "Materials:", STRMaterials);
            AppendCollectionToStringBuilderWithSeparator(output, "Releases:", STRReleases);
            AppendCollectionToStringBuilderWithSeparator(output, "Supports:", STRSupports);
            AppendCollectionToStringBuilderWithSeparator(output, "Sections:", STRSections);
            AppendCollectionToStringBuilderWithSeparator(output, "Nodes:", STRNodes);
            AppendCollectionToStringBuilderWithSeparator(output, "Lines:", STRLines);
            AppendCollectionToStringBuilderWithSeparator(output, "Load Cases:", STRLoadCases);
            AppendCollectionToStringBuilderWithSeparator(output, "Load Combinations:", STRLoadCombinations);
            AppendCollectionToStringBuilderWithSeparator(output, "Loads:", STRLoads, ConsoleColor.Yellow);

            return output.ToString();
        }

        private void AppendCollectionToStringBuilder<T>(StringBuilder sb, string header, IEnumerable<T> collection, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            sb.AppendLine(header);
            foreach (var item in collection)
            {
                sb.AppendLine(item?.ToString());
            }
            Console.ResetColor();
        }

        private void AppendCollectionToStringBuilderWithSeparator<T>(StringBuilder sb, string header, IEnumerable<T> collection, ConsoleColor color = ConsoleColor.White)
        {
            AppendSeparator(sb);
            AppendCollectionToStringBuilder(sb, header, collection, color);
        }

        private void AppendSeparator(StringBuilder sb)
        {
            sb.AppendLine(new string('-', 40)); // Adds a separator line of 40 dashes
        }
    }

}

