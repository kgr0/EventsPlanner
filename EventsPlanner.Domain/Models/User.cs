using EventsPlanner.Domain.Interfaces;
using System.Collections.Generic;

namespace EventsPlanner.Domain.Models
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
    }
}
