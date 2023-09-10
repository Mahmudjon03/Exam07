using Infrcstructure.Date;
using Infrcstructure.Servises;
using Infrcstructure.Servises.Category;
using Infrcstructure.Servises.File;
using Infrcstructure.Servises.QuoteImeges;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IFileServise,FileServise>();
builder.Services.AddSingleton<ICategoryServise,CategoryServise>();
builder.Services.AddSingleton<IQuoteImeges,QuoteImegesServise>();
//builder.Services.AddSingleton<IQuoteServise,QuoteServise>();
builder.Services.AddSingleton<DateContect>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
