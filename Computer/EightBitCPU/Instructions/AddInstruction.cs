using Computer.Interfaces;
using System;
using System.Collections;

namespace Computer.EightBitCPU.Instructions
{
    public class AddInstruction : IInstruction
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// An RCA algorithem for adding two binary numbers
        /// </summary>
        /// <returns>A BitArray with the two binary numbers added</returns>
        public object Execute(object parameter)
        {
            BitArray A = ((BitArray[])parameter)[0];
            BitArray B = ((BitArray[])parameter)[1];

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

            var xor2 = new BitArray(xor1).Xor(cin); //Second XOR which outputs the result

            return xor2;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}

