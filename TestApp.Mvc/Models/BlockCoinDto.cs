﻿using AutoMapper;
using TestApp.Application.Coins.Commands.BlockCoin;
using TestApp.Application.Coins.Commands.CreateCoin;
using TestApp.Application.Common.Mappings;

namespace TestApp.Mvc.Models
{
    public class BlockCoinDto : IMapWith<BlockCoinCommand>
    {
        public int Value { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlockCoinDto, BlockCoinCommand>()

                .ForMember(noteCommand => noteCommand.Value,
                    opt => opt.MapFrom(noteDto => noteDto.Value));
                
        }
    }
}
