using Microsoft.AspNetCore.Mvc;
using KEFKA.Models;
using KEFKA.Data;
using System.Collections;
using System.Linq;
namespace KEFKA.Controllers
{
    public class StoryController : Controller
    {
        private KefkaDbContext _context;

        public StoryController(KefkaDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            //stories.Add(new Story("Test Story", "some sdfdsjf jdvnjfn"));
            //ViewBag.Stories = StoryData.GetAll(); //Refactored to use Database Instead
            List<Story> stories = _context.Stories.AsQueryable().ToList();
            ViewBag.Stories = stories;
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
            //StoryData.Add(newStory); // Refactored to use database
            _context.Add(newStory);
            _context.SaveChanges();
            return Redirect("/story");
        }
        [HttpGet("/story/Edit/{storyID}")]
        public IActionResult Edit(int storyID)
        {
            //ViewBag.Stories = StoryData.GetAll();

            if (storyID == 0 || storyID.ToString().Equals(""))
            {
                return Redirect("/Story");
            }
            else
            {
                //ViewBag.EditStory = StoryData.GetById(storyID); //Refactored to use Database
                Story editStory = _context.Stories.Find(storyID);
                ViewBag.EditStory = editStory;
                return View();
            }
        }

        [HttpPost]
        [Route("/story/Edit")]
        public IActionResult submitEditStory(int storyID, string name, string description, string storyText)
        {
            /**************** REFACTORED TO USE DB *****************************/
            //StoryData.GetById(storyID).Name = name;
            //StoryData.GetById(storyID).Description = description;
            //StoryData.GetById(storyID).StoryText = storyText;
            Story editStory = _context.Stories.Find(storyID);
            _context.Attach(editStory);
            editStory.Name = name;
            editStory.Description = description;
            editStory.StoryText = storyText;
            _context.SaveChanges();
            return Redirect("/story");
        }

        public IActionResult Delete()
        {
            ViewBag.Stories = _context.Stories.ToList();
            return View();
        }

        [HttpPost]
        [Route("/story/Delete")]
        public IActionResult Delete(int[] storyIds)
        {
            foreach(int storyId in storyIds)
            {
                //StoryData.Remove(storyId); //Refactored to use Database
                Story storyDelete = _context.Stories.Find(storyId);
                _context.Stories.Remove(storyDelete);
            }
            return Redirect("/story");
        }
    }
}
