using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using PromartServices.Api.Customer.Persistence;
using PromartServices.Api.Customer.Model;
using System.Diagnostics.CodeAnalysis;

namespace PromartServices.Api.Customer.Application
{
    public class Add
    {
        public class ExecuteAdd : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime Birthdate { get; set; }
        }

        public class ExecuteAddValidation : AbstractValidator<ExecuteAdd>
        {
            public ExecuteAddValidation()
            {
                RuleFor(x => x.FirstName).NotEmpty().WithMessage("El nombre es obligatorio");
                RuleFor(x => x.LastName).NotEmpty().WithMessage("El apellido es obligatorio");
                RuleFor(x => x.Birthdate).NotEmpty().WithMessage("La fecha de nacimiento es obligatoria");
                RuleFor(x => x.Birthdate).LessThan(DateTime.Now.AddDays(-1)).WithMessage("La fecha de nacimiento no puede ser mayor a la fecha actual.");
            }
        }
        public class ExecuteAddHandler : IRequestHandler<ExecuteAdd>
        {
            private readonly Context _context;
            //private readonly IMapper mapper;

            public ExecuteAddHandler(Context context)
            {
                this._context = context;
            }

            /**
             * Crear Cliente
             **/
            public async Task<Unit> Handle(ExecuteAdd request, CancellationToken cancellationToken)
            {
                var client = new Client
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Birthdate = request.Birthdate
                };

                _context.Customer.Add(client);

                var value = await _context.SaveChangesAsync();

                if(value > 0)
                    return Unit.Value;

                throw new Exception("No se pudo insertar el cliente");
            }
        }





    }
}
