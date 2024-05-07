using Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;
using Lesson_9_OnlineStore_DataAccess.Reposiotries.Concretes;
using Lesson_9_OnlineStore_Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Lesson_9_OnlineStore_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ITagRepository _TagRepository;

        public ProductController(IProductRepository productRepository, ITagRepository tagRepository)
        {
            _productRepository = productRepository;
            _TagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productRepository.AddAsync(product);
            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var categories = await _productRepository.GetAllAsync();
            return View(categories);
        }



        [HttpGet]
        public IActionResult RemoveProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(Product product)
        {
            await _productRepository.DeleteAsync(product.Id);
            return View(product);
        }


























        //[HttpGet]
        //public async Task<IActionResult> AddTag(int id)
        //{
        //    var category = await _productRepository.GetByIdAsync(id);
        //    ViewBag.Tags = await _TagRepository.GetAllAsync();
        //    return View(category);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddTag(int id, int[] tags)
        //{
        //    var category = await _productRepository.GetByidWithTags(id);

        //    foreach (var tagId in tags)
        //    {
        //        var tag = await _TagRepository.GetByIdAsync(tagId);
        //        category.Tags.Add(tag);
        //    }

        //    await _productRepository.SaveChanges();
        //    return RedirectToAction("AddTag");
        //}


        public IActionResult Index()
        {
            return View();
        }
    }
}
