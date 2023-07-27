using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;
using Discoteque.Data.Services;

namespace Discoteque.Business.Services;

public class TourService : ITourService
{
    private IUnitOfWork _unitOfWork;
    public TourService(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }
    /// <summary>
    /// Creates a new <see cref="Tour"/> entity in Database. 
    /// </summary>
    public async Task<Tour> CreateTour(Tour tour)
    {
        var newTour = new Tour{
            Name = tour.Name,
            City = tour.City,
            Date = tour.Date,
            IsItSoldOut = tour.IsItSoldOut,
            ArtistId = tour.ArtistId
        };

        await _unitOfWork.TourRepository.AddAsync(newTour);
        await _unitOfWork.SaveAsync();
        return newTour;
    }
    /// <summary>
    /// Deletes the <see cref="Tour"/> entity in Database
    /// </summary>
    public async Task<Tour> DeleteTour(Tour tour)
    {
        await _unitOfWork.TourRepository.Delete(tour);
        await _unitOfWork.SaveAsync();
        return tour;
    }
    /// <summary>
    /// Gets all tours in the DB
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    public Task<IEnumerable<Tour>> GetAllToursAsync()
    {
        return _unitOfWork.TourRepository.GetAllAsync();
    }
    /// <summary>
    /// Gets all tours from a artist
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    public async Task<IEnumerable<Tour>> GetToursByArtist(string artist)
    {
        IEnumerable<Tour> tours;
        tours = await _unitOfWork.TourRepository.GetAllAsync(x => x.Artist.Name.Equals(artist), x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
        return tours;
    }
    /// <summary>
    /// Gets all tours in a city
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    public async Task<IEnumerable<Tour>> GetToursByCity(string city)
    {
        IEnumerable<Tour> tours;
        tours = await _unitOfWork.TourRepository.GetAllAsync(x => x.City == city, x => x.OrderBy( x=> x.Id), new Artist().GetType().Name);
        return tours;
    }
    /// <summary>
    /// Gets all tours in a year
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    public async Task<IEnumerable<Tour>> GetToursByYear(int year)
    {
        IEnumerable<Tour> tours;
        tours = await _unitOfWork.TourRepository.GetAllAsync(x => x.Date.Year == year, x => x.OrderBy(x=> x.Id),new Artist().GetType().Name);
        return tours;
    }
    /// <summary>
    /// Gets all tours in a year range
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    public async Task<IEnumerable<Tour>> GetToursByYearRange(int initialYear, int finalYear)
    {
        IEnumerable<Tour> tours;
        tours = await _unitOfWork.TourRepository.GetAllAsync(x => x.Date.Year >= initialYear && x.Date.Year <= finalYear, x => x.OrderBy(x => x.Id), new Artist().GetType().Name);
        return tours;
    }
    /// <summary>
    /// Updates the <see cref="tour"/> entity in Database
    /// </summary>
    public async Task<Tour> UpdateTour(Tour tour)
    {
        await _unitOfWork.TourRepository.Update(tour);
        await _unitOfWork.SaveAsync();
        return tour;
    }
}