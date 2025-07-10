using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services;

public class LineupService : ILineupService
{
    private readonly ILineupRepository _lineupRepository;
    private readonly IFestivalRepository _festivalRepository;
    private readonly IArtistRepository _artistRepository;
    
    public LineupService(ILineupRepository lineupRepository, IFestivalRepository festivalRepository, IArtistRepository artistRepository)
    {
        _lineupRepository = lineupRepository;
        _festivalRepository = festivalRepository;
        _artistRepository = artistRepository;   
    }
    
    public async Task<IEnumerable<LineupGetDto>> GetLineupAsync(int festivalId)
    {
        try
        {
            var lineup = await _lineupRepository.GetByFestivalIdAsync(festivalId);
            return lineup.Select(l => new LineupGetDto
            {
                FestivalId = l.FestivalId,
                ArtistName = l.Artist.Name,
                Stage = l.Stage,
                StartTime = l.StartTime
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to retrieve the lineup: {ex.Message}");     
        }
    }

    public async Task AddToLineupAsync(LineupCreateDto lineupCreateDto)
    {
        await ValidateLineupInputAsync(lineupCreateDto);
        var entity = new Lineup
        {
            FestivalId = lineupCreateDto.FestivalId,
            ArtistId = lineupCreateDto.ArtistId,
            Stage = lineupCreateDto.Stage,
            StartTime = lineupCreateDto.StartTime
        };
        try
        {
            await _lineupRepository.AddAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to add artist to lineup: {ex.Message}");
        }
    }
    
    public async Task UpdateLineupAsync(LineupCreateDto lineupCreateDto)
    {
        await ValidateLineupInputAsync(lineupCreateDto);
        try
        {
            var entity = new Lineup
            {
                FestivalId = lineupCreateDto.FestivalId,
                ArtistId = lineupCreateDto.ArtistId,
                Stage = lineupCreateDto.Stage,
                StartTime = lineupCreateDto.StartTime
            };
        
            await _lineupRepository.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to update lineup: {ex.Message}");
        }
    }
    
    public async Task RemoveFromLineupAsync(int festivalId, int artistId)
    {
        try
        {
            await _lineupRepository.DeleteAsync(festivalId, artistId);
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to remove artist from lineup: {ex.Message}");
        }
    }
    
    private async Task ValidateLineupInputAsync(LineupCreateDto lineupCreateDto)
    {
        if (lineupCreateDto.FestivalId <= 0)
            throw new ArgumentException("Invalid festival ID");
        
        if (lineupCreateDto.ArtistId <= 0)
            throw new ArgumentException("Invalid artist ID");
        
        if (string.IsNullOrWhiteSpace(lineupCreateDto.Stage))
            throw new ArgumentException("Stage is required");
        
        var festival = await _festivalRepository.GetByIdAsync(lineupCreateDto.FestivalId);
        if (festival == null)
            throw new ArgumentException($"Festival with ID {lineupCreateDto.FestivalId} not found");
        
        var artist = await _artistRepository.GetByIdAsync(lineupCreateDto.ArtistId);
        if (artist == null)
            throw new ArgumentException($"Artist with ID {lineupCreateDto.ArtistId} not found");
        
        if (festival.StartDate.HasValue && lineupCreateDto.StartTime < festival.StartDate.Value)
            throw new ArgumentException("Performance time cannot be before festival start date");
        
        if (festival.EndDate.HasValue && lineupCreateDto.StartTime > festival.EndDate.Value)
            throw new ArgumentException("Performance time cannot be after festival end date");
    }
}