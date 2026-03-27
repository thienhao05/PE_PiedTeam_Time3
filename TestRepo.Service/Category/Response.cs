namespace TetPee.Service.Category;

public class Response
{
    public class GetAllCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}