using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ALU8b : IALU
    {
        private BitArray cpuBus;

        private BitArray flags { get; set; }

        private Register aluRegister { get; set; }

        public ALU8b(BitArray _cpuBus)
        {
            cpuBus = _cpuBus;
            flags = new BitArray(4, false);

        }

        public void PrintBus()
        {
            Binary.PrintBA(cpuBus);
        }

        public void OR(BitArray A, BitArray B) => aluRegister.set(A.Or(B));
        public void AND(BitArray A, BitArray B) => aluRegister.set(A.And(B));
        public void NOT(BitArray A) => aluRegister.set(A.Not());
        public void XOR(BitArray A, BitArray B) => aluRegister.set(A.Xor(B));
        public void SHR(BitArray A) => aluRegister.set(A.RightShift(1));
        public void SHL(BitArray A) => aluRegister.set(A.LeftShift(1));
        public void ROR(BitArray A, int c) => aluRegister.set(A.RightShift(c));
        public void LOR(BitArray A, int c) => aluRegister.set(A.LeftShift(c));

        public void CopyToCPUBus(BitArray data)
        {
            for (int i = 0; i < cpuBus.Length; i++)
                cpuBus[i] = data[i];

        }
    }
}
