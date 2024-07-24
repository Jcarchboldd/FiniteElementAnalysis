using static Global.Enums;

namespace STRCore.STRElements
{
    public class STRLoadCase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public LoadCaseType Type { get; set; }

        internal STRLoadCase(int id, string? name, LoadCaseType type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"STRLoadCase {Id}: {Name} - Type: {Type}";
        }


    }
}
