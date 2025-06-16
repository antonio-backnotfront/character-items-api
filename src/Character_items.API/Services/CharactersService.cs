using Microsoft.EntityFrameworkCore;
using pazio_test2.API.DAL;
using pazio_test2.API.DTO;
using pazio_test2.API.Exceptions;
using pazio_test2.API.Models;

namespace pazio_test2.API.Services;

public class CharactersService : ICharactersService
{
    private readonly CharactersDbContext _context;

    public CharactersService(CharactersDbContext context)
    {
        _context = context;
    }

    public async Task<GetCharacterDto?> GetCharacterByIdAsync(int id, CancellationToken cancellationToken)
    {
        var character = await _context.Characters
            .Include(c => c.Backpacks)
                .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
                .ThenInclude(c => c.Title)
            .FirstOrDefaultAsync(e => e.CharacterId == id, cancellationToken);
        if (character == null) return null;
        return new GetCharacterDto()
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks
                .Select(backpack => new GetBackpackItemDto()
                {
                    Amount = backpack.Amount,
                    ItemName = backpack.Item.Name,
                    ItemWeight = backpack.Item.Weight
                })
                .ToList(),
            Titles = character.CharacterTitles
                .Select(t => new GetTitleDto()
                {
                    AcquiredAt = t.AcquiredAt,
                    Title = t.Title.Name
                })
                .ToList()
        };
    }

    public async Task<int[]> AddItemToCharacterAsync(int id, int[] dto, CancellationToken cancellationToken)
    {
        var character = await _context.Characters
            .FirstOrDefaultAsync(c => c.CharacterId == id, cancellationToken);
        if (character == null)
            throw new NotFoundException($"Character with id {id} not found");

        var items = await _context.Items
            .Where(item => dto.Contains(item.ItemId))
            .ToListAsync(cancellationToken);

        if (items.Count != dto.Length)
            throw new NotFoundException("Some items were not found");

        int weight = items.Sum(item => item.Weight);
        if (character.CurrentWeight + weight > character.MaxWeight)
            throw new ExceedingLimitException($"The current total weight {character.CurrentWeight + weight} kg exceeds the limit of {character.MaxWeight}kg");

        character.CurrentWeight += weight;

        var existingBackpacks = await _context.Backpacks
            .Where(b => b.CharacterId == id)
            .ToDictionaryAsync(b => b.ItemId, cancellationToken);

        foreach (var item in items)
        {
            if (existingBackpacks.TryGetValue(item.ItemId, out var backpack))
            {
                backpack.Amount += 1;
            }
            else
            {
                await _context.Backpacks.AddAsync(new Backpack
                {
                    CharacterId = character.CharacterId,
                    ItemId = item.ItemId,
                    Amount = 1
                }, cancellationToken);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        return dto;
    }

}