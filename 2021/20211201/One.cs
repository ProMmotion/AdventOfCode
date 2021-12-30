using AoC.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2021._20211201
{
    public class One : Exercise
    {
        public One():base("20211201/input1.txt"){}

        public override void Solve(string input)
        {
            int[] numbers = input.Split("\n").Select(n => Int32.Parse(n)).ToArray();
            // PART 1
            Console.WriteLine(this.numIncrease(numbers));
            // PART 1
            // PART 2
            List<int> sums = new List<int>();
            for(int i = 0 ; i < numbers.Length; i++)
            {
                if(i+2 < numbers.Length)
                {
                    sums.Add(numbers[i] + numbers[i+1] + numbers[i+2]);
                }
            }
            Console.WriteLine(this.numIncrease(sums.ToArray()));
            // PART 2
        }
        private int numIncrease(int[] numbers)
        {
            int increase = 0;
            for(int i = 1; i < numbers.Length; i++)
            {
                if(numbers[i] > numbers[i-1]) increase++;
            }
            return increase;
        }
    }
}
