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
        //Registers below

        //Registers used for general purposes
        public Dictionary<int, Register> generalPurposeRegisters { get; set; }

        //A special register used for storing the next instruction to be executed
        public Register programCounter { get; set; }

        //The Memory Address Register
        public Register MAR { get; set; }

        //Other different componenets of the CPU
        public IControlUnit controlUnit { get; set; }

        public Dictionary<string, IInstruction> instructionSet { get; set; }
        public IALU alu { get; set; }
        public Bus cpuBus { get; set; }
    }
}
