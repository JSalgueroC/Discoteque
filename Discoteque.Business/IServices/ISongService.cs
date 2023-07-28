using System.Reflection.Metadata;
using Discoteque.Business.Services;
using Discoteque.Data.Models;
namespace Discoteque.Data.Services;

public interface ISongService{       
    /// <summary>
    /// Creates a new <see cref="Song"/> entity in Database. 
    /// </summary>
    Task<Song> CreateSong(Song song);
    /// <summary>
    /// Creates a new <see cref="Song"/> entity in Database in batchmode. 
    /// </summary>
    //Task<Song> CreateSongBatch(List<Song> songBatch);
    /// <summary>
    /// Updates the <see cref="Song"/> entity in Database
    /// </summary>
    Task<Song> UpdateSong(Song song);
    /// <summary>
    /// Deletes the <see cref="Song"/> entity in Database
    /// </summary>
    Task<Song> DeleteSong(int id);
    /// <summary>
    /// Gets all songs in the DB
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Song>> GetAllSongsAsync(bool areReferencesLoaded);
    /// <summary>
    /// Gets all songs released in a specific year
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Song>> GetSongsByYear(int year);
    /// <summary>
    /// Gets all songs released in a year range
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Song>> GetSongsByYearRange(int initialYear, int finalYear);
    /// <summary>
    /// Gets all songs in a album
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Song>> GetSongsByAlbum(string album);
    /// <summary>
    /// Gets all songs from a artist
    /// </summary>
    /// <returns>A <see cref="List" /> of <see cref="Song"/> </returns>
    Task<IEnumerable<Song>> GetSongsByArtist(string artist);
    
}