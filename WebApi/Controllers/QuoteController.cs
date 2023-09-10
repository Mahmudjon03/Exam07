using Domain.Models;
using Infrcstructure.Servises;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController:ControllerBase
{
    private readonly IQuoteServise _quote;

    public QuoteController(IQuoteServise quote)
  {
        _quote = quote;
    }


    [HttpGet("Quote")]
    public async  Task<List<QuoteDto>> Get()=>await _quote.GetQuote();
    [HttpPost("AddQuote")]
    public async Task<QuoteDto> AddQuote( QuoteDto quoteDto)=> await _quote.AddQuote(quoteDto);
    [HttpPut("Update")]
    public async Task<string> Update(QuoteDto q) => await _quote.Update(q);
    [HttpDelete ("Delete")]
    public async Task<string> Delete(int id) => await _quote.Delete(id);
    [HttpGet("GetByid")]
   public async Task<QuoteDto> GetById(int i)=> await _quote.GetById(i);
   [HttpGet("Random")]
   public async Task<QuoteDto> Random() =>await _quote.RandomQuote();
  }
