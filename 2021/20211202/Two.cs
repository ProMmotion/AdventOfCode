using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021._20211202
{
    public class Two : Exercise
    {
        public Two():base("20211202/input1.txt"){}

        public override void Solve(string input)
        {
            string[] instructions = input.Split("\n");
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            foreach (string instruction in instructions)
            {
                string[] inst = instruction.Split(' ');
                int number = Int32.Parse(inst[1]);
                if(inst[0] == "forward"){
                    horizontal += number;
                    // Comment bellow line for part 1
                    depth += number*aim;
                }
                if(inst[0] == "up"){
                    aim -= number;
                }
                if(inst[0] == "down"){
                    aim += number;
                }
            }
            
            Console.WriteLine(horizontal*depth);
        }
    }
}
