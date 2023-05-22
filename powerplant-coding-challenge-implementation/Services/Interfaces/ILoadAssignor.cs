using powerplant_coding_challenge_implementation.Models;

namespace powerplant_coding_challenge_implementation.Services.Interfaces
{
    public interface ILoadAssignor
    {
        Task<List<ProductionPlanResponse>> AssignAsync(List<PowerPlant> meritOrderedPowerPlants,int load);
    }
}
