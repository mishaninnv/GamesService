namespace Core.DtoModels;

public class DtoGenreModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<DtoGameModel> Games { get; set; }

    public DtoGenreModel()
    {
        Games = new HashSet<DtoGameModel>();
    }
}
