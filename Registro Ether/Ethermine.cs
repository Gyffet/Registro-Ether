using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Ether
{
    public class Ethermine
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

    public class Statistic
    {
        public int time { get; set; }
        public int reportedHashrate { get; set; }
        public double currentHashrate { get; set; }
        public int validShares { get; set; }
        public int invalidShares { get; set; }
        public int staleShares { get; set; }
        public int activeWorkers { get; set; }
    }

    public class Worker
    {
        public string worker { get; set; }
        public int time { get; set; }
        public int lastSeen { get; set; }
        public int reportedHashrate { get; set; }
        public double currentHashrate { get; set; }
        public int validShares { get; set; }
        public int invalidShares { get; set; }
        public int staleShares { get; set; }
    }

    public class CurrentStatistics
    {
        public int time { get; set; }
        public int lastSeen { get; set; }
        public int reportedHashrate { get; set; }
        public double currentHashrate { get; set; }
        public int validShares { get; set; }
        public int invalidShares { get; set; }
        public int staleShares { get; set; }
        public int activeWorkers { get; set; }
        public long unpaid { get; set; }
    }

    public class Settings
    {
        public string email { get; set; }
        public int monitor { get; set; }
        public long minPayout { get; set; }
        public int suspended { get; set; }
    }

    public class Data
    {
        public List<Statistic> statistics { get; set; }
        public List<Worker> workers { get; set; }
        public CurrentStatistics currentStatistics { get; set; }
        public Settings settings { get; set; }
    }
}