using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pazio_test2.API.Models;

[Table("Item")]
public class Item
{
    [Key]
    public int ItemId { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; }
}