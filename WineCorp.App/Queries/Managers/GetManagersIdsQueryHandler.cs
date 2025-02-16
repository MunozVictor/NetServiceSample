using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WineCorp.Dom;

namespace WineCorp.App
{
    public class GetManagersIdsQueryHandler : IRequestHandler<GetManagersIdsQuery, IEnumerable<int>>
    {
        private readonly IManagerRepository _managerRepository;
       // private readonly IMapper _mapper;
        private readonly ILogger<GetManagersIdsQueryHandler> _logger;
        public GetManagersIdsQueryHandler(IManagerRepository repository, ILogger<GetManagersIdsQueryHandler> logger )
        {
            _managerRepository = repository;
            //_mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<int>> Handle(GetManagersIdsQuery request, CancellationToken cancellationToken)
        {
            return await _managerRepository.GetManagersIdsAsync();
        }
    }   
}
