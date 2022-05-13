using ServiceIAMAuthentication;
using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.Authenticate;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Other;
using SmartContract.Infrastructure.Resources.Share;
using SmartContract.Infrastructure.Resources.Share.ServiceOther;
using SmartContract.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Interfaces.Authenticate
{
    public interface IUserService
    {
        string GetIdUserSmct();
        string GetEmail();
        PermissionRole GetRoleRoleCode();
        string GetRoleShotName();
        string GetRoleFullName();
        string GetUserName();
        string GetUserFullName();
        string GetDepartmentCode();
        string GetVendorId();
        string GetVendorName();
        string GetRegisterType();
        Task<UserSmctDTO> GetUserByCID(string CID);
        Task<UserSmctDTO> LocalAuthen(UserLogin iuser, bool? IsPortal = null);
        Task AddUserInfoByiAm(authenAndUserInfoResponse indata, String PassWord);
        //DDOPA
        Task<DDOPALogin> DDOPAAuthen(DDOPALogin iuser);
        ResourceEmail CheckMailPassCode(CheckPassCode resource, string htmlBody, string email);
        Task<IEnumerable<UserRole>> UserRoles(String userRoleCode = null, String GroupRole = null);
        Task LogUser(string idUserSmct);
        int CountlogUser();
        Task ChangePassword(ChangePasswordMain indata);
    }
}
