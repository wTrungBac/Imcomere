namespace Imcomere.Pages.Component
{
    public partial class Slider
    {
        public string id { get; set; }
        public List<Item> items { get; set; }
        public class Item
        {
            public string id { get; set; }
            public bool isActive { get; set; }
            public string href { get; set; }
            public string imageSrc { get; set; }
            public string title { get; set; }
            public bool isShowFullDescription { get; set; }
            public string shortDescription { get; set; }
            public string description { get; set; }

        }
    }
}
