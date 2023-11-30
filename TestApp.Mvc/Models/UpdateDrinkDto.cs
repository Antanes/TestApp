using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TestApp.Application.Common.Mappings;
using TestApp.Application.Drinks.Commands.UpdateDrink;


namespace TestApp.Mvc.Models
{
    public class UpdateDrinkDto : IMapWith<UpdateDrinkCommand>
    {
        [Required]
        public Guid Id { get; set; }
        
        public int Price { get; set; }
        public int Quantity { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDrinkDto, UpdateDrinkCommand>()
                .ForMember(drinkCommand => drinkCommand.Id,
                    opt => opt.MapFrom(drinkDto => drinkDto.Id))
                .ForMember(drinkCommand => drinkCommand.Price,
                    opt => opt.MapFrom(drinkDto => drinkDto.Price))
                .ForMember(drinkCommand => drinkCommand.Quantity,
                    opt => opt.MapFrom(drinkDto => drinkDto.Quantity));
        }
    }
}
