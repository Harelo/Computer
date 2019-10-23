using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ALU8b : CPUComponent, IALU
    {
        /// <summary>
        /// The outputBus of the ALU
        /// </summary>
        private Bus outputBus;

        /// <summary>
        /// The ALU's flags
        /// </summary>
        private BitArray flags { get; set; }

        /// <summary>
        /// A register used for storing operation results from the ALU
        /// </summary>
        public Register aluRegister { get; set; }

        // A register for input B
        private Register InputBRegister;

        //Takes its' value from InputB register
        private BitArray InputB;

        /// <summary>
        /// The constructor for the ALU to initalize some parameters
        /// </summary>
        /// <param name="_cpuBus">The CPU's bus reference to be held by the ALU</param>
        public ALU8b(Bus _cpuBus, VonNeumannCPU cpu) : base(cpu)
        {
            cpuBus = _cpuBus;

            outputBus = new Bus(8);

            flags = new BitArray(4, false);

            InputBRegister = new Register(8, cpuBus, outputBus);
            InputBRegister.enableToBus = true;

            aluRegister = new Register(8, outputBus, cpuBus);

            outputBus.BusUpdateEvent += (n) => InputB = new BitArray(n);
        }

        //Operations the ALU can perform
        public void OR() => outputBus.busValue = cpuBus.busValue.Or(InputB);
        public void AND() => outputBus.busValue = cpuBus.busValue.And(InputB);
        public void NOT() => outputBus.busValue = cpuBus.busValue.Not();
        public void XOR() => outputBus.busValue = cpuBus.busValue.Xor(InputB);
        public void SHR() => outputBus.busValue = cpuBus.busValue.RightShift(1);
        public void SHL() => outputBus.busValue = cpuBus.busValue.LeftShift(1);
        public void ROR(int c) => outputBus.busValue = cpuBus.busValue.RightShift(c);
        public void LOR(int c) => outputBus.busValue = cpuBus.busValue.LeftShift(c);

        //The add operation which is based on RCA binary addition
        public void ADD()
        {
            BitArray A = cpuBus.busValue;
            BitArray B = InputB;

            var cin = new BitArray(A.Length + 1);
            var xor1 = new BitArray(A).Xor(B); //First XOR
            xor1.Length += 1;
            var carry1 = new BitArray(A).And(B); //Carry from first XOR
            var carry2 = new BitArray(A.Length);

            for (int i = 0; i < A.Length; i++) //A loop for calculating the carries to second XOR
            {
                carry2[i] = cin[i] & xor1[i];
                cin[i + 1] = carry1[i] | carry2[i];
            }

            var xor2 = new BitArray(xor1).Xor(cin); //Second XOR which cpuBuss the result

            outputBus.busValue = xor2;
        }
    }
}
