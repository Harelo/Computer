using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ControlUnit8b : CPUComponent, IControlUnit
    {
        /// <summary>
        /// The CPU with whose components the Control Unit will work
        /// </summary>
        private VonNeumannCPU cpu;
        public ControlUnit8b(VonNeumannCPU _cpu) : base(_cpu)
        {
            cpu = _cpu;
            cpuBus = cpu.cpuBus;
        }

        /// <summary>
        /// Setting the enable wire of a register to either on or off
        /// </summary>
        /// <param name="registerAddress">The address of the register</param>
        /// <param name="value">The value to which to set the enable wire</param>
        public void enable(int registerAddress, bool value) => cpu.registers[registerAddress].enable = value;

        /// <summary>
        /// Setting the set wire of a register to either on or off
        /// </summary>
        /// <param name="registerAddress">The address of the register</param>
        /// <param name="value">The value to which to set the set wire</param>
        public void set(int registerAddress, bool value) => cpu.registers[registerAddress].set = value;
    }
}
