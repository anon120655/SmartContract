using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Resources.Guarantee
{
	public class DashboardLG
	{

		public int DefualtCount { get; set; }
		public int CreatedCount { get; set; }
		public int ExtendedCount { get; set; }
		public int IncreasedCount { get; set; }
		public int DecreasedCount { get; set; }
		public int ClaimedCount { get; set; }

		public int SumCount()
		{
			return DefualtCount + CreatedCount + ExtendedCount + IncreasedCount + DecreasedCount + ClaimedCount;
		}
		public int ApproveCount()
		{
			return CreatedCount + ExtendedCount + IncreasedCount + DecreasedCount + ClaimedCount;
		}

	}
}
