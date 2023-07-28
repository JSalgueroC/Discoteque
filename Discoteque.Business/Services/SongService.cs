using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using Discoteque.Data;
using Discoteque.Data.Models;
using Discoteque.Data.Services;

namespace Discoteque.Business.Services;

public class SongService : ISongService
{
    private IUnitOfWork _unitOfWork;

    public SongService(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }
    /// <summary>
    /// Creates a new <see cref="Song"/> entity in Database. 
    /// </summary>
    public async Task<Song> CreateSong(Song song)
    {   
        var albumExist = await _unitOfWork.AlbumRepository.FindAsync(song.AlbumId);

        if (albumExist is null){
            throw new Exception($"Album with {song.AlbumId} does not exist");
        }
        var newSong = new Song{
            Name = song.Name,
            Duration = song.Duration,
            AlbumId = song.AlbumId
        };

        await _unitOfWork.SongRepository.AddAsync(newSong);
        await _unitOfWork.SaveAsync();
        return newSong;
    }

    /*public async Task<Song> CreateSongBatch(List<Song> songBatch)
    {   
        foreach (var song in songBatch){
            await CreateSong(song);
            return song;
        }
    }
    */
    public async Task<Song> DeleteSong(int id)
    {   
        await _unitOfWork.SongRepository.Delete(id);
        await _unitOfWork.SaveAsync();
        return null;    
    }

    public async Task<IEnumerable<Song>> GetAllSongsAsync(bool areReferencesLoaded)
    {
        IEnumerable<Song> songs;
        if (areReferencesLoaded){
            songs = await _unitOfWork.SongRepository.GetAllAsync(null, x => x.OrderBy(x => x.Id), new Album().GetType().Name);
        }
        else{
            songs = await _unitOfWork.SongRepository.GetAllAsync();
        }
        return songs;
    }
    public async Task<IEnumerable<Song>> GetSongsByAlbum(string album)
    {
        IEnumerable<Song> songs;
        songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Album.Name.Equals(album), x => x.OrderBy(x => x.Id), new Album().GetType().Name);
        return songs;
    }

    public async Task<IEnumerable<Song>> GetSongsByArtist(string artist)
    {
        IEnumerable<Song> songs;
        songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Album.Artist.Name.Equals(artist), x => x.OrderBy(x=>x.Id),new Artist().GetType().Name);
        return songs;
    }

    public async Task<IEnumerable<Song>> GetSongsByYear(int year)
    {
        IEnumerable<Song> songs;
        songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Album.Year.Equals(year), x => x.OrderBy(x => x.Id), new Album().GetType().Name);
        return songs;
    }

    public async Task<IEnumerable<Song>> GetSongsByYearRange(int initialYear, int finalYear)
    {
        IEnumerable<Song> songs;
        songs = await _unitOfWork.SongRepository.GetAllAsync(x => x.Album.Year >= initialYear && x.Album.Year <= finalYear, x => x.OrderBy(x => x.Id), new Album().GetType().Name);
        return songs;
    }

    public async Task<Song> UpdateSong(Song song)
    {
        await _unitOfWork.SongRepository.Update(song);
        await _unitOfWork.SaveAsync();
        return song;
    }
}