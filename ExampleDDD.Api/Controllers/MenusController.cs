using ExampleDDD.Contracts.Menus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDDD.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    [Authorize]
    public class MenusController : ApiController
    {
        [HttpPost]
        public IActionResult CreateMenu(CreateMenuRequest request, string hostId)
        {
            return Ok(request);
        }
    }
}
