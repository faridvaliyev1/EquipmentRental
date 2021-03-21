using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using EquipmentRental.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquipmentRental.Controllers
{
    public class OrderController : CustomController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderRepository orderRepository,IEquipmentRepository equipmentRepository,UserManager<User> userManager)
        {
            _equipmentRepository = equipmentRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create(int id)
        {
            var model = await _equipmentRepository.GetEquipmentDetail(id);

            var createOrderModel = new CreateOrderRequestModel()
            {
                EquipmentName = model.Name,
                Type_id = model.Type_id,
                EquipmentId=model.Id,
                
            };

            return View(createOrderModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateOrderRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                model.UserId = user.Id;

                await _orderRepository.AddOrder(model);

                user.LoyaltyBalance+= model.Type_id == 3 ? 2 : 1;

                await _userManager.UpdateAsync(user);

                return RedirectToAction("Index", "Equipment");
            }
            else
            {
                return View(model);
            }
        }

    }
}
