namespace CsharpBasics
{
    class Person : ICloneable
    {
        public string Name { get; set; }
        public Company Work { get; set; }

        public Person(string name, Company company)
        {
            Name = name;
            Work = company;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
