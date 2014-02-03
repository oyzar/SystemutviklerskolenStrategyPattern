namespace StrategyConsoleApplication
{
    public class Customer
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public Customer(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
        }
    }
}