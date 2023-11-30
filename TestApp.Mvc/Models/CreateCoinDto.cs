using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TestApp.Application.Common.Mappings;
using TestApp.Application.Coins.Commands.CreateCoin;

namespace TestApp.Mvc.Models
{
    public class CreateCoinDto : IMapWith<CreateCoinCommand>
    {
        [Required]

        public int Value { get; set; }
        public bool OnClientBalance { get; set; }
        public bool Blocked { get; set; }
        public int ClientBalance { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCoinDto, CreateCoinCommand>()
                
                .ForMember(coinCommand => coinCommand.Value,
                    opt => opt.MapFrom(coinDto => coinDto.Value))
                .ForMember(coinCommand => coinCommand.OnClientBalance,
                    opt => opt.MapFrom(coinDto => coinDto.OnClientBalance));
        }
    }
}
