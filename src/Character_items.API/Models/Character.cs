using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pazio_test2.API.Models;

[Table("Character")]
public class Character
{
    [Key]
    public int CharacterId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
    public ICollection<CharacterTitle> CharacterTitles { get; set; }
}