using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pazio_test2.API.Models;

[Table("CharacterTitle")]
[PrimaryKey(nameof(TitleId), nameof(CharacterId))]
public class CharacterTitle
{
    
    public int TitleId { get; set; }
    [ForeignKey(nameof(TitleId))]
    public Title Title { get; set; }
    
    public int CharacterId { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; }
    
    public DateTime AcquiredAt { get; set; }
}