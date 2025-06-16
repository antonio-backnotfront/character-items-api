using Microsoft.EntityFrameworkCore;
using pazio_test2.API.DAL;
using pazio_test2.API.DTO;

namespace pazio_test2.API.Services;

public interface ICharactersService
{
    public Task<GetCharacterDto?> GetCharacterByIdAsync(int id, CancellationToken cancellationToken);
    public Task<int[]> AddItemToCharacterAsync(int id, 
        int[] dto, 
        CancellationToken cancellationToken);
}