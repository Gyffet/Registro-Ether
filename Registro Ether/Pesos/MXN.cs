using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Ether.Pesos
{
    public class Payload
    {
        public object bucket_start_time { get; set; }
        public object first_trade_time { get; set; }
        public object last_trade_time { get; set; }
        public string first_rate { get; set; }
        public string last_rate { get; set; }
        public string min_rate { get; set; }
        public string max_rate { get; set; }
        public int trade_count { get; set; }
        public string volume { get; set; }
        public string vwap { get; set; }
    }

    public class MXN
    {
        public bool success { get; set; }
        public List<Payload> payload { get; set; }
    }
}
