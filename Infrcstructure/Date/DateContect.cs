using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Infrcstructure.Date;
public class DateContect
{
   private readonly IConfiguration? _configuration; 
   public DateContect(IConfiguration configuration) =>   _configuration = configuration;
    
    public IDbConnection CreateConnection() => new NpgsqlConnection(_configuration?.GetConnectionString("DefaultConnection"));
}

