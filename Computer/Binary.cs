using System;
using System.Numerics;
using System.Collections;
using System.Text.RegularExpressions;

namespace Computer
{
    public static class Binary
    {
        public static void PrintBA(BitArray bits)
        {
            Console.WriteLine();
            for (int i = bits.Length - 1; i >= 0; i--)
                Console.Write(bits[i] == true ? 1 : 0);
            Console.WriteLine();
        }


        //        /// <summary>
        //        /// For 32 bit integers
        //        /// </summary>
        //        /// <param name="integer"></param>
        //        /// <returns></returns>
        //        public static BitArray ToBitArray(int integer)
        //        {
        //            BitArray bits = new BitArray(new[] { integer });
        //            return bits;
        //        }

        //        /// <summary>
        //        /// For 64 bit integers (long)
        //        /// </summary>
        //        /// <param name="integer"></param>
        //        /// <returns></returns>
        //        public static BitArray ToBitArray(long integer)
        //        {
        //            byte[] bytes = BitConverter.GetBytes(integer);
        //            BitArray bits = new BitArray(bytes);
        //            return bits;
        //        }

        //        /// <summary>
        //        /// For anything higher than 64 bits.
        //        /// Expects the string to be a binary value
        //        /// </summary>
        //        /// <param name="binaryNum"></param>
        //        /// <returns></returns>
        //        public static BitArray ToBitArray(string binaryNum)
        //        {
        //            if (!Regex.IsMatch(binaryNum, @"^[0-1]+$"))
        //                throw new Exception("Not a binary number");

        //            int binaryNumLength = binaryNum.Length;
        //            BitArray bits = new BitArray(binaryNumLength);

        //            for (int i = 0; i < binaryNumLength; i++)
        //                bits[i] = binaryNum[i] == '1';

        //            return bits;
        //        }

        //        /// <summary>
        //        /// Converts a BitArray <paramref name="ba"/> to a single int
        //        /// </summary>
        //        /// <param name="ba">The BitArray to convert</param>
        //        /// <returns></returns>
        //        public static int ToInt(BitArray ba)
        //        {
        //            if (ba.Length > 32)
        //                new ArgumentException("BitArray cannot have more than 32 bits");
        //            int[] bitsAsInts = new int[1];
        //            ba.CopyTo(bitsAsInts, 0);
        //            return bitsAsInts[0];
        //        }
    }
}
