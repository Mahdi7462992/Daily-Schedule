using EndPoint.Models.DomainModels.PlanAggregates;
using EndPoint.Models.Frameworks.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace EndPoint.Controllers
{
    public class PlanController : Controller
    {

        #region [-Ctor()-]
        private readonly IPlanRepository _planRepository;
        public PlanController(IPlanRepository planRepository)
        {
            _planRepository=planRepository;
        }
        #endregion

        #region [-Index()-]
        public async Task<IActionResult> Index()
        {
            return View(await _planRepository.Select());
        }
        #endregion

        #region [-Create()-]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(long Id, [Bind("Time", "DayOfWeek", "Detail")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                await _planRepository.Insert(plan);
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
        #endregion

        #region [-Delete()-]

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            return View(await _planRepository.GetByIdAsync(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Plan plan)
        {
            await _planRepository.Delete(plan);
            return RedirectToAction("Index");
        }

        #endregion

        #region [-Update()-]

        [HttpGet]
        public async Task<IActionResult> Update(DayOfWeek day)
        {
            return View(await _planRepository.GetByDayAsync(day));
        }

        [HttpPost]
        public async Task<IActionResult> Update(List<Plan> plans)
        {
            if (ModelState.IsValid)
            {
                foreach (var plan in plans)
                {
                    await _planRepository.Update(plan);
                }
                return RedirectToAction("Index");
            }
            return View(plans);
        }
        #endregion

        #region [-Details()-]

        public async Task<IActionResult> Details(DayOfWeek day)
        {
            return View(await _planRepository.GetByDayAsync(day));
        }
        #endregion
    }
}
