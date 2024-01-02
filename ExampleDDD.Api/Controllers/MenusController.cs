using ExampleDDD.Application.Menus.Commands.CreateMenu;
using ExampleDDD.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDDD.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    [Authorize]
    public class MenusController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public MenusController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult = await _mediator.Send(command);

            return createMenuResult.Match(
                menu => Ok(_mapper.Map<MenuResponse>(menu)),
                errors => Problem(errors)
                );
        }
    }
}
