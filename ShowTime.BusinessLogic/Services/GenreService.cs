using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class GenreService : GenericEntityService<Genre, GenreGetDto, GenreCreateDto>,  IGenreService
{
    private readonly IGenreRepository _genreRepository;
    protected override string EntityName => "Genre";
    
    public GenreService(IGenreRepository genreRepository) : base(genreRepository)
    {
        _genreRepository = genreRepository;
    }
    
    protected override GenreGetDto MapToGetDto(Genre genre)
    {
        return new GenreGetDto
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }
    
    protected override Genre MapToEntityForCreate(GenreCreateDto genreCreateDto)
    {
        return new Genre
        {
            Name = genreCreateDto.Name
        };   
    }

    protected override Genre MapToEntityForUpdate(GenreCreateDto genreCreateDto, int id)
    {
        return new Genre
        {
            Id = id,
            Name = genreCreateDto.Name
        };
    }
}