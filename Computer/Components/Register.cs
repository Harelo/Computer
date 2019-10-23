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
        /// The bus from which the register will receive data when set is on
        /// </summary>
        private Bus inputBus { get; set; }

        /// <summary>
        /// The bus to which the register will output values when enable is on
        /// </summary>
        private Bus outputBus { get; set; }


        //Wires for setting and retrieving values from the register
        private bool etb;
        public bool enableToBus
        {
            get => etb;
            set
            {
                etb = value;
                if (value)
                    outputBus.busValue = new BitArray(bits);
            }
        }

        private bool sfb;
        public bool setFromBus
        {
            get => sfb;
            set
            {
                sfb = value;
                if (value)
                    bits = new BitArray(inputBus.busValue);
            }
        }

        /// <summary>
        /// Construct a register with a specific amount of bits
        /// </summary>
        /// <param name="bitAmount">The amount of bits the register will have</param>
        public Register(int bitAmount, Bus _inputBus, Bus _outputBus)
        {
            bits = new BitArray(bitAmount);

            for (int i = 0; i < bitAmount; i++)
                bits[i] = false;

            setBuses(_inputBus, _outputBus);
        }

        public Register(long bitAmount, Bus _inputBus, Bus _outputBus)
        {
            byte[] bytes = BitConverter.GetBytes(bitAmount);
            bits = new BitArray(bytes);

            setBuses(_inputBus, _outputBus);
        }

        /// <summary>
        /// Construct a register with an existing BitArray
        /// </summary>
        /// <param name="bitArray"></param>
        public Register(BitArray bitArray, Bus _inputBus, Bus _outputBus)
        {
            bits = bitArray;
            setBuses(_inputBus, _outputBus);
        }

        /// <summary>
        /// Construct a register from an existing byte array
        /// </summary>
        /// <param name="bitArray"></param>
        public Register(byte[] bitArray, Bus _inputBus, Bus _outputBus)
        {
            bits = new BitArray(bitArray);
            setBuses(_inputBus, _outputBus);
        }

        /// <summary>
        /// Setting buses for the register
        /// </summary>
        /// <param name="_inputBus"></param>
        /// <param name="_outputBus"></param>
        private void setBuses(Bus _inputBus, Bus _outputBus)
        {
            inputBus = _inputBus;
            outputBus = _outputBus;

            _inputBus.BusUpdateEvent += (n) =>
            {
                if (setFromBus)
                    bits = new BitArray(n);
                if (enableToBus)
                    outputBus.busValue = new BitArray(bits);
            };
        }

        //Testing purposes methods from this point


        ///// <summary>
        ///// Returns the amount of bits the register has
        ///// </summary>
        //public int Count => bits.Count;
        ////Options for setting the value of the register

        //public void SetValue(byte[] binaryNumber)
        //{
        //    bits = new BitArray(binaryNumber);
        //}

        //public void SetValue(int binaryNumber)
        //{
        //    bits = new BitArray(new[] { binaryNumber });
        //}

        //public void SetValue(long binaryNumber)
        //{
        //    byte[] bytes = BitConverter.GetBytes(binaryNumber);
        //    bits = new BitArray(bytes);
        //}

        //public void SetValue(BitArray binaryNumber)
        //{
        //    bits = binaryNumber;
        //}

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
