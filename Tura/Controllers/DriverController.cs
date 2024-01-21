using DBSystem.Handlers.Commands;
using DBSystem.Handlers.DriverQueryHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CreateDriverCommand = DBSystem.Handlers.Commands.CreateDriverCommand;
using DeleteDriverCommand = DBSystem.Handlers.Commands.DeleteDriverCommand;
using GetDriverByCompanyIdQuery = DBSystem.Handlers.DriverQueryHandlers.GetDriverByCompanyIdQuery;
using UpdateDriverCommand = DBSystem.Handlers.Commands.UpdateDriverCommand;

namespace Tura.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        /*private readonly DriverCommandHandler driverCommandHandler;
        private readonly DriverQueryHandler driverQueryHandler;*/

        //public DriverController(IDriverRepository iDriverRepository) => this.iDriverRepository = iDriverRepository;
        /*public DriverController(DriverCommandHandler driverCommandHandler, DriverQueryHandler driverQueryHandler)
        {
            this.driverCommandHandler = driverCommandHandler;
            this.driverQueryHandler = driverQueryHandler;
        }*/

        private readonly ICommandHandler<CreateDriverCommand> createHandler;
        private readonly ICommandHandler<DeleteDriverCommand> deleteHandler;
        private readonly ICommandHandler<UpdateDriverCommand> updateHandler;
        
        private readonly DriverQueryHandler driverQueryHandler;


        public DriverController(
            ICommandHandler<CreateDriverCommand> createHandler,
            ICommandHandler<DeleteDriverCommand> deleteHandler,
            ICommandHandler<UpdateDriverCommand> updateHandler)
        {
            this.createHandler = createHandler;
            this.deleteHandler = deleteHandler;
            this.updateHandler = updateHandler;
        }

        [HttpGet("getalldrivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            try
            {
                var drivers = await driverQueryHandler.Handle(new GetAllDriversQuery());
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
                var driver = await driverQueryHandler.Handle(new DBSystem.Handlers.DriverQueryHandlers.GetDriverByIdQuery { DriverId = idDriver });
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


        /*[HttpPost]
        public async Task<IActionResult> Create(CreateDriverCommand command)
        {
            var result = await createHandler.Handle(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDriverCommand { DriverId = id };
            var result = await deleteHandler.Handle(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDriverCommand command)
        {
            var result = await updateHandler.Handle(command);
            return Ok(result);
        }*/

    }
}
