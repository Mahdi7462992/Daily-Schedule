using EndPoint.Models.DomainModels.PlanAggregates;
using System;

namespace EndPoint.Models.Frameworks.Contract
{
    public interface IPlanRepository
    {
        Task<List<Plan>> Select();
        Task Insert(Plan plan);
    }
}
