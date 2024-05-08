using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Models;
using SQLiteRouletteAPI.Data;
using SQLiteRouletteAPI.Models;
using System.Data;

namespace SQLiteRouletteAPI.Repos
{
    public class BetRepository : IBetRepository
    {
        private readonly RouletteDbContext _dbContext;
        public BetRepository(RouletteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddBetAsync(Bet bet)
        {
            _dbContext.Bets.Add(bet);
            await _dbContext.SaveChangesAsync();
            return "Bet Placed Successfully";
        }


        public async Task<List<Bet>> GetBetsForSpinAsync(int spinIdNumber)
        {
            return await _dbContext.Bets.Where(b => b.SpinIdNumber == spinIdNumber).ToListAsync();
        }

        public async Task<List<Bet>> GetAllBetsAsync()
        {
            return await _dbContext.Bets.ToListAsync();
        }

        public async Task<List<Bet>> GetBetsForUserAsync(int userId)
        {
            return await _dbContext.Bets.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<Bet> GetSingleBetAsync(int betId)
        {
            return await _dbContext.Bets.FindAsync(betId);
        }
    }
}
