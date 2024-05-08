using Microsoft.AspNetCore.Mvc;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinResultController : ControllerBase
    {

        private readonly ISpinResultRepository _spinResultRepository;
        private readonly ISpinResultHelper _spinResultHelper;
        public SpinResultController(ISpinResultRepository spinResultRepository, ISpinResultHelper spinResultHelper)
        {
            _spinResultRepository = spinResultRepository;
            _spinResultHelper = spinResultHelper;
        }

        [Route("SpinTheWheel")]
        [HttpPost]
        public async Task<ActionResult<int>> SpinTheWheel()
        {
            int result = _spinResultHelper.SpinTheWheel();
            return await AddSpinResult(result);
        }

        [Route("AddSpinResult")]
        [HttpPost]
        public async Task<ActionResult<int>> AddSpinResult(int result)
        {
            var spinIdNumber = await _spinResultRepository.AddSpinResultAsync(result);
            return Ok(spinIdNumber);
        }

        [Route("GetAllSpinResults")]
        [HttpGet]
        public async Task<ActionResult<List<SpinResult>>> GetAllSpinResults()
        {
            var spinResults = await _spinResultRepository.GetAllSpinResultsAsync();
            return Ok(spinResults);
        }

        [Route("GetSpinResult")]
        [HttpGet]
        public async Task<ActionResult<SpinResult>> GetSpinResult(int spinResultId)
        {
            var spinResult = await _spinResultRepository.GetSpinResultAsync(spinResultId);
            if (spinResult == null)
                return NotFound();
            return Ok(spinResult);
        }

    }
}
