using System;
using System.Collections.Generic;
using System.Text;
using _2SEngineSimulator.EngineModels;

namespace _2SEngineSimulator.Interfaces
{

    public interface IEngine
    {
        string ModelName { get; set; }

        Piston Piston { get; }

        SparkPlug SparkPlug { get;  }

        RodController RodController { get; }

        CrankShaft CrankShaft { get; }

        void StartEngine();

    }


}
