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
                .ForMember(noteCommand => noteCommand.Name,
                    opt => opt.MapFrom(noteDto => noteDto.Name))
                .ForMember(noteCommand => noteCommand.Price,
                    opt => opt.MapFrom(noteDto => noteDto.Price))
                .ForMember(noteCommand => noteCommand.Quantity,
                    opt => opt.MapFrom(noteDto => noteDto.Quantity))
                .ForMember(noteCommand => noteCommand.Avatar,
                    opt => opt.MapFrom(noteDto => noteDto.Avatar));
        }
    }
}
