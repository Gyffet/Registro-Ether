using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Ether.Dolares
{
    public class Payload
    {
        public long bucket_start_time { get; set; }
        public long first_trade_time { get; set; }
        public long last_trade_time { get; set; }
        public string first_rate { get; set; }
        public string last_rate { get; set; }
        public string min_rate { get; set; }
        public string max_rate { get; set; }
        public int trade_count { get; set; }
        public string volume { get; set; }
        public string vwap { get; set; }
    }

    public class USD
    {
        public bool success { get; set; }
        public Payload[] payload { get; set; }
    }
}
