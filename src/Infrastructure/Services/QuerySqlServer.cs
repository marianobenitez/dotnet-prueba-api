using Andreani.Arq.Cqrs.Interfaces;
using Andreani.Arq.Cqrs.Queries;
using PruebaAPI.Application.Common.Interfaces;
using PruebaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaAPI.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace PruebaAPI.Infrastructure.Services
{
    public class QuerySqlServer : ReadOnlyQuery, IQuerySqlServer
    {
        private readonly ApplicationDbContext _context;
        public QuerySqlServer([FromKeyedServices("default")] IReadOnlyQueryConfiguration config,
            [FromKeyedServices("default")] ApplicationDbContext context) : base(config)
        {
          _context = context;
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
          return await _context.Person.FirstAsync(x => x.Nombre == name);
        }
    }
}
