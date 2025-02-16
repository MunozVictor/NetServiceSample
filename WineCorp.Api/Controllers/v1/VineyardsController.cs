using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCorp.App;

namespace WineCorp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VineyardsController
    {
        private readonly ILogger<VineyardsController> _logger;
        private readonly IMediator _mediator;

        public VineyardsController(IMediator mediator, ILogger<VineyardsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }



        [HttpGet("managers")]
        public async Task<IActionResult> GetGrapeAreaAsync()
        {
            var result = await _mediator.Send(new GetParcelVineyardsNamesWithManagersQuery());
            return new OkObjectResult(result);
        }

    }
}