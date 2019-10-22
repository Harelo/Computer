using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ALU8b : CPUComponent, IALU
    {
        /// <summary>
        /// The output of the ALU
        /// </summary>
        private BitArray output;

        /// <summary>
        /// The ALU's flags
        /// </summary>
        private BitArray flags { get; set; }

        /// <summary>
        /// A register used for storing operation results from the ALU
        /// </summary>
        private Register aluRegister { get; set; }

        // A register for input B
        private Register InputB;

        /// <summary>
        /// The constructor for the ALU to initalize some parameters
        /// </summary>
        /// <param name="_cpuBus">The CPU's bus reference to be held by the ALU</param>
        public ALU8b(BitArray _cpuBus, VonNeumannCPU cpu) : base(cpu)
        {
            cpuBus = _cpuBus;
            flags = new BitArray(4, false);
            InputB = new Register(8, cpuBus, output);
        }

        //Operations the ALU can perform

        public void OR() => output = cpuBus.Or(InputB.enableToInput());
        public void AND() => output = cpuBus.And(InputB.enableToInput());
        public void NOT() => output = cpuBus.Not();
        public void XOR() => output = cpuBus.Xor(InputB.enableToInput());
        public void SHR() => output = cpuBus.RightShift(1);
        public void SHL() => output = cpuBus.LeftShift(1);
        public void ROR(int c) => output = cpuBus.RightShift(c);
        public void LOR(int c) => output = cpuBus.LeftShift(c);

        //The set wire, setting the alu's register to the output of it
        public void set()
        {
            cpuBus = output;
            aluRegister.setFromBus = true;
        }

        //The enable wire, enabling the alu register to send its value along the cpu bus
        public void enable()
        {
            for (int i = 0; i < cpuBus.Length; i++)
                cpuBus[i] = aluRegister[i];

        }
    }
}
