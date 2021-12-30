
namespace AoC.Core
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
