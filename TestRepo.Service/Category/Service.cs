using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateCategory(Request.GetCategoryRequest request)
    {
        var existingCate = _dbContext.Categories.Where(x => x.Name == request.Name);
        var isExistedCate = await existingCate.AnyAsync();
        if (isExistedCate)
            throw new Exception("Category already exists");
        var newCategory = new Repository.Entity.Category()
        {
            Name = request.Name,
            ParentId = request.ParentId
        };
        _dbContext.Add(newCategory);
        await _dbContext.SaveChangesAsync();
        return "Add Category successful";
    }

    public async Task<List<Response.GetAllCategoryResponse>> GetAllCategories()
    {
        var query = _dbContext.Categories.Where(x => true);
        query = query.OrderBy(x => x.Name);
        var selectedQuery = query.Select(x => new Response.GetAllCategoryResponse()
        {
            Name = x.Name,
            Id = x.Id,
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }
}