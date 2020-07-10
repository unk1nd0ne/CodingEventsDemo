using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult AddEvent(int id)
        {
            Event theEvent = context.Events.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();

            AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int eventId = viewModel.EventId;
                int tagId = viewModel.TagId;

                List<EventTag> existingTags = context.EventTags
                    .Where(et => et.EventId == eventId)
                    .Where(et => et.TagId == tagId)
                    .ToList();

                if (existingTags.Count == 0)
                {
                    EventTag eventTag = new EventTag
                    {
                        EventId = eventId,
                        TagId = tagId
                    };

                    context.EventTags.Add(eventTag);
                    context.SaveChanges();
                }
                
                return Redirect("/Events/Detail/" + eventId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            
            List<EventTag> eventTags = context.EventTags
                .Where(et => et.TagId == id)
                .Include(et => et.Event)
                .Include(et => et.Tag)
                .ToList();

            return View(eventTags);
        }
    }
}
