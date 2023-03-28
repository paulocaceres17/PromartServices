using FluentValidation;
using MediatR;
using PromartServices.Api.Customer.Model;
using PromartServices.Api.Customer.Persistence;
using System.Threading.Tasks;
using System.Threading;
using System;
using PromartServices.Api.Customer.Dto;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Identity;

namespace PromartServices.Api.Customer.Application
{
    public class List
    {
        public class ExecuteList : IRequest<List<ClientDto>> { }

        public class ExecuteListHandler : IRequestHandler<ExecuteList, List<ClientDto>>
        {
            private readonly Context _context;
            private readonly IMapper _mapper;

            public ExecuteListHandler(Context context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            /**
             * Listar Clientes (todos los datos más edad)
             **/
            public async Task<List<ClientDto>> Handle(ExecuteList request, CancellationToken cancellationToken)
            {
                var clients = await _context.Customer.ToListAsync();
                var clientsDto = _mapper.Map<List<ClientDto>>(clients);

                foreach (ClientDto clientDto in clientsDto)
                    clientDto.edad = Utils.Utils.ObtenerEdad(clientDto.fecha_nacimiento);

                return clientsDto;
            }

        }


    }
}
