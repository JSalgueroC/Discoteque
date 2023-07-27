using Discoteque.Data.Models;
namespace Discoteque.Data.Services;

public interface ITourService{
    /// <summary>
    /// Creates a new <see cref="Tour"/> entity in Database. 
    /// </summary>
    Task<Tour> CreateTour(Tour tour);
    /// <summary>
    /// Updates the <see cref="tour"/> entity in Database
    /// </summary>
    Task<Tour> UpdateTour(Tour tour);
    /// <summary>
    /// Deletes the <see cref="Tour"/> entity in Database
    /// </summary>
    Task<Tour> DeleteTour(Tour tour);
    /// <summary>
    /// Gets all tours in the DB
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    Task<IEnumerable<Tour>> GetAllToursAsync();
    /// <summary>
    /// Gets all tours in a year
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    Task<IEnumerable<Tour>> GetToursByYear(int year);
    /// <summary>
    /// Gets all tours in a year range
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    Task<IEnumerable<Tour>> GetToursByYearRange(int initialYear, int finalYear);
    /// <summary>
    /// Gets all tours in a city
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    Task<IEnumerable<Tour>> GetToursByCity(string city);
    /// <summary>
    /// Gets all tours from a artist
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Tour"/> </returns>
    Task<IEnumerable<Tour>> GetToursByArtist(string artist);
}