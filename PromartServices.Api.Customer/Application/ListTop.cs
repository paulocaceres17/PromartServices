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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace PromartServices.Api.Customer.Application
{
    public class ListTop
    {
        public class ExecuteListTop : IRequest<List<ClientDto>> { }

        public class ExecuteListTopHandler : IRequestHandler<ExecuteListTop, List<ClientDto>>
        {
            private readonly Context _context;
            private readonly IMapper _mapper;

            public ExecuteListTopHandler(Context context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            /**
             * Listar los 3 clientes con mayor edad
             **/
            public async Task<List<ClientDto>> Handle(ExecuteListTop request, CancellationToken cancellationToken)
            {
                var clients = _context.Customer.OrderBy(x => x.Birthdate).Take(3);

                var clientsDto = _mapper.Map<List<ClientDto>>(clients);

                foreach (ClientDto clientDto in clientsDto)
                    clientDto.edad = Utils.Utils.ObtenerEdad(clientDto.fecha_nacimiento);

                return clientsDto;
            }

        }


    }
}
