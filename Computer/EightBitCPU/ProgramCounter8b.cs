using Computer.Components;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ProgramCounter8b
    {
        private Register currentAddressRegister;

        public BitArray CurrentAddress
        {
            get => currentAddressRegister.Value;
            set => currentAddressRegister.Value = value;
        }

        public ProgramCounter8b()
        {
            currentAddressRegister = new Register(8);
        }
    }
}
