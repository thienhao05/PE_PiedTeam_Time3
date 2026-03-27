using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Category;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IService _categoryService;
    public CategoryController(IService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("")]
    public async Task<IActionResult> GetCategory(Request.GetCategoryRequest request)
    {
        var category = await _categoryService.CreateCategory(request);
        return Ok(category);
    }
    
}