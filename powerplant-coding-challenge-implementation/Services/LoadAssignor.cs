using Microsoft.Extensions.Logging;
using powerplant_coding_challenge_implementation.Models;
using powerplant_coding_challenge_implementation.Services.Interfaces;
using System.Collections.Generic;

namespace powerplant_coding_challenge_implementation.Services
{
    public class LoadAssignor : ILoadAssignor
    {
        private readonly ILogger<LoadAssignor> _logger;

        public LoadAssignor(ILogger<LoadAssignor> logger)
        {
            _logger = logger;
        }

        public Task<List<ProductionPlanResponse>> AssignAsync(List<PowerPlant> meritOrderedPowerPlants, int load)
        {
            List<ProductionPlanResponse> response = new();

            foreach (PowerPlant powerPlant in meritOrderedPowerPlants)
            {
                int loadToAssign = CalculateLoadToAssign(load, powerPlant.PActual);
                load -= loadToAssign;

                ProductionPlanResponse productionPlanResponse = new(powerPlant.Name, loadToAssign);
                response.Add(productionPlanResponse);
            }

            return Task.FromResult(response);
        }

        private int CalculateLoadToAssign(int remainingLoad, int powerPlantPActual)
        {
            if (remainingLoad == 0)
            {
                return 0;
            }
            else
            {
                int loadToAssign = (remainingLoad - powerPlantPActual > 0) ? powerPlantPActual : remainingLoad;
                return loadToAssign;
            }
        }
    }
}
