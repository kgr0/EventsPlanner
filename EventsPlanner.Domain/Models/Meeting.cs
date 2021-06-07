using EventsPlanner.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace EventsPlanner.Domain.Models
{
    public class Meeting : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
