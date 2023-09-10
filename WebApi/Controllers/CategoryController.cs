using Microsoft.AspNetCore.Mvc;
using Infrcstructure.Servises.Category;
using Domain.Models;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryController:ControllerBase
{
    private readonly ICategoryServise _categoryServise;


    public CategoryController(ICategoryServise categoryServise)
    {
        _categoryServise = categoryServise;

    }
    [HttpGet("GetCategory")]
    public async Task<List<Category>> GetCategories()=>  await _categoryServise.Get();
    [HttpPost("AddCategory")]
    public async Task<string> Add(Category a)=>await _categoryServise.Add(a);
    [HttpPut("Update")]
     public Task<string> Update(Category q)=> _categoryServise.Update(q);
     [HttpDelete("Delete")]
     public  Task<string> Delete(int i) => _categoryServise.Delete(i);
     [HttpGet("GetbyId")]
    public Task<Category> GetById(int i)=> _categoryServise.GetById(i);
}
