/* Lucas Stoltman
 * BIT 143
 * 2018, Fall
 * A1.1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLanderHistory
    {
        RoundInfo[] rounds = new RoundInfo[10];

        int numRounds = 0;

		// I never used Clone()
        public MarsLanderHistory Clone()
        {
            MarsLanderHistory copy = new MarsLanderHistory();

            copy.rounds = new RoundInfo[this.rounds.Length];
            copy.numRounds = this.numRounds;
            for (int i = 0; i < copy.numRounds; i++)
                copy.rounds[i] = this.rounds[i];
            
            return copy;
        }
        
        public void AddRound(int nHeight, int nSpeed)
        {
			if (rounds.Length <= numRounds)
			{
				// Array.Resize(ref rounds, rounds.Length + 10);

                // creating a temp array
				RoundInfo[] roundsTemp = new RoundInfo[rounds.Length + 10];

				// Copying the elements into the longer temp array
				for (int i = 0; i < numRounds; i++)
				{
					roundsTemp[i] = rounds[i];
				}

                // Assigning memory address for the original array as the 
				// address for the new array
				rounds = roundsTemp;
			}

			RoundInfo newRound = new RoundInfo(nHeight, nSpeed);
            rounds[numRounds] = newRound;
			numRounds++;
        }

        public int NumberOfRounds()
		{
			return numRounds;
		}
        
        public int GetHeight(int roundNum)
		{
			return rounds[roundNum].GetHeight();
		} 
        
		public int GetSpeed(int roundNum)
        {
            return rounds[roundNum].GetSpeed();
        } 
    }

    class RoundInfo
    {
        private int height;
        private int speed;

        #region Accessors
        public int GetHeight()
        {
            return height;
        }
        public void SetHeight(int newValue)
        {
            height = newValue;
        }

        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newValue)
        {
            speed = newValue;
        }
        #endregion Accessors

        public RoundInfo(int h, int s)
        {
            height = h;
            speed = s;
        }
    }
}
