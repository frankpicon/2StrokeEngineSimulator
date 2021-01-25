using System;
using System.Threading;
using _2SEngineSimulator.EngineModels;

namespace _2SEngineSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize the Engine Parts
            Piston piston = new Piston { ModelName = "AwesomePistons" };
            SparkPlug sparkPlug = new SparkPlug { ModelName = "BurningHotSparks" };
            CrankShaft crankShaft = new CrankShaft { ModelName = "CrankyShafts" };
            RodController rodController = new RodController{ ModelName = "2inchRod"};

            EngineModels._2SEngine FP2SEngine = new _2SEngine(sparkPlug, piston, crankShaft, rodController) { ModelName = "Frank Picon Engine" };
            
            Console.Write("Hit the ENTER key to START the 2 Stroke Engine."); 
            Console.Read();
            FP2SEngine.StartEngine();
        }

    }

   



}
