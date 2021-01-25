using System;
using System.Collections.Generic;
using System.Text;

namespace _2SEngineSimulator.Interfaces
{
    interface IPiston
    {
        string ModelName { get; set; }
        void Up();
        void Down();
    }
}
