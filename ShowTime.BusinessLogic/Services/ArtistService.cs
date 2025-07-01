using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;

namespace ShowTime.BusinessLogic.Services;

public class ArtistService : IArtistService
{
    private readonly IRepository<Artist> _artistRepository;

    public ArtistService(IRepository<Artist> artistRepository)
    {
        _artistRepository = artistRepository;
    }
    
    public async Task<ArtistGetDto> GetArtistByIdAsync(int id)
    {
        try
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null)
            {
                throw new Exception($"Artist with id {id} not found");
            }
            return new ArtistGetDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Genre = artist.Genre,
                Image = artist.Image
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve artist with id {id}: {ex.Message}");
        }
    }
    
    public async Task<IList<ArtistGetDto>> GetAllArtistsAsync()
    {
        try
        {
            var artists = await _artistRepository.GetAllAsync();
            return artists.Select(artist => new ArtistGetDto
            {
                Id = artist.Id,
                Name = artist.Name,
                Genre = artist.Genre,
                Image = artist.Image
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve artists: {ex.Message}");
        }
    }

    public async Task AddArtistAsync(ArtistCreateDto artistCreateDto)
    {
        var artist = new Artist
        {
            Name = artistCreateDto.Name,
            Genre = artistCreateDto.Genre,
            Image = artistCreateDto.Image
        };
        try
        {
            await _artistRepository.AddAsync(artist);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to add artist: {ex.Message}");
        }
    }
    
    public async Task UpdateArtistAsync(int id, ArtistCreateDto artistCreateDto)
    {
        try
        {
            var artist = new Artist
            {
                Name = artistCreateDto.Name,
                Genre = artistCreateDto.Genre,
                Image = artistCreateDto.Image
            };
            await _artistRepository.UpdateAsync(id, artist);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update artist with id {id}: {ex.Message}");       
        }
    }
    
    public async Task DeleteArtistAsync(int id)
    {
        try
        {
            await _artistRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to delete artist with id {id}: {ex.Message}");
        }
    }
}