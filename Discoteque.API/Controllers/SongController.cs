using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;
using Discoteque.Data.Services;

namespace Discoteque.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService){
            _songService = songService;
        }

        [HttpPost]
        [Route("CreateSong")]
        public async Task<IActionResult> CreateSong(Song song){
            var result = await _songService.CreateSong(song);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteSong")]
        public async Task<IActionResult> DeleteSong(int id){
            var result = await _songService.DeleteSong(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllSongsAsync")]
        public async Task <IActionResult> GetAllSongAsync(bool areReferencesLoaded = false){
            var songs = await _songService.GetAllSongsAsync(areReferencesLoaded);
            return Ok(songs);
        }

        [HttpGet]
        [Route("GetSongsByAlbum")]
        public async Task<IActionResult> GetSongsByAlbum(string album){
            var songs = await _songService.GetSongsByAlbum(album);
            return Ok(songs);
        }

        [HttpGet]
        [Route("GetSongsByArtist")]
        public async Task<IActionResult> GetSongsByArtist(string artist){
            var songs = await _songService.GetSongsByArtist(artist);
            return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "No songs by this artist");
        }

        [HttpGet]
        [Route("GetSongsByYear")]
        public async Task<IActionResult> GetSongsByYear(int year){
            var songs = await _songService.GetSongsByYear(year);
            return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "No songs by this year");
        } 

        [HttpGet]
        [Route("GetSongsByYearRange")]
        public async Task<IActionResult> GetSongsByYearRange(int initialYear, int finalYear){ 
            var songs = await _songService.GetSongsByYearRange(initialYear, finalYear);
            return songs.Any() ? Ok(songs) : StatusCode(StatusCodes.Status404NotFound, "No songs in this year range");
        } 

        [HttpPatch]
        [Route("UpdateSong")]
        public async Task<IActionResult> UpdateSong(Song song){
            var result = await _songService.UpdateSong(song);
            return Ok(result);   
        }
    }   
}
