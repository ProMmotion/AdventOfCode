using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021
{
    public abstract class Exercise
    {
        public Exercise(string path)
        {
            this.Solve(File.ReadAllText(path));
        }
        public abstract void Solve(string input);
    }
}
