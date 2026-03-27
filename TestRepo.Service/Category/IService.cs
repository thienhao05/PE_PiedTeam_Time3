namespace TetPee.Service.Category;

public interface IService
{
    public Task<string> GetCategory(Request.GetCategoryRequest request);
}