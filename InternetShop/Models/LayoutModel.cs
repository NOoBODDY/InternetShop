namespace InternetShop.Models
{
    public class LayoutModel
    {
        public bool Active { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Title { get; set; }

        public static List<LayoutModel> Generate(string ActiveName = null)
        {
            List<LayoutModel> layouts = new List<LayoutModel>();
            layouts.Add(new LayoutModel { Action = "Index", Controller = "Home", Title = "Home", Active = false });
            layouts.Add(new LayoutModel { Action = "Index", Controller = "Home", Title = "Shop", Active = false });
            layouts.Add(new LayoutModel { Action = "Index", Controller = "Home", Title = "Product", Active = false });
            layouts.Add(new LayoutModel { Action = "Index", Controller = "Home", Title = "Cart", Active = false });
            layouts.Add(new LayoutModel { Action = "Index", Controller = "Seller", Title = "Seller", Active = false });
            if (ActiveName!= null)
            {
                layouts.First(x => x.Title == ActiveName).Active = true;
            }
            
            return layouts;
        }
    }
}
