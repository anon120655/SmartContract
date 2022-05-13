using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Utils
{
    public static class GroupRoles
    {
        public static PermissionRole[] GroupRoleAdmin =
            {
            PermissionRole.SystemAdmin,
            PermissionRole.CentralAdmin,
            PermissionRole.CentralUser,
            PermissionRole.KetSigner,
            PermissionRole.KetOfficer
        };
        public static PermissionRole[] GroupRoleUnit =
            {
            PermissionRole.Signer1,
            PermissionRole.Signer2,
            PermissionRole.Coordinator,
            PermissionRole.User
        };
    }
}
