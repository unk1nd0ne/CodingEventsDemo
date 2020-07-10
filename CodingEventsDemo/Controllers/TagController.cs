using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;

namespace CodingEventsDemo.Controllers
{
    public class TagController : Controller
    {
        private EventDbContext context;

        public TagController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Tag> eventTags = context.Tags.ToList();

            return View(eventTags);
        }

        public IActionResult Create()
        {
            AddTagViewModel addTagViewModel = new AddTagViewModel();

            return View(addTagViewModel);
        }

        [HttpPost]
        [Route("Tag/Create")]
        public IActionResult ProcessCreateTagFormt(AddTagViewModel addTagViewModel)
        {
            if (ModelState.IsValid)
            {
                Tag newTag = new Tag
                {
                    Name = addTagViewModel.Name,
                };

                context.Tags.Add(newTag);
                context.SaveChanges();

                return Redirect("/Tag");
            }

            return View("Create", addTagViewModel);
        }
    }
}
