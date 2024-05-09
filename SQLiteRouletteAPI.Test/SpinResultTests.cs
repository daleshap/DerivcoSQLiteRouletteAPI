using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SQLiteRouletteAPI.Data;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Repos;
using System.Threading.Tasks;

namespace SQLiteRouletteAPI.Test
{
    [TestFixture]
    public class SpinResultRepositoryTests
    {
        private RouletteDbContext _dbContext;
        private ISpinResultRepository _spinResultRepository;
        private string _databasePath;

        [SetUp]
        public void Setup()
        {

            // Create a temporary file-based database
            _databasePath = "../../../../Database/RouletteApp.db";
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = _databasePath
            };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            // Configure DbContext to use SQLite with the temporary database
            var options = new DbContextOptionsBuilder<RouletteDbContext>()
                .UseSqlite(connection)
                .Options;

            _dbContext = new RouletteDbContext(options);
            //_dbContext.Database.EnsureCreated();
            _spinResultRepository = new SpinResultRepository(_dbContext);
        }


        [Test]
        public async Task AddSpinResultAsync_ValidResult_ReturnsSpinIdNumber()
        {
            // Arrange
            var latestSpin = await _spinResultRepository.GetLatestSpinResultAsync();
            var expectedResult = latestSpin.SpinIdNumber +1 ;

            // Act
            var result = await _spinResultRepository.AddSpinResultAsync(31);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }


        [TearDown]
        public void TearDown()
        {
            _spinResultRepository = null;
        }
    }
}
