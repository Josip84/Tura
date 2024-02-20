using DBEntities.Entities.Drivers;
using DBSystem.Handlers.DriverCommands;
using DBSystem.Handlers.DriverQueryHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using GetDriverByCompanyIdQuery = DBSystem.Handlers.DriverQueryHandlers.GetDriverByCompanyIdQuery;


namespace Tura.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        private readonly ICommandDriversHandler<CreateDriverCommand> createHandler;
        private readonly ICommandDriversHandler<DeleteDriverCommand> deleteHandler;
        private readonly ICommandDriversHandler<UpdateDriverCommand> updateHandler;

        private readonly IQueryHandlerDrivers<GetDriverByPropertiesQuery, List<Drivers>> propertiesQueryHandler;
        private readonly IQueryHandlerDrivers<GetDriverByIdQuery, Drivers> idQueryHandler;
        private readonly IQueryHandlerDrivers<GetDriverByCompanyIdQuery, Drivers> companyIdQueryHandler;
        private readonly IQueryHandlerDrivers<GetAllDriversQuery, List<Drivers>> allDriversQueryHandler;


        public DriverController(
            ICommandDriversHandler<CreateDriverCommand> createHandler,
            ICommandDriversHandler<DeleteDriverCommand> deleteHandler,
            ICommandDriversHandler<UpdateDriverCommand> updateHandler,
            IQueryHandlerDrivers<GetDriverByPropertiesQuery, List<Drivers>> propertiesQueryHandler,
            IQueryHandlerDrivers<GetDriverByIdQuery, Drivers> idQueryHandler,
            IQueryHandlerDrivers<GetDriverByCompanyIdQuery, Drivers> companyIdQueryHandler,
            IQueryHandlerDrivers<GetAllDriversQuery, List<Drivers>> allDriversQueryHandler
        )
        {
            this.createHandler = createHandler;
            this.deleteHandler = deleteHandler;
            this.updateHandler = updateHandler;
            this.propertiesQueryHandler = propertiesQueryHandler;
            this.idQueryHandler = idQueryHandler;
            this.companyIdQueryHandler = companyIdQueryHandler;
            this.allDriversQueryHandler = allDriversQueryHandler;
        }

        [HttpGet("getalldrivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            try
            {
                var drivers = await allDriversQueryHandler.Handle(new GetAllDriversQuery());
                return Ok(drivers);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("getdriverby/{idDriver}")]
        public async Task<IActionResult> GetDriverByID(int idDriver)
        {
            try
            {
                var driver = await idQueryHandler.Handle(new DBSystem.Handlers.DriverQueryHandlers.GetDriverByIdQuery { DriverId = idDriver });
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getdriverbycompanyid/{driverCompanyID}")]
        public async Task<IActionResult> GetDriverByCompanyID(string driverCompanyID)
        {
            try
            {
                var driver = await companyIdQueryHandler.Handle(new GetDriverByCompanyIdQuery { DriverCompanyId = driverCompanyID });
                return Ok(driver);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("createdriver")]
        public async Task<IActionResult> CreateDriver(CreateDriverCommand driver)
        {
            try 
            {
                var hewdriver = await createHandler.Handle(driver);
                return Ok(hewdriver);
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("updatedriver")]
        public async Task<IActionResult> UpdateDriver(UpdateDriverCommand driver)
        {
            try
            {
                var updatedriver = await updateHandler.Handle(driver);
                return Ok(updatedriver);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("deletedriver/{idDriver}")]
        public async Task<IActionResult> DeleteDriver(int idDriver)
        {
            try
            {
                var deletedriver = await deleteHandler.Handle(new DeleteDriverCommand { DriverID = idDriver });
                return Ok();
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
