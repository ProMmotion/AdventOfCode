using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021.Helpers
{
    public static class Converter
    {
        public static int ConvertBinaryToDecimal(string binary)
        {
            string reversed = new string(binary.ToCharArray().Reverse().ToArray());
            return reversed.Select((c, i) =>
            {
                int bin = Int32.Parse(c.ToString());
                return bin * (int)Math.Pow(2, i);
            }).Sum();
        }
        public static T[] BiToUniArray<T>(T[][] multi)
        {
            List<T> l = new List<T>();
            foreach (T[] t in multi)
            {
                l.AddRange(t);
            }
            return l.ToArray();
        }
    }
}
