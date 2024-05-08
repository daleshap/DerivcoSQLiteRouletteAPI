using Microsoft.AspNetCore.Mvc;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository _betRepository;
        public BetController(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        [Route("AddBet")]
        [HttpPost]
        public async Task<ActionResult<string>> AddBet(Bet bet)
        {
            var result = await _betRepository.AddBetAsync(bet);
            return Ok(result);
        }

        [Route("GetBetsForSpin")]
        [HttpGet]
        public async Task<ActionResult<List<Bet>>> GetBetsForSpin(int spinIdNumber)
        {
            var bets = await _betRepository.GetBetsForSpinAsync(spinIdNumber);
            return Ok(bets);
        }

        [Route("GetAllBets")]
        [HttpGet]
        public async Task<ActionResult<List<Bet>>> GetAllBets()
        {
            var bets = await _betRepository.GetAllBetsAsync();
            return Ok(bets);
        }

        [Route("GetUserBets")]
        [HttpGet]
        public async Task<ActionResult<List<Bet>>> GetBetForUser(int userId)
        {
            var bets = await _betRepository.GetBetsForUserAsync(userId);
            return Ok(bets);
        }

        [Route("GetSingleBet")]
        [HttpGet]
        public async Task<ActionResult<Bet>> GetSingleBet(int betId)
        {
            var bet = await _betRepository.GetSingleBetAsync(betId);
            if (bet == null)
                return NotFound();
            return Ok(bet);
        }

    }
}
