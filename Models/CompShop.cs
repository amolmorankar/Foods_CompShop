using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Foods_CompShop.Models
{
    public class CompShop
    {
        public int CompShopId { get; set; }
        public string Dept { get; set; }

        public string ItemNo { get; set; }
        public string Description { get; set; }

        public string WHSE { get; set; }

        public string State { get; set; }

        public string MAC { get; set; }

        public string Sell { get; set; }

        public string IMU { get; set; }

        public string FutureSellPrice { get; set; }

        public string FutureSellDate { get; set; }

        public string LowestComp { get; set; }

        public string MaxPrice { get; set; }

        public string NewSell { get; set; }

        public string NewPrice { get; set; }

        public string SamsConvPrice { get; set; }

        public string SamsShelfPrice { get; set; }

        public string SamsAddtnPrice { get; set; }

        public string SamsShoppedURL { get; set; }
        public string SamsShoppedZip { get; set; }
        public string BJsConvPrice { get; set; }
        public string BJsShelfPrice { get; set; }
        public string BJsAddtnPrice { get; set; }
        public string BJsShoppedURL { get; set; }
        public string BJsShoppedZip { get; set; }
        public string BuyerNo { get; set; }

        public string Category { get; set; }

        public string BuyerComments { get; set; }

        public string PulledDate { get; set; }

//        public string StateMin { get; set; }

        public string Depot { get; set; }

        [NotMapped]
        int recordCnt { get; set; }

    }
}
