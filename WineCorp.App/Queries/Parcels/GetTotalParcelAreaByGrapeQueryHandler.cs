using MediatR;
using Microsoft.Extensions.Logging;
using WineCorp.Dom;

namespace WineCorp.App
{
    public class GetTotalParcelAreaByGrapeQueryHandler : IRequestHandler<GetTotalParcelAreaByGrapeQuery, IDictionary<string, float>>
    {
        IParcelsRepository _parcelRepository;
        private readonly ILogger<GetTotalParcelAreaByGrapeQueryHandler> _logger;

        public GetTotalParcelAreaByGrapeQueryHandler(IParcelsRepository parcelRepository , ILogger<GetTotalParcelAreaByGrapeQueryHandler> logger)
        {
            _logger = logger;
            _parcelRepository = parcelRepository;
        }
        public async Task<IDictionary<string, float>> Handle(GetTotalParcelAreaByGrapeQuery request, CancellationToken cancellationToken)
        {
            return await _parcelRepository.GetTotalParcelAreaByGrapeAsync();
        }
    }
}
