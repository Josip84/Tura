using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntities.Entities.Drivers;
using Microsoft.EntityFrameworkCore;

namespace DBSystem.Repositories.Tests
{
    [TestClass()]
    public class DriverRepositoryTests
    {
        private TuraContext _dbContext;
        private Drivers _driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TuraContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database") // Use In-Memory database for testing
                .Options;

            _dbContext = new TuraContext(options, isTest: true);

            _driver = new Drivers
            {
                DriverCompanyID = "121212",
                DriverFirstName = "josip",
                DriverLastName = "pejakovic"
            };
        }

        [TestMethod()]
        public async Task CreateDriverAsyncTest()
        {
            var driverRepository = new DriverRepository(_dbContext);

            var result = await driverRepository.CreateDriverAsync(_driver);

            Assert.IsNotNull(result, "Driver creation failed");
            Assert.AreEqual(_driver.DriverCompanyID, result.DriverCompanyID, "The created driver's ID does not match the expected ID");
        }
    }

}