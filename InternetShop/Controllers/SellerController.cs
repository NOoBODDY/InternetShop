using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using InternetShop.Models;
using Microsoft.EntityFrameworkCore;


namespace InternetShop.Controllers
{
    public class SellerController : Controller
    {
        private Context _context;
        IWebHostEnvironment _appEnvironment;
        public SellerController(Context context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }


        [Authorize(Roles = "seller")]
        public IActionResult Index()
        {
            Seller seller= _context.Users.Include(u => u.Seller).ThenInclude(c=> c!.Products).FirstOrDefault(x => x.Login == User.Identity.Name)?.Seller;

            ViewBag.SellerName =seller?.Name;
            return View(seller?.Products);
        }

        [Authorize(Roles = "seller")]
        public IActionResult Newproduct()
        {
            Seller seller = _context.Users.Include(u => u.Seller).FirstOrDefault(x => x.Login == User.Identity.Name)?.Seller;

            ViewBag.SellerName = seller?.Name;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(string FullName, string ShortName, IFormFile Image, string Description, string Cost)
        {
            Seller seller = _context.Users.Include(u => u.Seller).FirstOrDefault(x => x.Login == User.Identity.Name)?.Seller;
            Product product = new Product { FullName = FullName, Shortname = ShortName, Description = Description, Seller = seller };
            
            if (Image != null && seller != null)
            {
                // путь к папке Files
                Directory.CreateDirectory(_appEnvironment.WebRootPath + string.Format("/Files/{0}", seller.Name));
                string path = string.Format("/Files/{0}/{1}",seller.Name,Image.FileName);
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                product.ImagePath = path;  
            }
            ProductOnSell productOnSell = new ProductOnSell { Amount = 0, Cost = Convert.ToDecimal(Cost), Product = product, LastEdit = DateTime.Now };
            _context.ProductOnSells.Add(productOnSell);
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
