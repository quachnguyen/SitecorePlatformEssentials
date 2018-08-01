using System.Web.Mvc;

namespace SitecoreDev.Feature.Media.Controllers
{
    public class MediaController : Controller
    {
        // GET: Default
        public ActionResult HeroSliderView()
        {
            Sitecore.Data.Items.Item heroSlider = null;
            var database = Sitecore.Context.Database;
            if (database != null && Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource != null)
            {
                heroSlider = database.GetItem(new Sitecore.Data.ID(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource));
            }
            return View(heroSlider);
        }
    }
}