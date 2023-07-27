public async Task<Song> CreateSong(Song song)
    {   
        var newSong = new Song{
            Name = song.Name,
            Duration = song.Duration,
            AlbumId = song.AlbumId
        };

        await _unitOfWork.SongRepository.AddAsync(newSong);
        await _unitOfWork.SaveAsync();
        return newSong;
    }