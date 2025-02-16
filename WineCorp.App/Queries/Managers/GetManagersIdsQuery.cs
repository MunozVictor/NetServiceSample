using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCorp.App
{
    public class GetManagersIdsQuery : IRequest<IEnumerable<int>>
    {
    }
}
