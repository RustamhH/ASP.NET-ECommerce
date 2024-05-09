
using Lesson_9_OnlineStore_DataAccess.Reposiotries.Abstracts;
using Lesson_9_OnlineStore_DataAccess.Reposiotries.Concretes;
using Lesson_9_OnlineStore_Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Lesson_9_OnlineStore_MVC.Controllers;

public class CategoryController : Controller
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _TagRepository;

    public CategoryController(ICategoryRepository categoryRepository, ITagRepository tagRepository)
    {
        _categoryRepository = categoryRepository;
        _TagRepository = tagRepository;
    }

    [HttpGet]
    public IActionResult AddCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        bool exist = false;
        foreach (var item in await _categoryRepository.GetAllAsync())
        {
            if(item.Name==category.Name)
            {
                exist = true;
            }   
        }
        if(!exist)
        {
            await _categoryRepository.AddAsync(category);
        }
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCategory()
    {
        var categories = await _categoryRepository.GetAllAsync();
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
}
