namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.GetCategoryRequest request);
}