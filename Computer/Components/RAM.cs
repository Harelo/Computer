using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components
{
    public class RAM
    {
        /// <summary>
        /// All the RAM addresses
        /// </summary>
        public Dictionary<int, BitArray> addreses;

        /// <summary>
        /// Initializes RAM with <paramref name="initialSize"/> size. All addreses will have a default value of 0
        /// </summary>
        /// <param name="initialSize">The memory size with which to initialize the RAM</param>
        public RAM(int initialSize)
        {
            addreses = new Dictionary<int, BitArray>();

            for (int i = 0; i < initialSize; i++)
                addreses[i] = new BitArray(8, false);
        }

        /// <summary>
        /// Allows getting a value from an address
        /// </summary>
        /// <param name="address">The address from which to retreive the data</param>
        /// <returns></returns>
        public BitArray enable(int address) => addreses[address];

        /// <summary>
        /// Allows setting a value in an address
        /// </summary>
        /// <param name="address">The address to which to write the data</param>
        /// <param name="data">The data to write</param>
        public void set(int address, BitArray data) => addreses[address] = data;
    }
}
