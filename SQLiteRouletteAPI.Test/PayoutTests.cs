using NUnit.Framework;
using SQLiteRouletteAPI.Data;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Models;
using SQLiteRouletteAPI.Repos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace SQLiteRouletteAPI.Test
{
    [TestFixture]
    public class PayoutRepositoryTests
    {
        private RouletteDbContext _dbContext;
        private IPayoutRepository _payoutRepository;
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
            _payoutRepository = new PayoutRepository(_dbContext);
        }

        [Test]
        public async Task GetAllPayoutsAsync_ValidResult()
        {
            // Arrange

            // Act
            var result = await _payoutRepository.GetAllPayoutsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Payout>>(result);
        }

        // Add similar tests for other methods (GetAllPayoutsAsync, GetPayoutAsync)...

        [TearDown]
        public void TearDown()
        {
            _payoutRepository = null;
        }
    }
}
