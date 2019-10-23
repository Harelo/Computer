using Computer.Helpers;
using Computer.Interfaces;
using System.Collections.Generic;
using Computer.Components;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class CPU8bBuilder : CPUBuilder
    {
        public CPU8bBuilder()
        {
            cpu = new VonNeumannCPU();
        }

        public override void BuildALU() => cpu.alu = new ALU8b(cpu.cpuBus, cpu);

        public override void BuildControlUnit() => cpu.controlUnit = new ControlUnit8b(cpu);

        public override void BuildInstructionSet() => cpu.instructionSet = new Dictionary<string, IInstruction>();

        public override void BuildProgramCounter() => cpu.programCounter = new ProgramCounter8b(cpu.cpuBus, cpu);

        public override void BuildRegisters()
        {
            cpu.registers = new Dictionary<int, Register>();

            for (int i = 0; i < 4; i++)
                cpu.registers[i] = new Register(8, cpu.cpuBus, cpu.cpuBus);
        }

        public override void BuildCPUBus() => cpu.cpuBus = new Bus(8);
    }
}
