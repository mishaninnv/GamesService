namespace Core.Game.Models.Response;

public class GameModelResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Dictionary<int, string> Publisher { get; set; }
    public List<Dictionary<int, string>> Genres { get; set; }

    public GameModelResponse()
    { 
        Publisher = new Dictionary<int, string>();
        Genres = new List<Dictionary<int, string>>();
    }
}
