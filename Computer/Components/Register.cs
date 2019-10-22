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
        private BitArray bits;

        /// <summary>
        /// The bus from which the register will receive data when set is on
        /// </summary>
        public BitArray inputBus { get; set; }

        /// <summary>
        /// The bus to which the register will output values when enable is on
        /// </summary>
        public BitArray outputBus { get; set; }

        /// <summary>
        /// An indexer for the register
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool this[int i]
        {
            get => bits[i];
            set
            {
                bits[i] = value;
                if (enableToBus)
                    outputBus[i] = bits[i];
            }
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
                    UpdateOutputBus();
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
                    bits = inputBus;
            }
            get => _set;
        }


        /// <summary>
        /// Returns the amount of bits the register has
        /// </summary>
        public int Count => bits.Count;

        /// <summary>
        /// Construct a register with a specific amount of bits
        /// </summary>
        /// <param name="bitAmount">The amount of bits the register will have</param>
        public Register(int bitAmount, BitArray _inputBus, BitArray _outputBus)
        {
            bits = new BitArray(bitAmount);

            for (int i = 0; i < bitAmount; i++)
                bits[i] = false;

            setBuses(_inputBus, _outputBus);
        }

        /// <summary>
        /// Construct a register with an existing BitArray
        /// </summary>
        /// <param name="bitArray"></param>
        public Register(BitArray bitArray, BitArray _inputBus, BitArray _outputBus)
        {
            bits = bitArray;
            setBuses(_inputBus, _outputBus);
        }

        /// <summary>
        /// Construct a register from an existing byte array
        /// </summary>
        /// <param name="bitArray"></param>
        public Register(byte[] bitArray, BitArray _inputBus, BitArray _outputBus)
        {
            bits = new BitArray(bitArray);
            setBuses(_inputBus, _outputBus);
        }

        /// <summary>
        /// Setting buses for the register
        /// </summary>
        /// <param name="_inputBus"></param>
        /// <param name="_outputBus"></param>
        private void setBuses(BitArray _inputBus, BitArray _outputBus)
        {
            inputBus = _inputBus;
            outputBus = _outputBus;
        }

        //Options for setting the value of the register

        public void SetValue(byte[] binaryNumber)
        {
            bits = new BitArray(binaryNumber);
            if (enableToBus)
                UpdateOutputBus();
        }

        public void SetValue(int binaryNumber)
        {
            bits = new BitArray(new[] { binaryNumber });
            if (enableToBus)
                UpdateOutputBus();
        }

        public void SetValue(long binaryNumber)
        {
            byte[] bytes = BitConverter.GetBytes(binaryNumber);
            bits = new BitArray(bytes);
            if (enableToBus)
                UpdateOutputBus();
        }

        public void SetValue(BitArray binaryNumber)
        {
            bits = binaryNumber;
            if (enableToBus)
                UpdateOutputBus();
        }

        /// <summary>
        /// Updates output bus bit by bit so to not over-write the reference to the output bus
        /// </summary>
        private void UpdateOutputBus()
        {
            for (int i = 0; i < outputBus.Length; i++)
                outputBus[i] = bits[i];
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
