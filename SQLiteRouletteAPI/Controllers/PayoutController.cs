using Microsoft.AspNetCore.Mvc;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayoutController : ControllerBase
    {
        private readonly IPayoutRepository _payoutRepository;
        private readonly IPayoutHelper _payoutHelper;

        public PayoutController(IPayoutRepository payoutRepository, IPayoutHelper payoutHelper)
        {
            _payoutRepository = payoutRepository;
            _payoutHelper = payoutHelper;
        }

        [Route("AddPayout")]
        [HttpPost]
        public async Task<ActionResult<string>> AddPayout(Payout payout)
        {
            await _payoutRepository.AddPayoutAsync(payout);
            return Ok("Payout Placed");
        }

        [Route("GetAllPayouts")]
        [HttpGet]
        public async Task<ActionResult<List<Payout>>> GetAllPayouts()
        {
            var payouts = await _payoutRepository.GetAllPayoutsAsync();
            return Ok(payouts);
        }

        [Route("GetPayout")]
        [HttpGet]
        public async Task<ActionResult<Payout>> GetPayout(int payoutId)
        {
            var payout = await _payoutRepository.GetPayoutAsync(payoutId);
            if (payout == null)
                return NotFound();
            return Ok(payout);
        }

        [Route("CalculatePayout")]
        [HttpPost]
        public async Task<ActionResult<string>> CalculatePayout(int spinIdNumber)
        {
            await _payoutHelper.CalculatePayoutTotalAsync(spinIdNumber);
            return Ok("All Payouts Calculated");
        }
    }
}
