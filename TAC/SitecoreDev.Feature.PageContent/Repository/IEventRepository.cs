using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreDev.Feature.PageContent.Repository
{
    public interface IEventRepository
    {
        Sitecore.Data.Items.Item GetItem(string contentGuid);
    }
}
