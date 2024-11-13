using EndPoint.Models.DomainModels.PlanAggregates;
using EndPoint.Models.Frameworks.Contract;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(long Id, [Bind("Time","Day","Detail")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                await _planRepository.Insert(plan);
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
        #endregion
    }
}
