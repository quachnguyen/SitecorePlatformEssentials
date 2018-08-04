using SitecoreDev.Feature.PageContent.Models;
using SitecoreDev.Feature.PageContent.Repository;
using System;
using System.Web.Mvc;

namespace SitecoreDev.Feature.PageContent.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventRepository eventRepository;
        public EventsController()
        {
            eventRepository = new EventRepository();
        }
        // GET: Events
        public ActionResult EventList()
        {
            var eventListViewModel = new EventListViewModel();
            //check if the data source is not null
            if (!String.IsNullOrEmpty(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource))
            {
                var datasource = Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource;
                var item = eventRepository.GetItem(datasource);
                if (item != null)
                {
                    var events = new Sitecore.Data.Fields.MultilistField(item.Fields["Event List"]);
                    if (events != null)
                    {
                        foreach (var e in events.Items)
                        {
                            var i = eventRepository.GetItem(e);
                            var dateTimeField = (Sitecore.Data.Fields.DateField)i.Fields["StartDate"];
                            eventListViewModel.Events.Add(new EventList
                            {
                                EventDate = i.Fields["StartDate"] == null ? DateTime.Now : Sitecore.DateUtil.IsoDateToDateTime(dateTimeField.Value),
                                EventTitle = i.Fields["ContentHeading"].Value
                            });
                        }
                    }
                }
            }
            return View(eventListViewModel);
        }
    }
}