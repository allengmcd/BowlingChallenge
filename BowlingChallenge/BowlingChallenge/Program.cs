using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] rounds = new int[10][]
            {
                new int[] { 9, 0}, // Round #1
                new int[] { 3, 5}, // Round #2
                new int[] { 6, 1}, // Round #3
                new int[] { 3, 6}, // Round #4
                new int[] { 8, 1}, // Round #5
                new int[] { 5, 3}, // Round #6
                new int[] { 2, 5}, // Round #7
                new int[] { 8, 0}, // Round #8
                new int[] { 7, 1}, // Round #9
                new int[] { 8, 1}, // Round #10
            };
            BowlingGame game = new BowlingGame();
            //ISimpleBowlingGame game = new BowlingGame();

            foreach (var round in rounds)
            {
                game.RecordFrame(round);
            }

            Console.WriteLine($"Your final score is: {game.Score}");
            game.NewGame();

            rounds = new int[10][]
            {
                    new int[] { 9, 0}, // Round #1
                    new int[] { 3, 7}, // Round #2
                    new int[] { 6, 1}, // Round #3
                    new int[] { 3, 7}, // Round #4
                    new int[] { 8, 1}, // Round #5
                    new int[] { 5, 5}, // Round #6
                    new int[] { 0, 10}, // Round #7
                    new int[] { 8, 0}, // Round #8
                    new int[] { 7, 3}, // Round #9
                    new int[] { 8, 2, 8}, // Round #10
            };

            foreach (var round in rounds)
            {
                game.RecordFrame(round);
            }

            Console.WriteLine($"Your final score is: {game.Score}");
            game.NewGame();

            rounds = new int[10][]
            {
                    new int[] { 10, 0}, // Round #1
                    new int[] { 3, 7}, // Round #2
                    new int[] { 6, 1}, // Round #3
                    new int[] { 10 }, // Round #4
                    new int[] { 10 }, // Round #5
                    new int[] { 10 }, // Round #6
                    new int[] { 2, 8 }, // Round #7
                    new int[] { 9, 0}, // Round #8
                    new int[] { 7, 3}, // Round #9
                    new int[] { 10, 10, 10}, // Round #10
            };

            foreach (var round in rounds)
            {
                game.RecordFrame(round);
            }

            Console.WriteLine($"Your final score is: {game.Score}");
            Console.ReadKey();
        }
    }
}
