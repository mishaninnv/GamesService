using Core.DtoModels;
using Core.Game.Models.Request;

namespace Core.Interfaces;

/// <summary>
/// Интерфейс определяющий базовый репозиторий для работы с играми.
/// </summary>
public interface IDbRepository
{
    /// <summary>
    /// Получить все игры.
    /// </summary>
    /// <returns>Список игр.</returns>
    public List<DtoGameModel> GetAll();

    /// <summary>
    /// Получить одну игру.
    /// </summary>
    /// <param name="id">Ид игры в бд.</param>
    /// <returns></returns>
    public DtoGameModel? Get(int id);

    /// <summary>
    /// Создать новую игру в бд.
    /// </summary>
    /// <param name="game">Модель игры для запроса.</param>
    /// <returns>Модель созданной игры.</returns>
    public DtoGameModel Create(GameModelRequest game);

    /// <summary>
    /// Обновить данные об игре в бд.
    /// </summary>
    /// <param name="game">Модель игры для запроса (с обязательным Ид).</param>
    /// <returns>Модель обновленной игры.</returns>
    public DtoGameModel Update(GameModelRequest game);

    /// <summary>
    /// Удаление игры.
    /// </summary>
    /// <param name="id">Ид игры в бд.</param>
    public void Delete(int id);
}
