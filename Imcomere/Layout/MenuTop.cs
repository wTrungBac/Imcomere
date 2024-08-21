namespace Imcomere.Layout
{
    public class MenuTop
    {
        public List<MenuItem> lefts { get; set; }
        public List<MenuItem> rights { get; set; }

        public class MenuItem
        {
            public string name { get; set; }
            public string link { get; set; }
            public List<Item> items { get; set; }
        }

        public class Item
        {
            public string name { get; set; }
            public string link { get; set; }
        }
    }
}
