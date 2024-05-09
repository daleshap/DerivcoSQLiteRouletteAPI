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
    public class BetTests
    {
        private RouletteDbContext _dbContext;
        private IBetRepository _betRepository;
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
            _betRepository = new BetRepository(_dbContext);
        }


        [Test]
        public async Task AddBetAsync_ValidBet_ReturnsBetId()
        {
            // Arrange
            var expectedResult = "Bet Placed Successfully"; 

            // Act
            var result = await _betRepository.AddBetAsync(new Bet() { UserId = 1 });

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task GetAllBetsAsync_ReturnsDataTable()
        {
            // Act
            var result = await _betRepository.GetAllBetsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Bet>>(result);
        }

        [Test]
        public async Task GetBetsForSpinAsync_ValidSpinId_ReturnsDataTable()
        {
            // Act
            var result = await _betRepository.GetBetsForSpinAsync(1); // Change this to a valid spinId

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Bet>>(result);
        }

        [Test]
        public async Task GetBetsForUserAsync_ValidUserId_ReturnsDataTable()
        {
            // Act
            var result = await _betRepository.GetBetsForUserAsync(1); // Change this to a valid userId

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Bet>>(result);
        }

        [Test]
        public async Task GetSingleBetAsync_ValidBetId_ReturnsDataTable()
        {
            // Act
            var result = await _betRepository.GetSingleBetAsync(6); // Change this to a valid betId

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Bet>(result);
        }

        [TearDown]
        public void TearDown()
        {
            _betRepository = null;
        }
    }

}
