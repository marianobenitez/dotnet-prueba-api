using Andreani.Arq.Cqrs.Command;
using Andreani.Arq.Cqrs.Interfaces;
using PruebaAPI.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace PruebaAPI.Infrastructure.Services
{
    public class CommandSqlServer([FromKeyedServices("default")] ITransactionalConfiguration config) : TransactionalRepository(config), ICommandSqlServer
    {
    }
}
