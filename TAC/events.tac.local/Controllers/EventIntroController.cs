using events.tac.local.Models;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class EventIntroController : Controller
    {
        // GET: EventIntro
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        public static EventIntro CreateModel()
        {
            var item = Sitecore.Mvc.Presentation.RenderingContext.Current.ContextItem;
            return new EventIntro
            {
                ContentHeading = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "ContentHeading")),
                ContentBody = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "ContentBody")),
                Highlight = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "Highlights")),
                EventImage = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "Event Image", "mw=400")),
                ContentIntro = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "ContentIntro")),
                StartDate = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "StartDate")),
                Duration = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "Duration")),
                DifficultyLevel = new HtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render(item, "DifficultyLevel"))
            };
        }
    }
}