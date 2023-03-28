using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using PromartServices.Api.Customer.Application;
using System.Collections.Generic;
using PromartServices.Api.Customer.Dto;

namespace PromartServices.Api.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        /**
         * Crear Cliente
         **/
        [HttpPost("crear")]
        public async Task<ActionResult<Unit>> Crear(Add.ExecuteAdd data)
        {
            return await _mediator.Send(data);
        }


        /**
         * Listar Clientes (todos los datos más edad)
         **/
        [HttpGet("listar")]
        public async Task<ActionResult<List<ClientDto>>> Listar()
        {
            return await _mediator.Send(new List.ExecuteList());
        }


        /**
         * Listar los 3 clientes con mayor edad
         **/
        [HttpGet("listartop")]
        public async Task<ActionResult<List<ClientDto>>> ListarTop()
        {
            return await _mediator.Send(new ListTop.ExecuteListTop());
        }


        /**
         * Obtener cliente específico por Id (todos los datos más edad)
         **/
        [HttpGet("obtener/{id}")]
        public async Task<ActionResult<ClientDto>> Obtener(Guid id)
        {
            return await _mediator.Send(new Get.ExecuteGet { cliente_id = id });
        }






    }
}
