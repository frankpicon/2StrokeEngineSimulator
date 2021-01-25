using System;
using System.Collections.Generic;
using System.Text;
using _2SEngineSimulator.Interfaces;

namespace _2SEngineSimulator.EngineModels
{
    public class RodController : IRodController
    {

        public string ModelName { get; set; }
       public Piston Piston { get; set; }

       public CrankShaft CrankShaft { get; set; }

        public RodController()
        {
        }
        public RodController(Piston piston, CrankShaft crankShaft)
        {
            this.Piston = piston;
            this.CrankShaft = crankShaft;
        }

        public void Move(IRodController.Direction direction)
        {
            switch (direction)
            {
                case IRodController.Direction.Up:
                    this.Piston.Up();
                    break;
                case IRodController.Direction.Down:
                    this.Piston.Down();
                    break;
            }
        }



    }
}
