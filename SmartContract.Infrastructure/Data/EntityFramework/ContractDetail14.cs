﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SmartContract.Infrastructure.Data.EntityFramework
{
    public partial class ContractDetail14
    {
        public string IdContractDetail14 { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime EditDate { get; set; }
        public string EditUser { get; set; }
        public string IdContract { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P6 { get; set; }
        public string P7 { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        public string P10 { get; set; }
        public string P11 { get; set; }
        public string P12 { get; set; }
        public string P13 { get; set; }
        public string P14 { get; set; }
        public string P15 { get; set; }
        public string P16 { get; set; }
        public string P17 { get; set; }
        public string P18 { get; set; }
        public string P19 { get; set; }
        public string P20 { get; set; }
        public string P21 { get; set; }
        public string P22 { get; set; }
        public string P23 { get; set; }
        public string P24 { get; set; }
        public string P25 { get; set; }
        public string P26 { get; set; }
        public string P27 { get; set; }
        public string P28 { get; set; }
        public string P29 { get; set; }
        public string P30 { get; set; }
        public string P31 { get; set; }
        public string P32 { get; set; }
        public string P33 { get; set; }
        public string P34 { get; set; }
        public string P35 { get; set; }
        public string P36 { get; set; }
        public bool Used { get; set; }

        public virtual UserSmct CreateUserNavigation { get; set; }
        public virtual UserSmct EditUserNavigation { get; set; }
        public virtual Contract IdContractNavigation { get; set; }
    }
}