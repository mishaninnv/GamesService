namespace Core.Game.Models.Request;

public class GameModelRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Publisher { get; set; }
    public List<int> Genres { get; set; }

    public GameModelRequest()
    { 
        Genres = new List<int>();
    }
}
