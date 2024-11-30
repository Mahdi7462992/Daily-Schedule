using EndPoint.Models.DomainModels.PlanAggregates;
using EndPoint.Models.Frameworks.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Data;
using System.Xml;

namespace EndPoint.Models.Services
{
    public class PlanRepository : IPlanRepository
    {

        #region [-Ctor()-]

        private readonly PlanDbContext _context;
        public PlanRepository(PlanDbContext context)
        {
            _context = context;
        }

        #endregion

        #region [-Create()-]
        public async Task Insert(Plan plan)
        {
            using (_context)
            {
                try
                {
                    if (await _context.Plan.AnyAsync(p =>
                              p.Time == plan.Time && p.DayOfWeek == plan.DayOfWeek))
                    {
                        throw new InvalidOperationException("Time and Day of the week already exist");
                    }

                    var p = new Plan()
                    {
                        Id = plan.Id,
                        Time = plan.Time,
                        DayOfWeek = plan.DayOfWeek,
                        Detail = plan.Detail
                    };

                    _context.Plan.Add(p);
                    await _context.SaveChangesAsync();

                    //if (await _context.Plan.AnyAsync(p => p.Time == plan.Time))
                    //{
                    //    p.Detail = plan.Detail;
                    //}
                }

                catch (Exception ex)
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

        #region [-Delete()-]
        public async Task Delete(Plan plan)
        {
            try
            {
                if (plan != null)
                {
                    _context.Entry(plan).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task Delete(long id)
        {
            var plan = await _context.Plan
                .FirstOrDefaultAsync(m => m.Id == id);
            await Delete(plan);

            if (id == null)
            {
                throw new Exception();
            }
        }

        #endregion

        #region [-GetByIdAsync()-]
        public async Task<Plan> GetByIdAsync(long id)
        {
            return await _context.Plan.FirstOrDefaultAsync(p => p.Id == id);
        }

        #endregion

        #region [-Update()-]
        public async Task<List<Plan>> Update(Plan plan)
        {
            try
            {
                if (plan == null || plan.Id <= 0) 
                {
                    throw new ArgumentException("Invalid plan data.");
                }

                var existingPlan = await _context.Plan.FindAsync(plan.Id);
                if (existingPlan == null)
                {
                    throw new Exception("Plan not found.");
                }

                existingPlan.Detail = plan.Detail;
                await _context.SaveChangesAsync();
                return await _context.Plan.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the plan.", ex);
            }
        }
        #endregion

        #region [-GetByDayAsync()-]
        public async Task<List<Plan>> GetByDayAsync(DayOfWeek day)
        {
            return await _context.Plan.Where(p => p.DayOfWeek == day).ToListAsync();
        }

        #endregion

    }
}

