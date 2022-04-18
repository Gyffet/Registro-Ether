using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Registro_Ether
{
    class Respuesta
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task getRespuesta()
        {

            HttpResponseMessage response = await client.GetAsync("https://api.ethermine.org/miner/bC3DEa67404aAB0a70b0A0a0732c8d57bBA40c76/dashboard");

            //https://bitso.com/api/v3/ohlc?book=eth_mxn&time_bucket=86400 valor ether a mxn

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();


            //var resultadofrefe = JsonSerializer.Deserialize<dynamic>(responseBody);




            var resultadoPool = JsonConvert.DeserializeObject<Ethermine>(responseBody);




            Ethermine ether = new Ethermine();


            //var twghwrtgw = resultadoPool.Currentstatistics;
            //var rtgsvbwb = JsonConvert.DeserializeObject<Ethermine>(responseBody);
            //var fre=rtgsvbwb.ToString();
        }



    }
}


//{
//    { "status":"OK",
//      "data":{
//            "statistics":[{
//                "time":1637536200,
//                "reportedHashrate":90239922,
//                "currentHashrate":88644705.41416667,
//                "validShares":73,
//                "invalidShares":0,
//                "staleShares":2,
//                "activeWorkers":1
//            },
//            {
//                "time":1637536800,
//                "reportedHashrate":90764492,
//                "currentHashrate":79100188.0075,
//                "validShares":65,"invalidShares":0,
//                "staleShares":2,"activeWorkers":1
//            }]
//      },

//      "currentStatistics":{
//            "time":1637622000,
//            "lastSeen":1637621898,
//            "reportedHashrate":89533450,
//            "currentHashrate":98606795.4575,
//            "validShares":82,
//            "invalidShares":1,
//            "staleShares":1,
//            "activeWorkers":1,
//            "unpaid":19279806983530504},
//       "settings":{ "email":"","monitor":0,"minPayout":100000000000000000,"suspended":0} } }