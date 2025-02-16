using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCorp.Dom;

namespace WineCorp.App
{
    public class GetTotalParcelAreaByManagerQueryHandler : IRequestHandler<GetTotalParcelAreaByManagerQuery, IDictionary<string, float>>
    {
        IParcelsRepository _parcelRepository;
        private readonly ILogger<GetTotalParcelAreaByManagerQueryHandler> _logger;
        public GetTotalParcelAreaByManagerQueryHandler(IParcelsRepository parcelsRepository , ILogger<GetTotalParcelAreaByManagerQueryHandler> logger)
        {
            _parcelRepository = parcelsRepository;
            _logger = logger;
        }
        public async Task<IDictionary<string, float>> Handle(GetTotalParcelAreaByManagerQuery request, CancellationToken cancellationToken)
        {
            return await _parcelRepository.GetTotalParcelAreaByManagerAsync();
        }
    }
}
