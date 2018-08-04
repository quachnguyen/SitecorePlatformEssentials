using System.Collections.Generic;
using System.Linq;

namespace SitecoreDev.Feature.PageContent.Models
{
    public class EventListViewModel
    {
        public List<EventList> Events { get; set; } = new List<EventList>();
        public int EventCount => Events.Count();
        public bool HasEvents => EventCount > 0;
    }
}