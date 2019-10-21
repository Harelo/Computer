using Computer.EightBitCPU;
using Computer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components.Interfaces
{
    /// <summary>
    /// For Von Neumann architacture based CPUs
    /// </summary>
    public interface IVonNeumannCPU
    {
        IControlUnit controlUnit { get; set; }
        Dictionary<string, IInstruction> instructionSet { get; set; }
        IALU alu { get; set; }
        ProgramCounter8b programCounter { get; set; }
    }
}
