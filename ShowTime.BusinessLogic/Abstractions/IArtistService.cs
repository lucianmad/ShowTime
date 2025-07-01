using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IArtistService
{
    Task<ArtistGetDto> GetArtistByIdAsync(int id);
    Task<IList<ArtistGetDto>> GetAllArtistsAsync();
    Task AddArtistAsync(ArtistCreateDto artist);
    Task UpdateArtistAsync(int id, ArtistCreateDto artist);
    Task DeleteArtistAsync(int id);
}