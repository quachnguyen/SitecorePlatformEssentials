using Sitecore.Data.Items;

namespace SitecoreDev.Feature.PageContent.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly Sitecore.Data.Database database;
        public EventRepository()
        {
            database = Sitecore.Context.Database;
        }
        public Item GetItem(string contentGuid)
        {
            return database.GetItem(new Sitecore.Data.ID(contentGuid));
        }
    }
}