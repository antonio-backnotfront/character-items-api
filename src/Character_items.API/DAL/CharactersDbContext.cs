using Microsoft.EntityFrameworkCore;
using pazio_test2.API.Models;

namespace pazio_test2.API.DAL;

public class CharactersDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    
    public CharactersDbContext(DbContextOptions<CharactersDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item()
            {
                ItemId = 1,
                Name = "Item 1",
                Weight = 1
            },
            new Item()
            {
                ItemId = 2,
                Name = "Item 2",
                Weight = 2
            },
            new Item()
            {
                ItemId = 3,
                Name = "Item 3",
                Weight = 3
            });
        
        modelBuilder.Entity<Character>().HasData(
            new Character()
            {
                CharacterId = 1,
                FirstName = "Firstname 1",
                LastName = "Lastname 1",
                CurrentWeight = 0,
                MaxWeight = 3
            },
            new Character()
            {
                CharacterId = 2,
                FirstName = "Firstname 2",
                LastName = "Lastname 2",
                CurrentWeight = 0,
                MaxWeight = 8
            });
        
        modelBuilder.Entity<Title>().HasData(
            new Title()
            {
                TitleId = 1,
                Name = "Title 1",
            },
            new Title()
            {
                TitleId = 2,
                Name = "Title 2",
            },
            new Title()
            {
                TitleId = 3,
                Name = "Title 3",
            }
            );
        
        modelBuilder.Entity<CharacterTitle>().HasData(
            new CharacterTitle()
            {
                TitleId = 1,
                CharacterId = 1
            },
            new CharacterTitle()
            {
                TitleId = 2,
                CharacterId = 1
            },
            new CharacterTitle()
            {
                TitleId = 3,
                CharacterId = 2
            }
            );
        
        
        
        
        
        base.OnModelCreating(modelBuilder);
    }
}