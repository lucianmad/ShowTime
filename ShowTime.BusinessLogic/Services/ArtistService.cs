using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class ArtistService : GenericEntityService<Artist, ArtistGetDto, ArtistCreateDto>,IArtistService
{
    private readonly IArtistRepository _artistRepository;
    private readonly IGenreRepository _genreRepository;
    protected override string EntityName => "Artist";

    public ArtistService(IArtistRepository artistRepository, IGenreRepository genreRepository) : base(artistRepository)
    {
        _artistRepository = artistRepository;   
        _genreRepository = genreRepository;   
    }
    
    protected override ArtistGetDto MapToGetDto(Artist artist)
    {
        return new ArtistGetDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Genre = artist.Genre,
            GenreId = artist.GenreId,
            Image = artist.Image
        };
    }

    protected override Artist MapToEntityForCreate(ArtistCreateDto artistCreateDto)
    {
        return new Artist
        {
            Name = artistCreateDto.Name,
            GenreId = artistCreateDto.GenreId,
            Image = artistCreateDto.Image
        };   
    }

    protected override Artist MapToEntityForUpdate(ArtistCreateDto artistCreateDto, int id)
    {
        return new Artist
        {
            Id = id,
            Name = artistCreateDto.Name,
            GenreId = artistCreateDto.GenreId,
            Image = artistCreateDto.Image
        };  
    }

    public async Task<List<ArtistGetDto>> FilterByGenreAsync(int genreId)
    {
        var artists = await _artistRepository.FilterByGenre(genreId);
        return artists.Select(MapToGetDto).ToList();  
    }

    public async Task<List<ArtistGetDto>> SearchByNameAsync(string name)
    {
        var artists = await _artistRepository.SearchByName(name);
        return artists.Select(MapToGetDto).ToList();   
    }
}