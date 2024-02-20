using DBEntities.Entities.Planner;
using DBSystem.Handlers.PlannerCommandHandler;
using DBSystem.Handlers.PlannerQueryHandlers;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Tura.Controllers
{
    [Route("api/planner")]
    [ApiController]
    public class PlannerController : ControllerBase
    {
        private readonly IPlannerCommandHandler<CreatePlannerCommand> createHandler;
        private readonly IPlannerCommandHandler<UpdatePlannerCommand> updateHandler;
        private readonly IPlannerCommandHandler<DeletePlannerCommand> deleteHandler;
        private readonly IQueryHandlerPlanner<GetAllPlannerQuery, IEnumerable<Planner>> getAllPlanner;
        private readonly IQueryHandlerPlanner<GetPlannerByDateQuery, IEnumerable<Planner>> getByDatePlanner;
        private readonly IQueryHandlerPlanner<GetPlannerByUIDQuery, Planner> getPlannerByUID;


        public PlannerController(
            IPlannerCommandHandler<CreatePlannerCommand> createHandler,
            IPlannerCommandHandler<UpdatePlannerCommand> updateHandler,
            IPlannerCommandHandler<DeletePlannerCommand> deleteHandler,
            IQueryHandlerPlanner<GetAllPlannerQuery, IEnumerable<Planner>> getAllPlanner,
            IQueryHandlerPlanner<GetPlannerByDateQuery, IEnumerable<Planner>> getByDatePlanner,
            IQueryHandlerPlanner<GetPlannerByUIDQuery, Planner> getPlannerByUID
        )
        {
            this.createHandler = createHandler;
            this.updateHandler = updateHandler;
            this.deleteHandler = deleteHandler;
            this.getAllPlanner = getAllPlanner;
            this.getByDatePlanner = getByDatePlanner;
            this.getPlannerByUID = getPlannerByUID;
        }

        [HttpGet("getallplanners")]
        public async Task<IActionResult> GetAllPlanners()
        {
            try
            {
                var planners = await getAllPlanner.Handle();
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
                var planner = await getPlannerByUID.Handle(new GetPlannerByUIDQuery { UIDPlanner = plannerUID });
                return Ok(planner);
            }
            catch (Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getplannerfromdate")]
        public async Task<IActionResult> GetPlannerFromDate([FromQuery] GetPlannerByDateQuery query)
        {
            try
            {
                var planners = await getByDatePlanner.Handle(new GetPlannerByDateQuery { StartDate = query.StartDate, EndDate = query.EndDate });
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
                var newplanner = await createHandler.Handle(planner);
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
                var updateplanner = await updateHandler.Handle(planner);
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
                var deleteplanner = await deleteHandler.Handle(new DeletePlannerCommand { UIDPlanner = uidplanner });
                return Ok(deleteplanner);
            }
            catch (Exception ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
