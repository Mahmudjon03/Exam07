namespace Infrcstructure.Servises.Category;
using Domain.Models;
public interface ICategoryServise
{
    Task<List<Category>> Get();
    Task<string> Add(Category category);
    Task<string> Update(Category q);
    Task<string> Delete(int i);
    Task<Category> GetById(int i);
    
}
