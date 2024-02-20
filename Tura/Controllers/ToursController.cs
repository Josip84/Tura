using DBEntities.Entities.Tours;
using DBSystem.Handlers.TourCommandHandlers;
using DBSystem.Handlers.TourQueryHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Tura.Controllers
{
    [Route("api/tours")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourCommandHandler<CreateTourCommand> createHandler;
        private readonly ITourCommandHandler<UpdateTourCommand> updateHandler;
        private readonly ITourCommandHandler<DeleteTourCommand> deleteHandler;
        private readonly IQueryHandlerTour<GetAllToursQuery, List<Tours>> getAllTours;
        private readonly IQueryHandlerTour<GetTourByDateQuery, List<Tours>> getToursByDate;
        private readonly IQueryHandlerTour<GetTourByUIDQuery, Tours> getTourByID;

        public ToursController(
            ITourCommandHandler<CreateTourCommand> createHandler,
            ITourCommandHandler<UpdateTourCommand> updateHandler,
            ITourCommandHandler<DeleteTourCommand> deleteHandler,
            IQueryHandlerTour<GetAllToursQuery, List<Tours>> getAllTours,
            IQueryHandlerTour<GetTourByDateQuery, List<Tours>> getToursByDate,
            IQueryHandlerTour<GetTourByUIDQuery, Tours> getTourByID
        )
        {
            this.createHandler = createHandler;
            this.updateHandler = updateHandler;
            this.deleteHandler = deleteHandler;
            this.getAllTours = getAllTours;
            this.getToursByDate = getToursByDate;
            this.getTourByID = getTourByID;
        }

        [HttpGet("getalltours")]
        public async Task<IActionResult> GetAllTorus()
        {
            try
            {
                var tours = await getAllTours.Handle();
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
                var tours = await getToursByDate.Handle(query);
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
                var tour = await getTourByID.Handle(new GetTourByUIDQuery { IDTour = tourID });
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
                var newtour = await createHandler.Handle(tour);
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
                var updatetour = await updateHandler.Handle(tour);
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
            var deletetours = await deleteHandler.Handle(new DeleteTourCommand { UIDTour = tourID });
            return Ok(deletetours);
        }
    }
}
