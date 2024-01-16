using DBSystem;
using DBSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace Tura.UnitTest
{


    public class DriverRepositoryTests
    {
        private readonly DriverRepository _driverRepository;
        private readonly Mock<TuraContext> _dbContextMock;

        public DriverRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TuraContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContextMock = new Mock<TuraContext>(options);

            _driverRepository = new DriverRepository(_dbContextMock.Object);
        }

        [Fact]
        public async Task CreateDriverAsync_ShouldCreateDriver_WhenDriverIsValid()
        {
            // Arrange  
            var driver = new Drivers
            {
                DriverCompanyID = "testCompanyID",
                DriverLastName = "testLastName",
                DriverFirstName = "testFirstName",
                // Initialize other properties as needed  
            };

            // Act  
            var result = await _driverRepository.CreateDriverAsync(driver);

            // Assert  
            Assert.NotNull(result);
            Assert.Equal(driver, result);
            // Add more asserts as needed to check if other properties are correctly set  

            // Verify that the Add and SaveChangesAsync methods were called on the DbContext  
            _dbContextMock.Verify(db => db.Drivers.Add(It.IsAny<Drivers>()), Times.Once());
            _dbContextMock.Verify(db => db.SaveChangesAsync(default(CancellationToken)), Times.Once());
        }
    }
}
