namespace Infrcstructure.Servises.QuoteImeges;
using Domain.Models;

public interface IQuoteImeges
{
      Task<List<QuoteImages>> Get();
    Task<string> Add(QuoteImegesAdd q);
    Task<string> Update(QuoteImages q);
    Task<string> Delete(int i);
    Task<QuoteImages> GetById(int i);
}
