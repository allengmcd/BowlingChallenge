using System.Collections.Generic;

namespace BowlingChallenge
{
    public interface ISimpleBowlingGame
    {
        // Called when a player completes a frame.
        // This method will be called 10 times for a bowling game.
        // The throws parameter provides the number of pins knocked down on each throw in the frame being recorded.
        // The 10th frame may have 3 values.
        void RecordFrame(params int[] throws);

        // Called at the end of the game to get the final score.
        int Score { get; }
    }


    public class BowlingGame : ISimpleBowlingGame
    {
        public int Score { get; internal set; }
        private List<int> strikeSpareCounter; 
        private int round;


        /// <summary>
        /// Constructor for the BowlingGame. Sets the Score to 0, round to 1, and clears any instances of strikes or spares
        /// </summary>
        public BowlingGame()
        {
            Score = 0;
            round = 1;
            strikeSpareCounter = new List<int>();
        }


        /// <summary>
        /// Resets the Score, round, and any instances of strikes or spares
        /// </summary>
        public void NewGame()
        {
            Score = 0;
            round = 1;
            strikeSpareCounter = new List<int>();
        }


        /// <summary>
        /// Called when a player completes a frame.
        /// This method will be called 10 times for a bowling game.
        /// The 10th frame may have 3 values.
        /// </summary>
        /// <param name="throws">The throws parameter provides the number of pins knocked down on each throw in the frame being recorded.</param>
        public void RecordFrame(params int[] throws)
        {
            int roundScore = 0; // Initialize round score to 0
            if (throws[0] == 10) // STRIKE!!!!
            {
                roundScore += 10; // Add ten to the score
                AddStrikeSpareScores(throws[0]); // Add in strike or spare scores
                strike(); // Call strike sequence

                if(round == 10)
                {
                    AddStrikeSpareScores(throws[1]); // Add in strike or spare scores
                }
            }
            else // No strike occurrd
            {
                for (int i = 0; i < 2; i++)
                {
                    roundScore += throws[i]; // Add some amount to the score
                    AddStrikeSpareScores(throws[i]); // Add in strike or spare scores
                }

                if (roundScore == 10) // Spare!!
                {
                    spare(); // Call spare sequence
                }
            }
            
            if (round == 10 && roundScore >= 10) // Check if its the final round and if they can roll again
            {
                AddStrikeSpareScores(throws[2]); // Add in strike or spare scores
            }

            Score += roundScore; //Set score to total score
            round++; // Implement the round counter by 1
        }


        /// <summary>
        /// Initialize so that the next score will be counted
        /// </summary>
        private void spare()
        {
            int newSS = 1; // Set counter to 1 to count the next frame
            strikeSpareCounter.Add(newSS);
        }


        /// <summary>
        /// Initialize so that the next 2 scores will be counted
        /// </summary>
        private void strike()
        {
            int newSS = 2; // Set counter to 2 to count the next frame
            strikeSpareCounter.Add(newSS);
        }


        /// <summary>
        /// Adds in additional scores for any strikes or spares that have occurred
        /// </summary>
        /// <param name="frameScore"></param>
        private void AddStrikeSpareScores(int frameScore)
        {
            for(int i = 0; i < strikeSpareCounter.Count; i++)
            {
                if(strikeSpareCounter[i] != 0)
                {
                    Score += frameScore;
                    strikeSpareCounter[i]--;
                }
            }
        }
    }
}
