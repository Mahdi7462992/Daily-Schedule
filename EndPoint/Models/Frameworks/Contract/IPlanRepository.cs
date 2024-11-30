using EndPoint.Models.DomainModels.PlanAggregates;
using System;

namespace EndPoint.Models.Frameworks.Contract
{
    public interface IPlanRepository
    {
        Task<List<Plan>> Select();
        Task Insert(Plan plan);
        Task Delete(Plan plan);
        Task Delete(long id);
        Task<List<Plan>> Update(Plan plan);
        Task<Plan> GetByIdAsync(long id);
        Task<List<Plan>> GetByDayAsync(DayOfWeek day);
    }
}
