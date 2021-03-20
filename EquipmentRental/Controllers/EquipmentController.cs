using EquipmentRental.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquipmentRental.Controllers
{
    public class EquipmentController : Controller
    {

        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var model =await _equipmentRepository.GetEquipments();

            return View(model);
        }


    }
}
