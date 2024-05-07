using PruebaAPI.Domain.Common;
using System.Threading.Tasks;

namespace PruebaAPI.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
