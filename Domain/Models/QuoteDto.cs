namespace Domain.Models;

public class QuoteDto
{
    public int id { get; set; }
    public string? quote_text { get; set; }
    public int category_id { get; set; }
}
