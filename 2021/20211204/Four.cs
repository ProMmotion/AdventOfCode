using _2021.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021._20211204
{
    public class Four : Exercise
    {
        private List<Board> boards = new List<Board>();
        public Four() : base("20211204/input1.txt") { }
        public override void Solve(string input)
        {
            string[] vs = input.Split("\r");
            int[] picked = vs[0].Split(',').Select(e => Int32.Parse(e)).ToArray();
            foreach(var lnum in this.ParseInput(vs.Skip(1).ToArray()))
            {
                boards.Add(new Board(lnum));
            }
            bool hasWinner = false;
            List<int> scores = new List<int>();
            List<Board> remain = boards;
            foreach(var p in picked)
            {
                if (hasWinner)
                {
                    // break; // part 1
                }
                List<Board> boardList = new List<Board>();
                for(int i = 0; i < remain.Count(); i++)
                {
                    var board = remain[i];
                    try
                    {
                        board.PickedNumber(p);
                        boardList.Add(board);
                    }catch(WinningException e)
                    {
                        this.printBoard(board);
                        Console.WriteLine(e.Message);
                        scores.Add(Int32.Parse(e.Message));
                        hasWinner = true;
                        // break; // part 1
                    }
                }
                remain = boardList;
            }
            Console.WriteLine("\nLast score: {0}", scores.Last());
            
        }
        private void printBoard(Board board)
        {
            foreach (var b in board.numbers)
            {
                foreach (var c in b)
                {
                    if (c.isPicked)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(c.number + " ");
                    Console.ResetColor();
                }
                Console.Write('\n');
            }
        }
        public int[][] ParseInput(string[] inp)
        {
            List<int[]> nums = new List<int[]>();
            for(int i = 0; i < inp.Length; i++)
            {
                if (inp[i] == "\n")
                {
                    int start = i + 1;
                    int end = start + 4;
                    int[] elements = String.Join(' ', inp.Where((e, index) => index >= start && index <= end).ToArray()).Split('\n', ' ').Where(e => e != "").Select(e => Int32.Parse(e)).ToArray();
                    i = end;
                    nums.Add(elements);
                }
            }
            return nums.ToArray();
        }
    }
    public class Board
    {
        public BoardNumber[][] numbers = new BoardNumber[5][];
        public Board(int[] numbs)
        {
            if(numbs.Length != 25) // 5x5 board
            {
                throw new Exception("Board must have 25 numbers");
            }
            int x = 0;
            int y = 0;
            foreach(int num in numbs)
            {
                if(x == 5)
                {
                    y++;
                    x = 0;
                }
                if(this.numbers[y] == null)
                {
                    this.numbers[y] = new BoardNumber[5];
                }
                this.numbers[y][x++] = new BoardNumber(num);
            }
        }
        public void PickedNumber(int picked)
        {
            BoardNumber[] bns = Converter.BiToUniArray<BoardNumber>(numbers.Select(col => col.Where(e => e.number == picked).ToArray()).ToArray());
            foreach (BoardNumber bn in bns)
            {
                bn.isPicked = true;
            }
            if (this.isSolved())
            {
                throw new WinningException(this.getScore(picked));
            }
        }
        private bool isSolved()
        {
            bool col1Solved = !numbers[0].Any(col => !col.isPicked);
            bool col2Solved = !numbers[1].Any(col => !col.isPicked);
            bool col3Solved = !numbers[2].Any(col => !col.isPicked);
            bool col4Solved = !numbers[3].Any(col => !col.isPicked);
            bool col5Solved = !numbers[4].Any(col => !col.isPicked);
            bool colSolved = col1Solved || col2Solved || col3Solved || col4Solved || col5Solved;
            bool row1Solved = !numbers.Select(col => col[0]).Any(row => !row.isPicked);
            bool row2Solved = !numbers.Select(col => col[1]).Any(row => !row.isPicked);
            bool row3Solved = !numbers.Select(col => col[2]).Any(row => !row.isPicked);
            bool row4Solved = !numbers.Select(col => col[3]).Any(row => !row.isPicked);
            bool row5Solved = !numbers.Select(col => col[4]).Any(row => !row.isPicked);
            bool rowSolved = row1Solved || row2Solved || row3Solved || row4Solved || row5Solved;
            return colSolved || rowSolved;
        }
        private int getScore(int lastPick)
        {
            int col1UnMarked = numbers[0].Where(col => !col.isPicked).Select(col => col.number).Sum();
            int col2UnMarked = numbers[1].Where(col => !col.isPicked).Select(col => col.number).Sum();
            int col3UnMarked = numbers[2].Where(col => !col.isPicked).Select(col => col.number).Sum();
            int col4UnMarked = numbers[3].Where(col => !col.isPicked).Select(col => col.number).Sum();
            int col5UnMarked = numbers[4].Where(col => !col.isPicked).Select(col => col.number).Sum();
            int unMarked = col1UnMarked + col2UnMarked + col3UnMarked + col4UnMarked + col5UnMarked;
            return unMarked * lastPick;
        }
    }
    public class BoardNumber
    {
        public bool isPicked = false;
        public readonly int number;
        public BoardNumber(int n)
        {
            this.number = n;
        }
    }
    public class WinningException : Exception
    {
        public WinningException(int score) : base(score.ToString())
        {
        }
    }
}
