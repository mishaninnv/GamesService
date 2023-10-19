using AutoMapper;
using Core.Game.Models.Request;
using Core.Game.Models.Response;
using Core.Interfaces;

namespace Logic.Game;

/// <summary>
/// Класс отвечающий за логику работы с играми.
/// </summary>
public class GameManager
{
    private IMapper _mapper;
    private IDbRepository _repository;

    public GameManager(IMapper mapper, IDbRepository repository) 
    {
        _mapper = mapper;
        _repository = repository;
    }

    public List<GameModelResponse> GetAllGames(int genreId = 0)
    {
        var gamesDto = _repository.GetAll();
        var games = _mapper.Map<List<GameModelResponse>>(gamesDto);
        return genreId == 0 ? games : games.Where(x => x.Genres.Any(y => y.Keys.Contains(genreId))).ToList(); ;
    }

    public GameModelResponse CreateGame(GameModelRequest request)
    {
        var gameDto = _repository.Create(request);
        return _mapper.Map<GameModelResponse>(gameDto);
    }

    public GameModelResponse UpdateGame(GameModelRequest request) 
    {
        var gameDto = _repository.Update(request);
        return _mapper.Map<GameModelResponse>(gameDto);
    }

    public void DeleteGame(int id) 
    {
        _repository.Delete(id);
    }
}
