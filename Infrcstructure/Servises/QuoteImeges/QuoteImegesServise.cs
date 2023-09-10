using Dapper;
using Domain.Models;
using Infrcstructure.Date;
using Infrcstructure.Servises.File;

namespace Infrcstructure.Servises.QuoteImeges;

public class QuoteImegesServise : IQuoteImeges
{
    private readonly DateContect contect;
    private readonly IFileServise _fileServise;

    


    public QuoteImegesServise(DateContect contect, IFileServise fileServise)
    {
        this.contect = contect;
        _fileServise = fileServise;
    }
     public async Task<string> Add(QuoteImegesAdd q)
    {
       using var con=contect.CreateConnection();
       var sql = $"insert into quoteimages(image_name,quote_id)values('{q.File?.FileName}',{q.quote_id}) ";
       if(q.File != null){
      await _fileServise.CreateFile("images", q.File);
        }
        var res =await con.ExecuteAsync(sql);
        if(res!=0){
         return "Images Add";
        }
        return "Error";
    }

    public async Task<string> Delete(int i)
    {
        using var con= contect.CreateConnection();
        var sql=$"delete from quotes where id={i}";
      var res =await con.ExecuteAsync(sql);
      if(res!=0){
        return "Images delete";
      }
      return "Error";
    }

    public async Task<List<QuoteImages>> Get()
    {
      using var con= contect.CreateConnection();
      var sql="select * from quoteimages";
      var res =await con.QueryAsync<QuoteImages>(sql);
      return res.ToList();
    }

    public async Task<QuoteImages> GetById(int i)
    {
         using var con= contect.CreateConnection();
      var sql=$"select * from quoteimages where id={i}";
      var res =await con.QueryFirstOrDefaultAsync<QuoteImages>(sql);
      return res;
    }

   
    public Task<string> Update(QuoteImages q)
    {
        throw new NotImplementedException();
    }
}
