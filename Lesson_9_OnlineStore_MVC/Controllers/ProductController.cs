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
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTag(Tag tag)
        {
            bool exist = false;
            foreach (var item in await _TagRepository.GetAllAsync())
            {
                if (item.Name == tag.Name)
                {
                    exist = true;
                }
            }
            if (!exist)
            {
                await _TagRepository.AddAsync(tag);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _TagRepository.GetAllAsync();
            return View(tags);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
