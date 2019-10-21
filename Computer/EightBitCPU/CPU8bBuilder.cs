using Computer.Components.Helpers;
using Computer.EightBitCPU;
using Computer.Interfaces;
using System.Collections.Generic;

namespace Computer.Components.EightBitCPU
{
    public class CPU8bBuilder : CPUBuilder
    {
        public override void BuildALU() => cpu.alu = new ALU8b();

        public override void BuildControlUnit() => cpu.controlUnit = new ControlUnit8b();

        public override void BuildInstructionSet() => cpu.instructionSet = new Dictionary<string, IInstruction>();
    }
}
