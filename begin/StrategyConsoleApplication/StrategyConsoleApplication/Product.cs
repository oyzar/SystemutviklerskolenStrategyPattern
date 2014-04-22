namespace StrategyConsoleApplication
{
    public class Product
    {
        public string Name { get; private set; }
        public string RecommendedBy { get; private set; }

        public Product(string name, string recommendedBy)
        {
            Name = name;
            RecommendedBy = recommendedBy;
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}