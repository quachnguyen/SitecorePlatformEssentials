using Sitecore.Data.Items;
using System;

namespace SitecoreDev.Feature.Media.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly Sitecore.Data.Database database;
        public MediaRepository()
        {
            database = Sitecore.Context.Database;
        }
        public Item GetItem(string contentGuid)
        {
            return database.GetItem(new Sitecore.Data.ID(contentGuid));
        }
    }
}