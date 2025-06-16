namespace pazio_test2.API.DTO;

public class GetCharacterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<GetBackpackItemDto> BackpackItems { get; set; } = new List<GetBackpackItemDto>();
    public List<GetTitleDto> Titles { get; set; } = new List<GetTitleDto>();
}