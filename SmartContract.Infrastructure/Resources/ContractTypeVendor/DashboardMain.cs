using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.ContractTypeVendor
{
    public class DashboardMain
    {
        public DashboardMain()
        {
            Dashboards = new List<Dashboards>();
            DashboardFReturn = new List<DashboardFReturn>();
        }

        public List<Dashboards> Dashboards { get; set; }
        public List<DashboardFReturn> DashboardFReturn { get; set; }


    }
}
