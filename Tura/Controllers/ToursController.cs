using DBSystem.Commands.TourCommands;
using DBSystem.Handlers.TourCommandHandlers;
using DBSystem.Handlers.TourQueryHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using System.Formats.Asn1;
using System.Net;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Tura.Controllers
{
    [Route("api/tours")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly TourCommandHandler tourCommandHandler;
        private readonly ToursQueryHandler toursQueryHandler;

        private ToursController(TourCommandHandler tourCommandHandler, ToursQueryHandler toursQueryHandler)
        {
            this.tourCommandHandler = tourCommandHandler;
            this.toursQueryHandler = toursQueryHandler;
        }

        [HttpGet("getalltours")]
        public async Task<IActionResult> GetAllTorus()
        {
            try
            {
                var tours = await toursQueryHandler.Handle();
                return Ok(tours);
            } catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("gettoursbydate")]
        public async Task<IActionResult> GetToursByDate([FromQuery] GetTourByDateQuery query)
        {
            try
            {
                var tours = await toursQueryHandler.Handle(query);
                return Ok(tours);
            }
            catch (Exception ex)
            {
               return StatusCode((int) HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("gettourbyid")]
        public async Task<IActionResult> GetTourByID(string tourID)
        {
            try
            {
                var tour = await toursQueryHandler.Handle(new GetTourByIDQuery { TourID = tourID });
                return Ok(tour);
            } 
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("createtour")]
        public async Task<IActionResult> CreteTour(CreateTourCommand tour)
        {
            try
            {
                var newtour = await tourCommandHandler.Handle(tour);
                return Ok(newtour);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("updatetour")]
        public async Task<IActionResult> UpdateTour(UpdateTourCommand tour)
        {
            try
            {
                var updatetour = await tourCommandHandler.Handle(tour);
                return Ok(updatetour);
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("deletetour/{tourID}")]
        public async Task<IActionResult> DeleteTour(string tourID)
        {
            var deletetours = await tourCommandHandler.Handle(new DeleteTourCommand { TourID = tourID });
            return Ok(deletetours);
        }
    }
}
