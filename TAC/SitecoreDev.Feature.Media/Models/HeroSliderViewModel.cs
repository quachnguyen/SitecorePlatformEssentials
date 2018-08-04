using System.Collections.Generic;
using System.Linq;

namespace SitecoreDev.Feature.Media.Models
{
    public class HeroSliderViewModel
    {
        public List<HeroSliderImageViewModel> HeroSilderImages { get; set; } = new List<HeroSliderImageViewModel>();
        public int ImageCount  => HeroSilderImages.Count();
        public bool HasImage => ImageCount > 0;
    }
}