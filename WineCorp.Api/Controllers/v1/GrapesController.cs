using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WineCorp.App;

namespace WineCorp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrapesController
    {
        private readonly ILogger<GrapesController> _logger;
        private readonly IMediator _mediator;

        public GrapesController(IMediator mediator, ILogger<GrapesController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }



        [HttpPost("area")]
        public async Task<IActionResult> GetGrapeAreaAsync()
        {
            var result = await _mediator.Send(new GetTotalParcelAreaByGrapeQuery());
            return new OkObjectResult(result);
        }
        
    }
}
