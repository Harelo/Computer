using Computer.Components;
using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ALU8b : IALU
    {
        private BitArray cpuBus;
        public BitArray flags { get; set; }

        public ALU8b(BitArray _cpuBus)
        {
            cpuBus = _cpuBus;
            flags = new BitArray(4, false);
        }

        public void OR(BitArray A, BitArray B) => cpuBus = A.Or(B);
        public void AND(BitArray A, BitArray B) => cpuBus = A.And(B);
        public void NOT(BitArray A) => cpuBus = A.Not();
        public void XOR(BitArray A, BitArray B) => cpuBus = A.Xor(B);
        public void SHR(BitArray A) => cpuBus = A.RightShift(1);
        public void SHL(BitArray A) => cpuBus = A.LeftShift(1);
        public void ROR(BitArray A, int c) => cpuBus = A.RightShift(c);
        public void LOR(BitArray A, int c) => cpuBus = A.LeftShift(c);

    }
}
