using Microsoft.AspNetCore.Mvc;
using KEFKA.Models;
using KEFKA.Data;
namespace KEFKA.Controllers
{
    public class StoryController : Controller
    {


        public IActionResult Index()
        {
            //stories.Add(new Story("Test Story", "some sdfdsjf jdvnjfn"));
            ViewBag.Stories = StoryData.GetAll();
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/story/add")]
        public IActionResult Add(Story newStory)
        {
            //Story newStory = new Story(name, description);
            StoryData.Add(newStory);
            return Redirect("/story");
        }
        [HttpGet("/story/Edit/{storyID?}")]
        public IActionResult Edit(int storyID = 0)
        {
            if(storyID == 0 || storyID.ToString().Equals(""))
            {
                return Redirect("/Story");
            }
            else
            {
                ViewBag.EditStory = StoryData.GetById(storyID);
                return View();
            }
        }

        [HttpPost]
        [Route("/Edit")]
        public IActionResult submitEditStory(int storyID, string name, string description)
        {
            return View();
        }

        public IActionResult Delete()
        {
            ViewBag.Stories = StoryData.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/story/Delete")]
        public IActionResult Delete(int[] storyIds)
        {
            foreach(int storyId in storyIds)
            {
                StoryData.Remove(storyId);
            }
            return Redirect("/story");
        }
    }
}
