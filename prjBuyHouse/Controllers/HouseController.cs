using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prjBuyHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHouseList()
        {
            return null;
        }

        [HttpPost]
        public IActionResult CreateNewHouse()
        {
            return null;
        }

        [HttpDelete]
        public IActionResult DeleteHouse()
        {
            return null;
        }

        [HttpPatch]
        public IActionResult UpdateHouse() 
        {
            return null;
        }
    }
}
