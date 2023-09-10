
using Infrcstructure.Date;
using Domain.Models;
using Dapper;
namespace Infrcstructure.Servises.Category;

public class CategoryServise : ICategoryServise
{
    private readonly DateContect _constr;


    public CategoryServise(DateContect constr)
    {
        _constr = constr;

    }
    public async Task<string> Add(Domain.Models.Category category)
    {
        using var con=_constr.CreateConnection();
        var sql= $"insert into categories(category_name)values(' {category.category_name}')";
        var res =await con.ExecuteAsync(sql);
        
        return "Add Category";

    }

    public async Task<string> Delete(int i)
    {
         using var con =_constr.CreateConnection();
        var sql=$"delete from categories where id={i}";
        var res=await con.ExecuteAsync(sql);
         if(res!= 0 ){
            return "category delete";
        }
           return "Error";
    }

    public async Task<Domain.Models.Category> GetById(int i)
    { 
     using var con =_constr.CreateConnection();
    var sql =$"select * from categories where id={i}";
    var res=await con.QueryFirstOrDefaultAsync<Domain.Models.Category>(sql);
    return res;
       
    }

    async Task<List<Domain.Models.Category>> ICategoryServise.Get()
    {
         using var con =_constr.CreateConnection();
         var sql =$"select * from categories";
         var res =await con.QueryAsync<Domain.Models.Category>(sql);
         return res.ToList();
    }

    public async Task<string> Update(Domain.Models.Category q)
    {
        using var con =_constr.CreateConnection();
         var sql =$"update categories set category_name='{q.category_name} where id={q.id}'";
         var res =await con.ExecuteAsync(sql);
         if(res!=0){
            return "CAtegory Update";
         }
         return "Error";
       }
}
