using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;

namespace ShowTime.BusinessLogic.Services;

public class ArtistService : GenericEntityService<Artist, ArtistGetDto, ArtistCreateDto>,IArtistService
{
    protected override string EntityName => "Artist";

    public ArtistService(IRepository<Artist> artistRepository) : base(artistRepository)
    {
    }
    
    protected override ArtistGetDto MapToGetDto(Artist artist)
    {
        return new ArtistGetDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Genre = artist.Genre,
            Image = artist.Image
        };
    }

    protected override Artist MapToEntityForCreate(ArtistCreateDto artistCreateDto)
    {
        return new Artist
        {
            Name = artistCreateDto.Name,
            Genre = artistCreateDto.Genre,
            Image = artistCreateDto.Image
        };   
    }

    protected override Artist MapToEntityForUpdate(ArtistCreateDto artistCreateDto, int id)
    {
        return new Artist
        {
            Id = id,
            Name = artistCreateDto.Name,
            Genre = artistCreateDto.Genre,
            Image = artistCreateDto.Image
        };  
    }
}