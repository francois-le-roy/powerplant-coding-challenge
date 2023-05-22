using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using powerplant_coding_challenge_implementation.Logging;
using powerplant_coding_challenge_implementation.Models;
using powerplant_coding_challenge_implementation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace powerplant_coding_challenge_implementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductionPlanController : ControllerBase
    {
        private readonly ILogger<ProductionPlanController> _logger;
        private readonly IMeritOrderCalculator _meritOrderCalculator;
        private readonly ILoadAssignor _loadAssignor;

        public ProductionPlanController(
            ILogger<ProductionPlanController> logger,
            IMeritOrderCalculator meritOrderCalculator,
            ILoadAssignor loadAssignor)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _meritOrderCalculator = meritOrderCalculator ?? throw new ArgumentNullException(nameof(meritOrderCalculator));
            _loadAssignor = loadAssignor ?? throw new ArgumentNullException(nameof(loadAssignor));
        }

        [HttpPost(Name = "productionplan")]
        public async Task<IActionResult> PostProductionPlan([FromBody] ProductionPlanPayload productionPlanPayload)
        {
            try
            {
                _logger.LogTrace("Enter PostProductionPlan");

                if (!ModelState.IsValid)
                {
                    ModelStateLogger.LogErrors(ModelState, _logger);
                    return BadRequest(ModelState);
                }

                List<PowerPlant> meritOrderedPowerPlants = await _meritOrderCalculator.ComputeAsync(productionPlanPayload);

                List<ProductionPlanResponse> response = await _loadAssignor.AssignAsync(meritOrderedPowerPlants, productionPlanPayload.Load);

                _logger.LogTrace("Exit PostProductionPlan Status: Ok");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in PostProductionPlan");
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred");
            }
        }
        private void LogModelStateErrors()
        {
            IEnumerable<string> errorMessages = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            foreach (string errorMessage in errorMessages)
            {
                _logger.LogWarning(errorMessage);
            }
        }
    }
}
