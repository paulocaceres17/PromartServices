using AutoMapper;
using MediatR;
using PromartServices.Api.Customer.Dto;
using PromartServices.Api.Customer.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace PromartServices.Api.Customer.Application
{
    public class Get
    {
        public class ExecuteGet : IRequest<ClientDto>
        {
            public Guid cliente_id { get; set; }
        }

        public class ExecuteGetHandler : IRequestHandler<ExecuteGet, ClientDto>
        {
            private readonly Context _context;
            private readonly IMapper _mapper;

            public ExecuteGetHandler(Context context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            /**
             * Obtener cliente específico por Id (todos los datos más edad)
             **/
            public async Task<ClientDto> Handle(ExecuteGet request, CancellationToken cancellationToken)
            {
                var client = await _context.Customer.Where(x => x.ClientId == request.cliente_id).FirstOrDefaultAsync();
                
                if(client == null)
                    throw new Exception("No se encontró el cliente");

                var clientDto = _mapper.Map<ClientDto>(client);
                clientDto.edad = Utils.Utils.ObtenerEdad(clientDto.fecha_nacimiento);
                return clientDto;
            }
        }
    }
}
