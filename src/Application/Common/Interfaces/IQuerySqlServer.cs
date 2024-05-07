using Andreani.Arq.Core.Interface;
using PruebaAPI.Domain.Entities;
using System.Threading.Tasks;

namespace PruebaAPI.Application.Common.Interfaces;

    public interface IQuerySqlServer: IReadOnlyQuery
    {
        public Task<Person> GetPersonByNameAsync(string name);
    }
