namespace SitecoreDev.Feature.Media.Repositories
{
    public interface IMediaRepository
    {
        Sitecore.Data.Items.Item GetItem(string contentGuid);
    }
}
