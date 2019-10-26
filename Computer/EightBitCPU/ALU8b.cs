using Computer.Components;
using Computer.Helpers;
using Computer.Interfaces;
using System;
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
            inputBus = _cpuBus;

            outputBus = new Bus(8);

            flags = new BitArray(4, false);

            InputBRegister = new Register(8, inputBus, outputBus);
            InputBRegister.enableToBus = true;

            aluRegister = new Register(8, outputBus, inputBus);

            outputBus.BusUpdateEvent += (n) => InputB = new BitArray(n);
        }

        //Operations the ALU can perform
        public BitArray OR => inputBus.busValue.Or(InputB);
        public BitArray AND => inputBus.busValue.And(InputB);
        public BitArray NOT => inputBus.busValue.Not();
        public BitArray XOR
        {
            get
            {
                int bitAmount = inputBus.busValue.Length;
                bool aLarger = false, equalAbove = true, A, B, xor, and, not;

                for (int i = bitAmount; i >= 0; i--)
                {
                    A = inputBus.busValue[i];
                    B = InputB[i];

                    xor = A ^ B;
                    and = A & equalAbove & xor;
                    not = !xor;
                    equalAbove = not & equalAbove;
                    aLarger = aLarger | and;
                }

                return inputBus.busValue.Xor(InputB);
            }
        }

        public BitArray SHR => inputBus.busValue.RightShift(1);
        public BitArray SHL => inputBus.busValue.LeftShift(1);

        //One bit ripple carry adder used for ADD calculations
        private class OneBitRCA
        {
            public bool sum { get; set; }

            public bool Calculate(bool A, bool B, bool carryIn)
            {
                bool xor1 = A ^ B;
                bool carry1 = A & B;
                bool carry2 = xor1 & carryIn;
                bool cout = carry1 | carry2;
                sum = carryIn ^ xor1;

                return cout;
            }
        }

        //The add operation which is based on RCA binary addition
        public BitArray ADD
        {
            get
            {
                int bitAmount = inputBus.busValue.Length;
                OneBitRCA[] rcas = new OneBitRCA[bitAmount];
                BitArray result = new BitArray(bitAmount, false);
                bool cin = false;

                for (int i = 0; i < rcas.Length; i++)
                {
                    rcas[i] = new OneBitRCA();
                    cin = rcas[i].Calculate(inputBus.busValue[i], InputB[i], cin);
                    result[i] = rcas[i].sum;
                }

                return result;
            }
        }




        [Obsolete("Use ADD instead")]
        public void OldAdd()
        {
            BitArray A = inputBus.busValue;
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
