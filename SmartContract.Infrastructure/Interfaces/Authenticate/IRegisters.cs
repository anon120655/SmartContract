using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.Registers;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Authenticate
{
    public interface IRegisters
    {
        void ValidateUserCheck(RegisterMaster indata);

        Task<RegisterMaster> InitialData(RegisterMaster indata);
        void Validate(RegisterMaster indata);
        Task<RegisterMaster> GetView(string IdUserSmct = null, string email = null,String IdRegisterNhso =null);
        Task<RegisterMaster> CreateAsync(RegisterMaster indata);
        Task<RegisterMaster> UpdateAsync(RegisterMaster indata);

        Task<TrackingRegCheckMain> Dashboard(TrackingRegCheckMain indata);
        IList<TrackingRegCheckView> GetListRegCheck(SearchOptionRegCheck condition = null);
        PaginationView<List<TrackingRegCheckView>> GetTrackingRegCheck(int? page, int pageSize, SearchOptionRegCheck condition = null);

        Task<TrackingRegCheckMain> DashboardUser(TrackingRegCheckMain indata);
        IQueryable<TrackingRegCheckView> GetListRegCheckUser(SearchOptionRegCheck condition = null);
        PaginationView<List<TrackingRegCheckView>> GetTrackingRegCheckUser(int? page, int pageSize, SearchOptionRegCheck condition = null);

        Task<RegisterMaster> SaveStatus(RegisterMaster indata);

        //sent mail
        ResourceEmail GetMailVerify(RegisterMaster indata, string htmlBody);
    }
}
