using Core.DtoModels;
using Microsoft.EntityFrameworkCore;

namespace Dal.EF;

public class AppGameContext : DbContext
{
    public DbSet<DtoGameModel> Games { get; set; }
    public DbSet<DtoPublisherModel> Publishers { get; set; }
    public DbSet<DtoGenreModel> Genres { get; set; }

    public AppGameContext(DbContextOptions<AppGameContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DtoGenreModel>().HasData(
                new DtoGenreModel() { Id = 1, Name = "Aciton" },
                new DtoGenreModel() { Id = 2, Name = "Horror" },
                new DtoGenreModel() { Id = 3, Name = "Race" },
                new DtoGenreModel() { Id = 4, Name = "Adventures" }
            );

        modelBuilder.Entity<DtoPublisherModel>().HasData(
                new DtoPublisherModel() { Id = 1, Name = "Epic" },
                new DtoPublisherModel() { Id = 2, Name = "Electronic" },
                new DtoPublisherModel() { Id = 3, Name = "Sony" },
                new DtoPublisherModel() { Id = 4, Name = "Microsoft" }
            );

        base.OnModelCreating(modelBuilder);
    }
}
