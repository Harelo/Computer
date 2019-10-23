using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ProgramCounter8b : CPUComponent, IProgramCounter
    {
        private Register currentAddressRegister;

        public BitArray CurrentAddress
        {
            get => cpuBus.busValue;
            set => currentAddressRegister.setFromBus = true;
        }

        public ProgramCounter8b(Bus _cpuBus, VonNeumannCPU cpu) : base(cpu)
        {
            cpuBus = _cpuBus;
            currentAddressRegister = new Register(8, cpuBus, cpuBus);
        }
    }
}
