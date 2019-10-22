using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ProgramCounter8b : IProgramCounter
    {
        private BitArray cpuBus;

        private Register currentAddressRegister;

        public BitArray CurrentAddress
        {
            get => currentAddressRegister.enable();
            set => currentAddressRegister.set(value);
        }

        public ProgramCounter8b(BitArray _cpuBus)
        {
            cpuBus = _cpuBus;
            currentAddressRegister = new Register(8);
        }
    }
}
