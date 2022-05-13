using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.DTO
{
    public class UserSmctDTO
    {
        public UserSmctDTO()
        {
            UserSmctSigners = new UserSmctSignerDTO();
        }

        public string IdUserSmct { get; set; }
        public string IdUserLevel { get; set; }
        public string DepartmentCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserFullname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string Email { get; set; }
        public string Cid { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string PositionName { get; set; }
        public bool Used { get; set; }
        public DateTime? Birthday { get; set; }
        public string BirthdayStr { get; set; }
        public string Laser { get; set; }
        public string IdRegisterNhso { get; set; }
        public string VendorId { get; set; }
        public string SignerType { get; set; }
        public string RegisterType { get; set; }
        public string VendorName { get; set; }
        public UserRightDTO UserRights { get; set; }
        public UserRoleDTO UserRoles { get; set; }
        public IList<UserLevelDTO> UserLevels { get; set; }
        public UserSmctSignerDTO UserSmctSigners { get; set; }
    }
}
