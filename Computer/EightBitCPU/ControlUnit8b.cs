using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ControlUnit8b : IControlUnit
    {
        private VonNeumannCPU cpu;
        public ControlUnit8b(VonNeumannCPU _cpu)
        {
            cpu = _cpu;
        }

        /// <summary>
        /// Allows setting a value in a register
        /// </summary>
        /// <param name="register">The register to which to write the data</param>
        /// <param name="data">The data to write</param>
        public void set(int register, BitArray data) => cpu.registers[register].set(data);
    }
}
