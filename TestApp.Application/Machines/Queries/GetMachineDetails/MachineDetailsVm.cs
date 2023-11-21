using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Common.Mappings;
using TestApp.Domain;

namespace TestApp.Application.Machines.Queries.GetMachineDetails
{
    public class MachineDetailsVm : IMapWith<Machine>
    {
        public int Id { get; set; }
        public int ClientBalance { get; set; }
        public int Change { get; set; }
        public int Coin1quantity { get; set; }
        public int Coin2quantity { get; set; }
        public int Coin5quantity { get; set; }
        public int Coin10quantity { get; set; }
        public ICollection<Drink> Drinks { get; set; }
        public ICollection<Coin> Coins { get; set; }
        public bool Login { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Machine, MachineDetailsVm>()
                .ForMember(drinkDto => drinkDto.Id,
                    opt => opt.MapFrom(drink => drink.Id))
                .ForMember(drinkDto => drinkDto.ClientBalance,
                    opt => opt.MapFrom(drink => drink.ClientBalance))
                .ForMember(drinkDto => drinkDto.Coin1quantity,
                    opt => opt.MapFrom(drink => drink.Coin1quantity))
                .ForMember(drinkDto => drinkDto.Coin2quantity,
                    opt => opt.MapFrom(drink => drink.Coin2quantity))
                .ForMember(drinkDto => drinkDto.Coin5quantity,
                    opt => opt.MapFrom(drink => drink.Coin5quantity))
                .ForMember(drinkDto => drinkDto.Coin10quantity,
                    opt => opt.MapFrom(drink => drink.Coin10quantity))
                .ForMember(drinkDto => drinkDto.Change,
                    opt => opt.MapFrom(drink => drink.Change))
                .ForMember(drinkDto => drinkDto.Drinks,
                    opt => opt.MapFrom(drink => drink.Drinks))
                .ForMember(drinkDto => drinkDto.Login,
                    opt => opt.MapFrom(drink => drink.Login))
                .ForMember(drinkDto => drinkDto.Coins,
                    opt => opt.MapFrom(drink => drink.Coins));

        }
    }
}
