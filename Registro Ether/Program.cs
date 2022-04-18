using Newtonsoft.Json;
using Registro_Ether.Dolares;
using Registro_Ether.Pesos;
using Spire.Xls;
using System;


namespace Registro_Ether
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main()
        {
            Program program = new Program();
            await program.GetResultado();
        }

        private async Task GetResultado()
        {
            string responsePool = await client.GetStringAsync("https://api.ethermine.org/miner/0x8438a012b6d2c43b8615d7d67a42883b2e69ea7c/dashboard");
            var poolResult = JsonConvert.DeserializeObject<Ethermine>(responsePool);
            var saldoP = Math.Round(poolResult.data.currentStatistics.unpaid * 0.000000000000000001, 5);

            string responseMXN = await client.GetStringAsync("https://bitso.com/api/v3/ohlc?book=eth_mxn&time_bucket=86400");
            MXN mxnResult = JsonConvert.DeserializeObject<MXN>(responseMXN);
            var listaMXN = mxnResult.payload.ToArray();
            var ultimoMXN = listaMXN[listaMXN.Length - 1];


            string responseUSD = await client.GetStringAsync("https://bitso.com/api/v3/ohlc?book=eth_usd&time_bucket=86400");
            USD usdResult = JsonConvert.DeserializeObject<USD>(responseUSD);
            var ultimoUSD = usdResult.payload[usdResult.payload.Length - 1];


            Workbook workbook = new Workbook();
            //workbook.LoadFromFile("D:\\Documents\\Minero\\Estadisticas.xlsx");
            workbook.LoadFromFile("C:\\Users\\Rig\\Documents\\Minero_Remoto\\Estadisticas.xlsx");

            Worksheet hoja = workbook.Worksheets[0];
            int lastFilledRow = hoja.LastRow;
            for (int i = hoja.LastRow; i >= 0; i--)
            {
                CellRange cr = hoja.Rows[i - 1].Columns[0];
                if (!cr.IsBlank)
                {
                    lastFilledRow = i;
                    break;
                }
            }
            //to find the last filled row of this column


            string pETH = "A" + (lastFilledRow + 1).ToString();
            string pUSD = "B" + (lastFilledRow + 1).ToString();
            string pMXN = "C" + (lastFilledRow + 1).ToString();
            string gETH = "D" + (lastFilledRow + 1).ToString();
            string gUSD = "E" + (lastFilledRow + 1).ToString();
            string gMXN = "F" + (lastFilledRow + 1).ToString();
            string toUSD = "G" + (lastFilledRow + 1).ToString();
            string toMXN = "H" + (lastFilledRow + 1).ToString();
            string fecha = "I" + (lastFilledRow + 1).ToString();

            hoja.Range[pETH].Text = saldoP.ToString();
            hoja.Range[pUSD].Formula = "=" + pETH + "*" + toUSD;
            hoja.Range[pMXN].Formula = "=" + pETH + "*" + toMXN;
            hoja.Range[gETH].Formula = "=" + pETH + "-" + ("A" + (lastFilledRow).ToString());
            hoja.Range[gUSD].Formula = "=" + pUSD + "-" + ("B" + (lastFilledRow).ToString());
            hoja.Range[gMXN].Formula = "=" + pMXN + "-" + ("C" + (lastFilledRow).ToString());
            hoja.Range[toMXN].Text = ultimoMXN.last_rate.ToString();
            hoja.Range[toUSD].Text = ultimoUSD.last_rate.ToString();
            hoja.Range[fecha].DateTimeValue = DateTime.Now;
            workbook.Save();

            System.Environment.Exit(1);
        }
    }
}
