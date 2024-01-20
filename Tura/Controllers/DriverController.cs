using DBEntities.Entities.Drivers;
using DBSystem.Commands.DriverComands;
using DBSystem.Commands.DriverCommands;
using DBSystem.Handlers.DriverCommandHandlers;
using DBSystem.Handlers.DriverQueryHandlers;
using DBSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.WebSockets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tura.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverCommandHandler driverCommandHandler;
        private readonly DriverQueryHandler driverQueryHandler;

        //public DriverController(IDriverRepository iDriverRepository) => this.iDriverRepository = iDriverRepository;
        public DriverController(DriverCommandHandler driverCommandHandler, DriverQueryHandler driverQueryHandler)
        {
            this.driverCommandHandler = driverCommandHandler;
            this.driverQueryHandler = driverQueryHandler;
        }

        [HttpGet("getalldrivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            try
            {
                var drivers = await driverQueryHandler.Handle();
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
                var driver = await driverQueryHandler.Handle(new GetDriverByIdQuery { DriverId = idDriver });
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
                var driver = await driverQueryHandler.Handle(new GetDriverByCompanyIdQuery { DriverCompanyId = driverCompanyID });
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
                var hewdriver = await driverCommandHandler.Handle(driver);
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
                var updatedriver = await driverCommandHandler.Handle(driver);
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
                var deletedriver = await driverCommandHandler.Handle(new DeleteDriverCommand { DriverId = idDriver });
                return Ok();
            } 
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    
    }
}
