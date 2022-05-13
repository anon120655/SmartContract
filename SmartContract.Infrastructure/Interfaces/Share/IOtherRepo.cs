using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Share
{
    public interface IOtherRepo
    {
        string ParameterSearchOptionsAll(Pager resource);
        PaginationView<List<ContractStationDTO>> GetSearch(int? page, int pageSize, OtherSearchOption Condition = null);
    }
}
