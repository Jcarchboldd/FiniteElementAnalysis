using static Global.Enums;

namespace STRCore.STRElements
{
    public class STRLoadCombination : STRLoadCase
    {
        public LoadCombinationType LoadCombinationType { get; set; }

        public List<STRLoadCase> LoadCases { get; set; }

        public List<double> LoadCaseFactors { get; set; }

        internal STRLoadCombination(int id, string? name, LoadCombinationType loadCombinationType) : base(id, name, LoadCaseType.Other)
        {
            LoadCombinationType = loadCombinationType;
            LoadCases = [];
            LoadCaseFactors = [];
        }

        public override string ToString()
        {
            return $"STRLoadCombination {Id}: {Name} - Type: {LoadCombinationType}";
        }

    }
}

