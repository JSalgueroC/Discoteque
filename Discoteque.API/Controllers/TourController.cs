using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;
using Discoteque.Data.Services;

namespace Discoteque.Business.Controllers{
    [Route("api/[controller]")]
    [ApiController]

    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService){
            _tourService = tourService;
        }

        [HttpPost]
        [Route("CreateTour")]
        public async Task<IActionResult> CreateTour(Tour tour){
            try{
            var result = await _tourService.CreateTour(tour);
            return Ok(result);
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTour")]
        public async Task<IActionResult> DeleteTour(Tour tour){
            var result = await _tourService.DeleteTour(tour);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllToursAsync")]
        public async Task <IActionResult> GetAllToursAsync(){
            var tours = await _tourService.GetAllToursAsync();
            return Ok(tours);
        }

        [HttpGet]
        [Route("GetToursByArtist")]
        public async Task <IActionResult> GetToursByArtist(string artist){
            var tours = await _tourService.GetToursByArtist(artist);
            return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "No tours by this artist");
        }

        [HttpGet]
        [Route("GetToursByCity")]
        public async Task <IActionResult> GetToursByCity(string city){
            var tours = await _tourService.GetToursByCity(city);
            return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "No tours in this city");
        }

        [HttpGet]
        [Route("GetToursByYear")]
        public async Task <IActionResult> GetToursByYear(int year){
            var tours = await _tourService.GetToursByYear(year);
            return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "No tours during this year");
        }

        [HttpGet]
        [Route("GetToursByYearRange")]
        public async Task <IActionResult> GetToursByYearRange(int initialYear, int finalYear){
            var tours = await _tourService.GetToursByYearRange(initialYear, finalYear);
            return tours.Any() ? Ok(tours) : StatusCode(StatusCodes.Status404NotFound, "No tours during this year range");
        }

        [HttpDelete]
        [Route("UpdateTour")]
        public async Task<IActionResult> UpdateTour(Tour tour){
            var result = await _tourService.UpdateTour(tour);
            return Ok(result);
        }
    }
}