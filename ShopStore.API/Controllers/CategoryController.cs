using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopStore.API.Dto;
using ShopStore.Data.Models;
using ShopStore.Data.Repository.Contracts;

namespace ShopStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public IActionResult GetCategories()
    {
        var categories = _mapper.Map<IEnumerable<CategoryDto>>(_categoryRepository.GetCategories());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(categories);
    }
}

