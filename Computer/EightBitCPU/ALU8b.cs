using Computer.Interfaces;
using System.Collections;

namespace Computer.EightBitCPU
{
    public class ALU8b : IALU
    {
        public BitArray OR(BitArray A, BitArray B) => A.Or(B);
        public BitArray AND(BitArray A, BitArray B) => A.And(B);
        public BitArray NOT(BitArray A) => A.Not();
        public BitArray XOR(BitArray A, BitArray B) => A.Xor(B);
        public BitArray SHR(BitArray A) => A.RightShift(1);
        public BitArray SHL(BitArray A) => A.LeftShift(1);
        public BitArray ROR(BitArray A, int c) => A.RightShift(c);
        public BitArray LOR(BitArray A, int c) => A.LeftShift(c);

    }
}
