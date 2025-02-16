using MediatR;
using WineCorp.Dto;

namespace WineCorp.App
{
    public class GetManagersByTaxNumbersQuery : IRequest<IEnumerable<string>>
    {
        public SortOrder SortOrder { get; set; }
    }
}
