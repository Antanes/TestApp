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
                .ForMember(machineDto => machineDto.Id,
                    opt => opt.MapFrom(machine => machine.Id))
                .ForMember(machineDto => machineDto.ClientBalance,
                    opt => opt.MapFrom(machine => machine.ClientBalance))
                .ForMember(machineDto => machineDto.Coin1quantity,
                    opt => opt.MapFrom(machine => machine.Coin1quantity))
                .ForMember(machineDto => machineDto.Coin2quantity,
                    opt => opt.MapFrom(machine => machine.Coin2quantity))
                .ForMember(machineDto => machineDto.Coin5quantity,
                    opt => opt.MapFrom(machine => machine.Coin5quantity))
                .ForMember(machineDto => machineDto.Coin10quantity,
                    opt => opt.MapFrom(machine => machine.Coin10quantity))
                .ForMember(machineDto => machineDto.Change,
                    opt => opt.MapFrom(machine => machine.Change))
                .ForMember(machineDto => machineDto.Drinks,
                    opt => opt.MapFrom(machine => machine.Drinks))
                .ForMember(machineDto => machineDto.Login,
                    opt => opt.MapFrom(machine => machine.Login))
                .ForMember(machineDto => machineDto.Coins,
                    opt => opt.MapFrom(machine => machine.Coins));

        }
    }
}
