using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TestApp.Application.Common.Mappings;
using TestApp.Application.Drinks.Commands.CreateDrink;


namespace TestApp.Mvc.Models
{
    public class CreateDrinkDto : IMapWith<CreateDrinkCommand>
    {
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public IFormFile? Avatar { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDrinkDto, CreateDrinkCommand>()
                .ForMember(drinkCommand => drinkCommand.Name,
                    opt => opt.MapFrom(drinkDto => drinkDto.Name))
                .ForMember(drinkCommand => drinkCommand.Price,
                    opt => opt.MapFrom(drinkDto => drinkDto.Price))
                .ForMember(drinkCommand => drinkCommand.Quantity,
                    opt => opt.MapFrom(drinkDto => drinkDto.Quantity))
                .ForMember(drinkCommand => drinkCommand.Avatar,
                    opt => opt.MapFrom(drinkDto => drinkDto.Avatar));
        }
    }
}
