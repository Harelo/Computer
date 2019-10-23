using Computer.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Computer.Components
{
    /// <summary>
    /// For Von Neumann architacture based CPUs
    /// </summary>
    public class VonNeumannCPU
    {
        public Dictionary<int, Register> registers { get; set; }
        public IControlUnit controlUnit { get; set; }
        public Dictionary<string, IInstruction> instructionSet { get; set; }
        public IALU alu { get; set; }
        public IProgramCounter programCounter { get; set; }
        public Bus cpuBus { get; set; }
    }
}
