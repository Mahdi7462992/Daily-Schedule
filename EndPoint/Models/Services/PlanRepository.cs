using EndPoint.Models.DomainModels.PlanAggregates;
using EndPoint.Models.Frameworks.Contract;
using Microsoft.EntityFrameworkCore;
using System;

namespace EndPoint.Models.Services
{
    public class PlanRepository : IPlanRepository
    {
        #region [-Ctor()-]

        private readonly PlanDbContext _context;
        public PlanRepository(PlanDbContext context)
        {
            _context= context;
        }
        #endregion

        #region [-Create()-]
        public async Task Insert(Plan plan)
        {
            using (_context)
            {
                try
                {
                    var p = new Plan()
                    {
                        Id = plan.Id,
                        Time = plan.Time,
                        Day = plan.Day,
                        Detail=plan.Detail
                    };

                    _context.Plan.Add(p);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.Plan != null) _context.Dispose();
                }
            }
        }
        #endregion

        #region [-Select()-]
        public async Task<List<Plan>> Select()
        {
            using (_context)
            {
                try
                {
                    var Plans = await _context.Plan.ToListAsync();
                    return Plans;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.Plan != null) _context.Dispose();
                }
            }
        }
        #endregion
    }
}
