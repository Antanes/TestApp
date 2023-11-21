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
                
                .ForMember(noteCommand => noteCommand.Value,
                    opt => opt.MapFrom(noteDto => noteDto.Value))
                .ForMember(noteCommand => noteCommand.OnClientBalance,
                    opt => opt.MapFrom(noteDto => noteDto.OnClientBalance));
        }
    }
}
