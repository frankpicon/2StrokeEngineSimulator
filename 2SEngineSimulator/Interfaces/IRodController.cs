using System;
using System.Collections.Generic;
using System.Text;
using _2SEngineSimulator.EngineModels;

namespace _2SEngineSimulator.Interfaces
{
    public interface IRodController
    {
        Piston Piston { get; set; }

        CrankShaft CrankShaft { get; set; }

        string ModelName { get; set; }
        void Move(Direction direction);
        public enum Direction
        {
            Up = 0,
            Down = 1
        }

    }
}
