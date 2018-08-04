using SitecoreDev.Feature.Media.Models;
using SitecoreDev.Feature.Media.Repositories;
using System.Web.Mvc;

namespace SitecoreDev.Feature.Media.Controllers
{
    public class MediaController : Controller
    {
        private readonly IMediaRepository mediaRepository;
        public MediaController()
        {
            mediaRepository = new MediaRepository();
        }
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

        public ActionResult HeroSilder()
        {
            var heroSliderImages = new HeroSliderViewModel();
            if (!string.IsNullOrEmpty(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource))
            {
                var sliderItem = mediaRepository.GetItem(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource);
                if (sliderItem != null)
                {
                    var images = new Sitecore.Data.Fields.MultilistField(sliderItem.Fields["Hero Images"]);

                    if (images != null)
                    {
                        var items = images.GetItems();
                        var itemCount = 0;
                        foreach (var item in items)
                        {
                            var mediaItem = (Sitecore.Data.Items.MediaItem)item;
                            heroSliderImages.HeroSilderImages.Add(new HeroSliderImageViewModel
                            {
                                ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem),
                                AltText = mediaItem.Alt,
                                IsActive = itemCount == 0
                            });
                            itemCount++;
                        }
                    }
                }
            }
            return View(heroSliderImages);
        }
    }
}