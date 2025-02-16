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
    public class GetManagersByTaxNumbersQueryHandler : IRequestHandler<GetManagersByTaxNumbersQuery, IEnumerable<string>>
    {
        private readonly IManagerRepository _managerRepository;
        // private readonly IMapper _mapper;
        private readonly ILogger<GetManagersByTaxNumbersQueryHandler> _logger;
        public GetManagersByTaxNumbersQueryHandler(IManagerRepository repository, ILogger<GetManagersByTaxNumbersQueryHandler> logger)
        {
            _managerRepository = repository;
            //_mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<string>> Handle(GetManagersByTaxNumbersQuery request, CancellationToken cancellationToken)
        {
            var result =  await _managerRepository.GetManagersTaxNumbersOrderedByNameAsync(m => m.Name,request.SortOrder);

            return result.Select(x => x.ToString()).ToList();
        }
    }
}
