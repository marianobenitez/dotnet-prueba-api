﻿using Andreani.Arq.Pipeline.Clases;
using PruebaAPI.Application.Common.Interfaces;
using PruebaAPI.Domain.Common;
using PruebaAPI.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaAPI.Application.UseCase.V1.PersonOperation.Queries.GetByName
{
    public class GetPersonByName : IRequest<Response<Person>>
    {
      public required string Name { get; set; }
    }

    public class GetPersonByNameHandler(IQuerySqlServer query) : IRequestHandler<GetPersonByName, Response<Person>>
    {
        public async Task<Response<Person>> Handle(GetPersonByName request, CancellationToken cancellationToken)
        {
            var person = await query.GetPersonByNameAsync(request.Name);

            var response = new Response<Person>();
            if (person == null)
            {
              response.AddNotification("#3123", nameof(request.Name), string.Format(ErrorMessage.NOT_FOUND_RECORD, nameof(Person), request.Name));
              response.StatusCode = System.Net.HttpStatusCode.NotFound;
              return response;
            }

            response.Content = person;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}

