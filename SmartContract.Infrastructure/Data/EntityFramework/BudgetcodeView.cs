using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class BudgetcodeView
    {
        public string Budgetyear { get; set; }
        public string Budgetcode { get; set; }
        public decimal? Remain { get; set; }
    }
}
