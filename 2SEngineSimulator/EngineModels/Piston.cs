using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using _2SEngineSimulator.Interfaces;

namespace _2SEngineSimulator.EngineModels
{
    public class Piston : IPiston
    {
        public string ModelName { get; set; }

        public int strokeLen = 2;

        #region Piston Movement Events
        public void Up()
        {
            EngineStates.EchoEngineState(EngineStates.PistonUp + $"({this.ModelName})");
            WaitHandle[] waitHandles = new WaitHandle[2];
            for (int strokeMotionCycle = 0; strokeMotionCycle <= strokeLen; strokeMotionCycle++)
            {

                var CylinderCompressionHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                var CylinderCompression = new Thread(() =>
                {
                    CylinderCompressionProcess(strokeMotionCycle);
                    CylinderCompressionHandle.Set();
                });
                waitHandles[0] = CylinderCompressionHandle;
                CylinderCompression.Start();

                var IntakeHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                var Intake = new Thread(() =>
                {
                    IntakeProcess(strokeMotionCycle);
                    IntakeHandle.Set();
                });
                waitHandles[1] = IntakeHandle;
                Intake.Start();
            }
            WaitHandle.WaitAll(waitHandles);

            EngineStates.EchoEngineState(EngineStates.PistonUpComplete);
            EngineStates.EchoEngineState(EngineStates.FirstStrokeComplete);

            //Piston is at the Top where the SparkPlug is located. Time to Ignite it ! Perform a callback on the spark plug ignition process.
            Ignite((sparkPlug) => sparkPlug.Ignite());

        }

        public void Ignite(Action<SparkPlug> callback)
        {
            callback(new SparkPlug());
        }

        public void Down()
        {
            EngineStates.EchoEngineState(EngineStates.PistonDown + $"({this.ModelName})");
            WaitHandle[] waitHandles = new WaitHandle[2];
            for (int strokeMotionCycle = 0; strokeMotionCycle <= strokeLen; strokeMotionCycle++)
            {

                var CrankCaseHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                var CrankCaseCompression = new Thread(() =>
                {
                    CrankCaseCompressionProcess(strokeMotionCycle);
                    CrankCaseHandle.Set();
                });
                waitHandles[0] = CrankCaseHandle;
                CrankCaseCompression.Start();

                var TransferExhaustHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                var TransferExhaust = new Thread(() =>
                {
                    TransferExhaustProcess(strokeMotionCycle);
                    TransferExhaustHandle.Set();
                });
                waitHandles[1] = TransferExhaustHandle;
                TransferExhaust.Start();

            }
            WaitHandle.WaitAll(waitHandles);
            EngineStates.EchoEngineState(EngineStates.PistonDownComplete);
            EngineStates.EchoEngineState(EngineStates.SecondStrokeComplete);
        }

        #endregion


        #region ActionHandlers

        public bool IsCrankCaseCompressionComplete = false;
        public bool IsTransferExhaustComplete = false;
        public bool IsIntakeComplete = false;
        public bool IsCylinderCompressionComplete = false;


        public void CrankCaseCompressionProcess(int strokeCycle)
        {
            Console.WriteLine($"{strokeCycle} Piston Motion Cycle");
            Console.WriteLine("In Crank Case....CrankCase Compression");
            Console.WriteLine("Proppet Valve Closed");
            Console.WriteLine("Compress Fuel/Air Mixture");
            Thread.Sleep(1000);
            this.IsCrankCaseCompressionComplete = true;
        }

        public void TransferExhaustProcess(int strokeCycle)
        {
            Console.WriteLine($"{strokeCycle} Piston Motion Cycle");
            Console.WriteLine("In Cylinder....Transfer Exhaust Process");
            Console.WriteLine("Expel Exhaust Gases");
            Console.WriteLine("Fuel/Air Mixture Enters Cylinder");
            Thread.Sleep(1000);
            this.IsTransferExhaustComplete = true;
        }

        public void IntakeProcess(int strokeCycle)
        {
            Console.WriteLine($"{strokeCycle} Piston Motion Cycle");
            Console.WriteLine("In Crank Case....Intake Process");
            Console.WriteLine("Proppet Valve Open");
            Console.WriteLine("Fuel/Air Mixture Enters CrankCase");
            Thread.Sleep(1000);
            this.IsIntakeComplete = true;

            //raise Event MoveUp 1 inch
        }

        public void CylinderCompressionProcess(int strokeCycle)
        {
            Console.WriteLine($"{strokeCycle} Piston Motion Cycle");
            Console.WriteLine("In Cylinder....Cylider Compression Process");
            Console.WriteLine("Compress Fuel/Air Mixture");
            Thread.Sleep(1000);
            this.IsCylinderCompressionComplete = true;
        }

        #endregion
    }
}
