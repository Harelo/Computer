using System;
using System.Collections;
using System.Linq.Expressions;

namespace Computer.Components
{
    public class Register
    {
        /// <summary>
        /// The actual binary number stored in the Register
        /// </summary>
        private BitArray bits { get; set; }

        /// <summary>
        /// The bus with to which the register will output when enable is on
        /// </summary>
        public BitArray cpuBus { get; set; }

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

        //Wires for setting and retrieving values from the register
        private bool _enable, _set;

        /// <summary>
        /// Allows getting a value from the register
        /// </summary>
        /// <returns></returns>
        public bool enableToBus
        {
            set
            {
                _enable = value;
                if (value)
                    cpuBus = bits;
            }
            get => _enable;
        }

        /// <summary>
        /// Allows setting a value to the register
        /// </summary>
        public bool setFromBus
        {
            set
            {
                _set = value;
                if (value)
                    bits = cpuBus;
            }
            get => _set;
        }

        /// <summary>
        /// Allows enable wire for inputs
        /// </summary>
        /// <returns></returns>
        public BitArray enableToInput() => bits;

        /// <summary>
        /// Returns the amount of bits the register has
        /// </summary>
        public int Count => bits.Count;

        /// <summary>
        /// Construct a register with <paramref name="bitAmount"></paramref> amount of bits
        /// </summary>
        /// <param name="bitAmount">The amount of bits the register will have</param>
        public Register(int bitAmount, BitArray _cpuBus)
        {
            bits = new BitArray(bitAmount);

            for (int i = 0; i < bitAmount; i++)
                bits[i] = false;

            cpuBus = _cpuBus;

        }

        /// <summary>
        /// Construct a register with existing BitArray
        /// </summary>
        /// <param name="bitArray"></param>
        public Register(BitArray bitArray, BitArray _cpuBus)
        {
            bits = bitArray;
        }

        private Register() { }

        private Register(BitArray bitArray)
        {
            bits = bitArray;
        }

        //Options for setting the value of the register

        public void SetValue(byte[] binaryNumber)
        {
            bits = new BitArray(binaryNumber);
        }

        public void SetValue(int binaryNumber)
        {
            bits = new BitArray(new[] { binaryNumber });
        }

        public void SetValue(long binaryNumber)
        {
            byte[] bytes = BitConverter.GetBytes(binaryNumber);
            bits = new BitArray(bytes);
        }

        public void SetValue(BitArray binaryNumber)
        {
            bits = binaryNumber;
        }

        //public static implicit operator Register(byte[] binaryNumber)
        //{
        //    //Converting binaryNumber into a BitArray
        //    BitArray registerBits = new BitArray(binaryNumber);

        //    return new Register(registerBits);
        //}

        //public static implicit operator Register(int binaryNumber)
        //{
        //    //Converting binaryNumber into a BitArray
        //    BitArray registerBits = new BitArray(new[] { binaryNumber });

        //    return new Register(registerBits);
        //}

        //public static implicit operator Register(long binaryNumber)
        //{
        //    //Converting binaryNumber into a BitArray   
        //    byte[] bytes = BitConverter.GetBytes(binaryNumber);
        //    BitArray registerBits = new BitArray(bytes);

        //    return new Register(registerBits);
        //}

        //public static implicit operator Register(BitArray binaryNumber) => new Register(binaryNumber);
    }
}
