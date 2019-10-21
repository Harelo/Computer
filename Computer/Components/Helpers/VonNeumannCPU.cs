using Computer.EightBitCPU;
using Computer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components.Helpers
{
    public class VonNeumannCPU : ICPU
    {
        public IControlUnit controlUnit { get; set; }
        public Dictionary<string, IInstruction> instructionSet { get; set; }
        public IALU alu { get; set; }
        public ProgramCounter8b programCounter { get; set; }
    }
}
