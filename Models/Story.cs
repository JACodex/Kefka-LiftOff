namespace KEFKA.Models
{
    public class Story
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private static int ID { get; set; }

        private static int nextID = 1;


        public Story(string name, string description)
        {
            Name = name;
            Description = description;
            ID = nextID;
            nextID++;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"Story name: {Name} - Description: {Description}";
        }
    }
}
