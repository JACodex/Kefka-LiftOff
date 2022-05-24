using Microsoft.AspNetCore.Mvc;

namespace KEFKA.Models
{
    public class Story
    {
        //[FromForm(Name="name")]
        public string Name { get; set; }

        //[FromForm(Name="description")]
        public string Description { get; set; }

        public string StoryText { get; set; }

        public  int Id { get; set; }

        //private static int nextID = 1;

        public Story()
        {
            //ID = nextID;
            //nextID++;
            //Name = "TODO: Add a Title this Story";
            //Description = "TODO: Add Description to this Story";
            //StoryText = "TODO: Add Story Text Here";
        }
        public Story(string name, string description, string storyText) : base()
        {
            Name = name;
            Description = description;
            StoryText = storyText;
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
