using System;
using System.Collections.Generic;
using System.Text;
using _2SEngineSimulator.Interfaces;

namespace _2SEngineSimulator.EngineModels
{
    public class SparkPlug : ISparkPlug
    {
        public string ModelName { get; set; }
        public void Ignite()
        {
            Console.WriteLine($"BBBBBBOOOOOOOOOOOOOOOOOOOOOOOMMMMMMMMMMMMMMMM.........BBBBBBOOOOOOOOOOOOOOOOOOMMMMMMMMMMM.........IGNITE!!! BURNING!!");
        }
    }
}
