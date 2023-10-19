using AutoMapper;
using Core.DtoModels;
using Core.Game.Models.Request;
using Core.Game.Models.Response;

namespace Logic.Game;

public class GameProfile : Profile
{
    public GameProfile() 
    {
        CreateMap<GameModelRequest, DtoGameModel>()
            .ForMember(to => to.Id, from => from.MapFrom(src => src.Id))
            .ForMember(to => to.Name, from => from.MapFrom(src => src.Name))
            .ForMember(to => to.Publisher, from => from.MapFrom(src => new DtoPublisherModel() { Id = src.Publisher }))
            .ForMember(to => to.Genres, from => from.MapFrom(src => src.Genres.Select(x => new DtoGenreModel() { Id = x }).ToList()));

        CreateMap<DtoGameModel, GameModelResponse>()
            .ForMember(to => to.Id, from => from.MapFrom(src => src.Id))
            .ForMember(to => to.Name, from => from.MapFrom(src => src.Name))
            .ForMember(to => to.Publisher, from => from.MapFrom(src => new Dictionary<int, string>() { { src.Publisher.Id, src.Publisher.Name } } ))
            .ForMember(to => to.Genres, from => from.MapFrom(src => src.Genres.Select(x => new Dictionary<int, string>() { { x.Id, x.Name} }).ToList()));
    }
}
