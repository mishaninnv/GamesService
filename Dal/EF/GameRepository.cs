using Core.DtoModels;
using Core.Game.Models.Request;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.EF;

public class GameRepository : IDbRepository
{
    private AppGameContext _context;

    public GameRepository(AppGameContext context)
    {
        _context = context;
    }

    public DtoGameModel Create(GameModelRequest game)
    {
        var publisher = GetPublisher(game.Publisher);
        if (publisher == null)
        {
            throw new Exception($"Не найден производитель по Id: {game.Publisher}");
        }

        var genres = GetGenres(game.Genres);
        if (genres.Count() != game.Genres.Count)
        {
            throw new Exception($"Некоторые идентификаторы жанров отсутствуют в бд.");
        }

        var gameModel = new DtoGameModel()
        {
            Id = game.Id,
            Name = game.Name,
            Publisher = publisher,
            Genres = genres
        };

        _context.Add(gameModel);
        _context.SaveChanges();
        return gameModel;
    }

    public void Delete(int id)
    {
        var game = Get(id);
        if (game == null)
        {
            throw new Exception($"В бд отсутствует игра с Id: {id}");
        }
        _context.Remove(game);
        _context.SaveChanges();
    }

    public DtoGameModel? Get(int id)
    {
        return _context.Games.Where(x => x.Id == id).Include(x => x.Publisher).Include(x => x.Genres).FirstOrDefault();
    }

    public List<DtoGameModel> GetAll()
    {
        return _context.Games.Include(x => x.Publisher).Include(x => x.Genres).ToList();
    }

    public DtoGameModel Update(GameModelRequest game)
    {
        var currGame = Get(game.Id);
        if (currGame == null)
        {
            throw new Exception($"В бд отсутствует игра с Id: {game.Id}");
        }

        var publisher = GetPublisher(game.Publisher);
        if (publisher == null)
        {
            throw new Exception($"Не найден производитель по Id: {game.Publisher}");
        }

        var genres = GetGenres(game.Genres);
        if (genres.Count() != game.Genres.Count)
        {
            throw new Exception($"Некоторые идентификаторы жанров отсутствуют в бд.");
        }

        currGame.Name = game.Name;
        currGame.Publisher = publisher;
        currGame.Genres = genres;

        _context.SaveChanges();
        return currGame;
    }

    private DtoPublisherModel? GetPublisher(int id) => _context.Publishers.FirstOrDefault(x => x.Id == id);
    private List<DtoGenreModel> GetGenres(List<int> ids) => _context.Genres.Where(x => ids.Contains(x.Id)).ToList();
}
