using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core;
using Pharmacy.Repos;

namespace Pharmacy.UI.Controllers
{
    public class ManagerController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public ManagerController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View("Orders", await _orderRepository.GetAllOrder());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string customerName)
        {
            return View("Orders", await _orderRepository.GetSearchAllOrder(customerName));
        }

            // EDIT

            [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var statuslist = new List<string>
            {
                "NEW",
                "підтверджено",
                "відправлено",
            };
            var order = await _orderRepository.GetOrder(id);
            ViewBag.Status = statuslist;
            ViewData["selectstatus"] = order.Status.ToString();
            return View(await _orderRepository.GetOrder(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(string modelId, string status, bool ispaid)
        {
                await _orderRepository.UpdateAsync(modelId, status, ispaid);
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var order = await _orderRepository.GetOrder(id);
            var detid = order.details;
            ViewBag.Order = order;
            var items = await _orderRepository.GetOrderItems(detid.Id);
            ViewBag.Items = items;
            return View(detid);
        }
    }
}
