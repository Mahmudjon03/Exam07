namespace Domain.Models;

using Microsoft.AspNetCore.Http;



public class QuoteImegesAdd:QuoteImages
{
    public IFormFile? File { get; set; }
}

