using System;
using System.Collections.Generic;
using System.Text;

namespace _2SEngineSimulator.Interfaces
{
    interface ISparkPlug
    {
        string ModelName { get; set; }
        void Ignite();
    }
}
