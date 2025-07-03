using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;

namespace ShowTime.BusinessLogic.Abstractions;

public interface IArtistService : IEntityService<ArtistGetDto, ArtistCreateDto>
{
    Task<List<ArtistGetDto>> FilterByGenreAsync(int genreId);
    Task<List<ArtistGetDto>> SearchByNameAsync(string name);
}