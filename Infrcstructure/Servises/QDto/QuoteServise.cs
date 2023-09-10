using System.Security.Cryptography;
using Dapper;
using Domain.Models;
using Infrcstructure.Date;
using Infrcstructure.Servises.File;
namespace Infrcstructure.Servises;

public class QuoteServise : IQuoteServise
{
    private readonly DateContect _context;
    private readonly IFileServise _fileServise;
    public QuoteServise(DateContect context,FileServise fileServise)
    {
        _context = context;

        _fileServise = fileServise;

    }




    public async Task<List<QuoteDto>> GetQuote()
    {
        using  var con=_context.CreateConnection();
        var sql=$"select * from quotes";
        var response =await con.QueryAsync<QuoteDto>(sql);
        return response.ToList();
    }

    public async Task<QuoteDto> AddQuote(QuoteDto quoteDto)
    {
          using var con = _context.CreateConnection();
        var sql = $"insert into quotes(quote_text,category_id)values('{quoteDto.quote_text}',{quoteDto.category_id})";
        var res =await con.ExecuteAsync(sql);
        
        
            return quoteDto;
        
         
    }

    public async  Task<string> Update(QuoteDto q)
    {
        using var con =_context.CreateConnection();
       var sql=$"update quotes set quote_text='{q.quote_text}' where id={q.id}";
       var resalt=await con.ExecuteAsync(sql);
       if (resalt!=0)
       {
        return "Quote Update";
       }
       return "Error";
    }

    public async Task<string> Delete(int i)
    {
       using var con= _context.CreateConnection();
       var sql= $"delete from quotes where id={i}";
       var  res = await con.ExecuteAsync(sql);
       if (res!=0)
       {
        return "Quote Delete";
       }
       return "Error";

    }

    public async Task<QuoteDto> GetById(int i)
    {
       using var con =_context.CreateConnection();
       var sql =$"select * from quotes where id={i}";
       var res= await con.QueryFirstOrDefaultAsync<QuoteDto>(sql);
       return res ;
    }
    public async Task<QuoteDto> RandomQuote(){
        using var con =_context.CreateConnection();
       var sql =$"select * from quotes ordey by random() limit 1";
       var res= await con.QueryFirstOrDefaultAsync<QuoteDto>(sql);
       return res ;  
    }

    public Task<List<QuoteSumImages>> GetQuoteSumIamged()
    {
        throw new NotImplementedException();
    }

}
