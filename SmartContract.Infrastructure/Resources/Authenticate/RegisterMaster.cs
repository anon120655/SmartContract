using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.ContractTypeVendor;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Registers;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Authenticate
{
    public class RegisterMaster : RegisterNhsoDTO
    {
        public RegisterMaster()
        {
            ParameterCondition = new ParameterCondition();
            GetLookUp = new LookUpResource();
            UserSmct = new UserSmctDTO();
        }

        public ParameterCondition ParameterCondition { get; set; }
        public LookUpResource GetLookUp { get; set; }
        public RegisterNhso RegisterNhso { get; set; }
        public UserSmctDTO UserSmct { get; set; }
        public UserSmctVendorDTO UserSmctVendor { get; set; }
        public ApproveModel Approve { get; set; }
        /// <summary>
        /// ผู้เข้าใช้งานภายใต้หน่วยบริการ
        /// </summary>
        public List<TrackingRegCheckView> UsersUnderServiceUnit { get; set; }
        public string UrlDDOPA { get; set; }
        public string StateRandom { get; set; }
        public string ServerSite { get; set; }
    }
}
