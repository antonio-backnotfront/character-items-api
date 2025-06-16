using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pazio_test2.API.Models;

[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
[Table("Backpack")]
public class Backpack
{
    
    public int CharacterId { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; }
    
    public int ItemId { get; set; }
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
    
    public int Amount { get; set; }
}