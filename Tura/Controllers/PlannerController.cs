using DBEntities.Entities.Planner;
using DBSystem.Commands.PlannerCommands;
using DBSystem.Commands.TourCommands;
using DBSystem.Handlers.PlannerCommandHandler;
using DBSystem.Handlers.PlannerQueryHandlers;
using DBSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Tura.Controllers
{
    [Route("api/planner")]
    [ApiController]
    public class PlannerController : ControllerBase
    {
        private readonly PlannercCommandHandler plannerCommandHandler;
        private readonly PlannerQueryHandler plannerQueryHandler;

        public PlannerController(PlannercCommandHandler plannerCommandHandler, PlannerQueryHandler plannerQueryHandler)
        {
            this.plannerCommandHandler = plannerCommandHandler;
            this.plannerQueryHandler = plannerQueryHandler;
        }

        [HttpGet("getallplanners")]
        public async Task<IActionResult> GetAllPlanners()
        {
            try
            {
                var planners = await plannerQueryHandler.Handle();
                return Ok(planners);
            } 
            catch (Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getplannerbyuid")]
        public async Task<IActionResult> GetPlannerByUID(Guid plannerUID)
        {
            try
            {
                var planner = await plannerQueryHandler.Handle(new GetPlannerByUID { PlannerUID = plannerUID });
                return Ok(planner);
            }
            catch (Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getplannerfromdate")]
        public async Task<IActionResult> GetPlannerFromDate([FromQuery] GetPlannerFromDate query)
        {
            try
            {
                var planners = await plannerQueryHandler.Handle(new GetPlannerFromDate { StartDate = query.StartDate, EndDate = query.EndDate });
                return Ok(planners);
            }
            catch (Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("createplanner")]
        public async Task<IActionResult> CreatePlanner(CreatePlannerCommand planner)
        {
            try
            {
                var newplanner = await plannerCommandHandler.Handle(planner);
                return Ok(newplanner);
            }
            catch (Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("updateplanner")]
        public async Task<IActionResult> UpdatePlanner(UpdatePlannerCommand planner)
        {
            try
            {
                var updateplanner = await plannerCommandHandler.Handle(planner);
                return Ok(updateplanner);
            }
            catch(Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("deleteplanner/{uidplanner}")]
        public async Task<IActionResult> DeletePlanner(Guid uidplanner)
        {
            try
            {
                var deleteplanner = await plannerCommandHandler.Handle(new DeletePlannerCommand { UIDPlanner = uidplanner });
                return Ok(deleteplanner);
            }
            catch (Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
