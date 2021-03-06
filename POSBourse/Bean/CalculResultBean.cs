﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBourse.Bean
{
    public class CalculResultBean
    {
        public decimal totalAPayer { get; set; }
        public decimal resteAPayer { get; set; }
        public decimal ARendre { get; set; }
        public decimal monnaiePayee { get; set; }
        public decimal monnaiePayeeESP { get; set; }
        public decimal monnaiePayeeCB { get; set; }
        public decimal monnaiePayeeCHEQUE { get; set; }
        public decimal totalRemise { get; set; }
        public decimal totalAvoir { get; set; }
        public decimal totalEchange { get; set; }
        public decimal totalEchangeAndAvoir { get; set; }
        public decimal totalEchangeDirect { get; set; }
        public decimal totalReductions { get; set; }
        public decimal totalProduits { get; set; }
        public decimal ARendreAvoir { get; set; }
        public decimal avoirUtil { get; set; }
        public decimal avoirConverti { get; set; }
        public decimal ARendreESP { get; set; }
        public decimal ARendreReelESP { get; set; }
        public decimal monnaiePayeeReelESP { get; set; }
        public int productCount { get; set; }
        public decimal totalEchangeAndAvoirUtil { get; set; }
        public decimal avoirEchangeConverti { get; set; }
        public decimal totalBonCadeau { get; set; }
    }
}
