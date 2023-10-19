namespace Core.DtoModels;

public class DtoGameModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DtoPublisherModel Publisher { get; set; } = null!;
    public ICollection<DtoGenreModel> Genres { get; set; }

    public DtoGameModel()
    {
        Genres = new List<DtoGenreModel>();
    }
}
