using AoC.Core;
using AoC.Core.Helpers;
using System;
using System.Linq;

namespace AoC._2021._20211203
{
    public class Three : Exercise
    {
        public Three() : base("20211203/input1.txt") { }
        public override void Solve(string input)
        {
            string[] bits = input.Split("\r\n");
            int nInstuctions = bits.Length;
            string gamma = "";
            string epsilon = "";
            string oxyGen = "";
            string co2Scrub = "";
            string[] oxyValues = bits;
            string[] co2Values = bits;
            for(int i = 0; i < bits[0].Length; i++)
            {
                // Part 1
                int oneCount = bits.Select(b => b[i]).Where(b => b == '1').Count();
                gamma += oneCount > nInstuctions / 2 ? '1' : '0';
                epsilon += oneCount > nInstuctions / 2 ? '0' : '1';
                // Part 1
                // Part 2
                if(oxyValues.Length > 1)
                {
                    string[] oxyOnes = oxyValues.Where(b => b[i] == '1').ToArray();
                    string[] oxyZeros = oxyValues.Where(b => b[i] == '0').ToArray();
                    if (oxyOnes.Length >= oxyZeros.Length)
                    {
                        oxyValues = oxyOnes;
                    }
                    else
                    {
                        oxyValues = oxyZeros;
                    }
                }
                else
                {
                    oxyGen = oxyValues[0];
                }
                if(co2Values.Length > 1)
                {
                    string[] co2Ones = co2Values.Where(b => b[i] == '1').ToArray();
                    string[] co2Zeros = co2Values.Where(b => b[i] == '0').ToArray();
                
                    if(co2Zeros.Length <= co2Ones.Length)
                    {
                        co2Values = co2Zeros;
                    }
                    else
                    {
                        co2Values = co2Ones;
                    }
                }
                else
                {
                    co2Scrub = co2Values[0];
                }
                // Part 2
            }
            // Part 1
            Console.WriteLine(Converter.ConvertBinaryToDecimal(gamma) * Converter.ConvertBinaryToDecimal(epsilon));
            // Part 2
            Console.WriteLine(Converter.ConvertBinaryToDecimal(oxyGen) * Converter.ConvertBinaryToDecimal(co2Scrub));
        }
    }
}
