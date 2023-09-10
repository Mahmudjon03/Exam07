using Domain.Models;

namespace Infrcstructure.Servises;

public interface IQuoteServise
{
    Task<List<QuoteDto>> GetQuote();
    Task<QuoteDto> AddQuote(QuoteDto quoteDto);
    Task<string> Update(QuoteDto q);
    Task<string> Delete(int i);
    Task<QuoteDto> GetById(int i);
     Task<QuoteDto> RandomQuote();
     Task<List<QuoteSumImages>> GetQuoteSumIamged();
     

}
