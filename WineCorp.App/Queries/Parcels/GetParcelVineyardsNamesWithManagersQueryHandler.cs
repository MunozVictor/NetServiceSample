using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCorp.Dom;

namespace WineCorp.App.Queries.Parcels
{
    public class GetParcelVineyardsNamesWithManagersQueryHandler : IRequestHandler<GetParcelVineyardsNamesWithManagersQuery, IDictionary<string, List<string>>>
    {

        IParcelsRepository _parcelRepository;
        private readonly ILogger<GetParcelVineyardsNamesWithManagersQueryHandler> _logger;
        public GetParcelVineyardsNamesWithManagersQueryHandler(IParcelsRepository parcelsRepository, ILogger<GetParcelVineyardsNamesWithManagersQueryHandler> logger)
        {
            _parcelRepository = parcelsRepository;
            _logger = logger;
        }

        public async Task<IDictionary<string, List<string>>> Handle(GetParcelVineyardsNamesWithManagersQuery request, CancellationToken cancellationToken)
        {
            return await _parcelRepository.GetParcelVineyardsNamesWithManagersAsync();
        }
    }
}
