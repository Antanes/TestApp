using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp.Mvc.Models;
using TestApp.Application.Drinks.Commands.CreateDrink;
using System;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using TestApp.Application.Drinks.Commands.DeleteDrink;
using TestApp.Application.Drinks.Commands.UpdateDrink;

using TestApp.Application.Coins.Commands.CreateCoin;
using TestApp.Application.Drinks.Commands.BuyDrink;

namespace TestApp.Mvc.Controllers
{
    public class DrinkController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IMapper _mapper;

        public DrinkController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public ActionResult<Guid> Create()
        {
            
                return PartialView();
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDrinkDto createDrinkDto)
        {
            var command = _mapper.Map<CreateDrinkCommand>(createDrinkDto);

            await Mediator.Send(command);
            return RedirectToAction("GetMachineAdmin", "Machine");
        }

        [HttpGet]
        public ActionResult<Guid> Update(UpdateDrinkDto updateDrinkDto, Guid id)
        {
            updateDrinkDto.Id = id;
            return PartialView(updateDrinkDto);

        }
        [HttpPost]        
        public async Task<IActionResult> Update(UpdateDrinkDto updateDrinkDto)
        {
            var command = _mapper.Map<UpdateDrinkCommand>(updateDrinkDto);            
            await Mediator.Send(command);
            return RedirectToAction("GetMachineAdmin", "Machine");
        }


        
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDrinkCommand
            {
                Id = id

            };
            await Mediator.Send(command);
            return RedirectToAction("GetMachineAdmin", "Machine");
        }

        
        public async Task<IActionResult> Buy(Guid id)
        {
            var command = new BuyDrinkCommand
            {
                Id = id

            };
            await Mediator.Send(command);
            return RedirectToAction("GetMachine", "Machine");
        }
    }
}