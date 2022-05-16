using KEFKA.Models;
using System.Collections.Generic;

namespace KEFKA.Data
{
    public class StoryData
    {
        static private Dictionary<int , Story> Stories = new Dictionary<int, Story>();

        public static IEnumerable<Story> GetAll()
        {
            return Stories.Values;
        }

        public static void Add(Story newStory)
        {
            Stories.Add(newStory.ID, newStory);
        }

        public static void Remove(int id)
        {
            Stories.Remove(id);
        }

        public static Story GetById(int id)
        {
            return Stories[id];
        }
    }
}
