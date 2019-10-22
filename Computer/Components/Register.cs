using System;
using System.Collections;
using System.Linq.Expressions;

namespace Computer.Components
{
    public class Register
    {
        private BitArray bits { get; set; }

        /// <summary>
        /// An indexer for the register
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool this[int i]
        {
            get => bits[i];
            set => bits[i] = value;
        }

        /// <summary>
        /// Allows getting a value from the register
        /// </summary>
        /// <returns></returns>
        public BitArray enable() => bits;

        /// <summary>
        /// Allows setting a value in the register
        /// </summary>
        /// <param name="data"></param>
        public void set(BitArray data) => bits = data;

        /// <summary>
        /// Returns the amount of bits the register has
        /// </summary>
        public int Count => bits.Count;

        /// <summary>
        /// Construct a register with <paramref name="bitAmount"></paramref> amount of bits
        /// </summary>
        /// <param name="bitAmount">The amount of bits the register will have</param>
        public Register(int bitAmount)
        {
            bits = new BitArray(bitAmount);

            for (int i = 0; i < bitAmount; i++)
                bits[i] = false;

        }

        /// <summary>
        /// Construct a register with existing BitArray
        /// </summary>
        /// <param name="bitArray"></param>
        public Register(BitArray bitArray)
        {
            bits = bitArray;
        }

        private Register() { }

        public static implicit operator Register(byte[] binaryNumber)
        {
            //Converting binaryNumber into a BitArray
            BitArray registerBits = new BitArray(binaryNumber);

            return new Register(registerBits);
        }

        public static implicit operator Register(int binaryNumber)
        {
            //Converting binaryNumber into a BitArray
            BitArray registerBits = new BitArray(new[] { binaryNumber });

            return new Register(registerBits);
        }

        public static implicit operator Register(long binaryNumber)
        {
            //Converting binaryNumber into a BitArray   
            byte[] bytes = BitConverter.GetBytes(binaryNumber);
            BitArray registerBits = new BitArray(bytes);

            return new Register(registerBits);
        }

        public static implicit operator Register(BitArray binaryNumber) => new Register(binaryNumber);
    }
}
