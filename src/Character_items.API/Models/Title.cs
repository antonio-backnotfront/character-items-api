using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pazio_test2.API.Models;

[Table("Title")]
public class Title
{
    
    [Key]
    public int TitleId { get; set; }
    public string Name { get; set; }
    public ICollection<CharacterTitle> CharacterTitles { get; set; }
}