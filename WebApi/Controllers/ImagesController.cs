using System.Formats.Asn1;
using Domain.Models;
using Infrcstructure.Servises.QuoteImeges;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController:ControllerBase
{
    private readonly IQuoteImeges quoteImeges;


    public ImagesController(IQuoteImeges quoteImeges)
    {
        this.quoteImeges = quoteImeges;

    }
[HttpPost("Add")]
public async Task<string> Add([FromForm]QuoteImegesAdd q) =>await quoteImeges.Add(q);
[HttpGet("Get")]
public async  Task<List<QuoteImages>> GetImages()=> await quoteImeges.Get();
    [HttpPut("Update")]
 public async Task<string> Update(QuoteImegesAdd q) => await quoteImeges.Update(q);
    [HttpDelete ("Delete")]
    public async Task<string> Delete(int id) => await quoteImeges.Delete(id);
    [HttpGet("GetByid")]
   public async Task<QuoteImages> GetById(int i)=> await quoteImeges.GetById(i);

}
