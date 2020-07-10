using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEventsDemo.Models
{
    public class Tag
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Event> Events { get; set; }

        public Tag()
        {
        }

        public Tag(string name)
        {
            Name = name;
        }
    }
}
