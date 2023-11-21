using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MediatR;
using System.Diagnostics;
using TestApp.Mvc.Models;
using System;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TestApp.Application.Machines.Queries.GetMachineDetails;

namespace TestApp.Mvc.Controllers
{
    public class MachineController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IMapper _mapper;

        public MachineController(IMapper mapper) => _mapper = mapper;

        [HttpGet]        
        public async Task<ActionResult<MachineDetailsVm>> GetMachine()
        {
            var query = new GetMachineDetailsQuery
            {
                Logoff = true,
                Id = 1
            };
            var vm = await Mediator.Send(query);
           return View(vm);
        }
       
        [HttpGet]
        public async Task<ActionResult<MachineDetailsVm>> GetMachineAdmin(int p)
        {
           
                var query = new GetMachineDetailsQuery
                {
                    Pass = p,
                    Id = 1
                };
                var vm = await Mediator.Send(query);

                return View(vm);
           
        }
    }
}
