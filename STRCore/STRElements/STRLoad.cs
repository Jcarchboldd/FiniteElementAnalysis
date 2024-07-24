namespace STRCore.STRElements
{
    public class STRLoad
    {
        public int Id { get; set; }
        public STRLoadCase LoadCase { get; set; }

        /// <summary>
        /// The ids of the members upon which the load is applied
        /// </summary>
        public List<int> AppliedOnIds { get; set; }

        internal STRLoad(int id, STRLoadCase loadCase, List<int> appliedOnIds)
        {
            Id = id;
            LoadCase = loadCase;
            AppliedOnIds = new List<int>(appliedOnIds);
        }

        public override string ToString()
        {
            return $"STRLoad {Id}: {LoadCase.Name} - Applied on: {string.Join(", ", AppliedOnIds)}";
        }

    }
}

