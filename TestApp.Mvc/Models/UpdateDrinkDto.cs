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
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Price,
                    opt => opt.MapFrom(noteDto => noteDto.Price))
                .ForMember(noteCommand => noteCommand.Quantity,
                    opt => opt.MapFrom(noteDto => noteDto.Quantity));
        }
    }
}
