using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaSupportApi.ExternalCurrencyClient
{
    public class Currency
    {
        public string Base { get; set; }

        public string Date { get; set; }
        
        public List<Rate> Rates { get; set; }
    }

    public class Rate
    {
        public string Code { get; set; }

        public decimal Mid { get; set; }
    }
}