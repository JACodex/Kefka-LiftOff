using Microsoft.AspNetCore.Mvc;
using KEFKA.Models;
using System.Collections.Generic;

namespace KEFKA.Controllers
{
    public class StoryController : Controller
    {

        static private List<Story> stories = new List<Story>();

        public IActionResult Index()
        {
            //stories.Add(new Story("Test Story", "some sdfdsjf jdvnjfn"));
            ViewBag.Stories = stories;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/story/add")]
        public IActionResult Add(string name, string description)
        {

            stories.Add(new Story(name, description));
            return Redirect("/story");
        }
    }
}
