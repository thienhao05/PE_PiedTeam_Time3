namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.GetCategoryRequest request);
    
    public Task<List<Response.GetAllCategoryResponse>> GetAllCategories();
}