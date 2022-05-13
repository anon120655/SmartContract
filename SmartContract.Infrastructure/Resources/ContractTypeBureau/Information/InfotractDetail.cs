using SmartContract.Infrastructure.Data.EntityFramework;
using SmartContract.Infrastructure.Resources.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeBureau.Information
{
    /// <summary>
    /// ข้อมูลรายละเอียดนิติกรรมสัญญา
    /// </summary>
    public class InfotractDetail
    {

        public InfotractDetail()
        {
            ContractDetail01 = new ContractDetail01DTO();
            ContractDetail02 = new ContractDetail02DTO();
            ContractDetail03 = new ContractDetail03DTO();
            ContractDetail04 = new ContractDetail04DTO();
            ContractDetail05 = new ContractDetail05DTO();
            ContractDetail06 = new ContractDetail06DTO();
            ContractDetail07 = new ContractDetail07DTO();
            ContractDetail08 = new ContractDetail08DTO();
            ContractDetail09 = new ContractDetail09DTO();
            ContractDetail10 = new ContractDetail10DTO();
            ContractDetail12 = new ContractDetail12DTO();
            ContractDetail13 = new ContractDetail13DTO();
            ContractDetail14 = new ContractDetail14DTO();
            ContractDetail11 = new ContractDetail11();
        }

        public ContractDetail01DTO ContractDetail01 { get; set; }
        public ContractDetail02DTO ContractDetail02 { get; set; }
        public ContractDetail03DTO ContractDetail03 { get; set; }
        public ContractDetail04DTO ContractDetail04 { get; set; }
        public ContractDetail05DTO ContractDetail05 { get; set; }
        public ContractDetail06DTO ContractDetail06 { get; set; }
        public ContractDetail07DTO ContractDetail07 { get; set; }
        public ContractDetail08DTO ContractDetail08 { get; set; }
        public ContractDetail09DTO ContractDetail09 { get; set; }
        public ContractDetail10DTO ContractDetail10 { get; set; }
        public ContractDetail12DTO ContractDetail12 { get; set; }
        public ContractDetail13DTO ContractDetail13 { get; set; }
        public ContractDetail14DTO ContractDetail14 { get; set; }
        public ContractDetail11 ContractDetail11 { get; set; }

    }
}
