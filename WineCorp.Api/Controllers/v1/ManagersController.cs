using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WineCorp.App;
using WineCorp.Dto;


namespace WineCorp.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly ILogger<ManagersController> _logger;
        private readonly IMediator _mediator;

        public ManagersController(IMediator mediator,ILogger<ManagersController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "ids")]
        public async Task<IActionResult> GetManagersIds()
        {
            //Crea un método que devuelva una lista de los identificadores de todos los gerentes.
            try
            {
                var result = await _mediator.Send(new GetManagersIdsQuery());

                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los identificadores de los gerentes");
            }
            return BadRequest();
        }


        //Gerentes Ordenados por Nombre: Devuelve los números fiscales de los gerentes ordenados alfabéticamente por su nombre. Endpoint: GET /managers/taxnumbers? sorted = true
        [HttpGet("taxnumbers")]
        public async Task<IActionResult> GetManagersByTaxNumbers([FromQuery] bool sorted = false)
        {
            try
            {
                var sortOrder = SortOrder.None;

                if (sorted) 
                {
                    sortOrder = SortOrder.Descending;
                }

                var result = await _mediator.Send(new GetManagersByTaxNumbersQuery() { SortOrder = sortOrder });

                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los números fiscales de los gerentes");
            }
            return BadRequest();
        }


        [HttpPost("totalarea")]
        public async Task<IActionResult> GetManagerAreaAsync()
        {
            var result = await _mediator.Send(new GetTotalParcelAreaByManagerQuery());
            return new OkObjectResult(result);
        }





    }
}
