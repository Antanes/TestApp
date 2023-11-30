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
using TestApp.Application.Coins.Commands.BlockCoin;

namespace TestApp.Mvc.Controllers
{
    public class CoinController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IMapper _mapper;

        public CoinController(IMapper mapper) => _mapper = mapper;

      

        [HttpPost]
        public async Task<int> Create(CreateCoinDto createCoinDto, int value)
        {
            createCoinDto.Value = value;
            var command = _mapper.Map<CreateCoinCommand>(createCoinDto);

            await Mediator.Send(command);
            return command.Value;
        }

        [HttpPost]
        public async Task Block(BlockCoinDto blockCoinDto, int value)
        {
            blockCoinDto.Value = value;
            var command = _mapper.Map<BlockCoinCommand>(blockCoinDto);

            await Mediator.Send(command);
           
        }

    }
}