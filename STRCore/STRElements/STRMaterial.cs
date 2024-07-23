namespace STRCore.STRElements
{
    public class STRMaterial
    {
        public int Id { get; set; }
        public double ElasticModulus { get; set; }

        public string Name { get; set; }

        internal STRMaterial(int id, double elasticModulus, string name)
        {
            Id = id;
            ElasticModulus = elasticModulus;
            Name = name;
        }

        public override string ToString()
        {
            return $"STRMaterial {Id} - {Name}: E = {ElasticModulus.ToString("0.00")}";
        }
    }
}
