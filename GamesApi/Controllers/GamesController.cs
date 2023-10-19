using Microsoft.AspNetCore.Mvc;
using Core.Game.Models.Response;
using Core.Game.Models.Request;
using Logic.Game;
using System.ComponentModel.DataAnnotations;

namespace GamesApi.Controllers;

[ApiController]
[Route("games")]
public class GamesController : ControllerBase
{
    private GameManager _manager;

    public GamesController(GameManager manager)
    {
        _manager = manager;
    }

    [ProducesResponseType(typeof(List<GameModelResponse>), 200)]
    [HttpGet]
    public IActionResult Get([FromQuery] int genre)
    {
        var result = _manager.GetAllGames(genre);
        return Ok(result);
    }

    [ProducesResponseType(typeof(GameModelResponse), 200)]
    [HttpPost]
    public IActionResult Post([FromBody] GameModelRequest game)
    {
        var result = _manager.CreateGame(game);
        return Ok(result);
    }

    [ProducesResponseType(typeof(GameModelResponse), 200)]
    [HttpPut]
    public IActionResult Put([FromBody] GameModelRequest game)
    {     
        var result = _manager.UpdateGame(game);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery, Required] int id)
    {
        _manager.DeleteGame(id);
        return Ok();
    }
}
