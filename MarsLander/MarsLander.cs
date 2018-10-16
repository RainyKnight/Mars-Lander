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
	class MarsLander
	{
		// positive speed == speed towards Mars (DOWNWARD)

		private MarsLanderHistory mlh = new MarsLanderHistory();

		private int speed;
		private int height;
		private int fuel;
        
		public MarsLander()
		{
			speed = 100;
			height = 1000;
			fuel = 500;
		}

		// returns height
		public int GetHeight()
		{
			return height;
		}

		// returns speed
		public int GetSpeed()
		{
			return speed;
		}

		// returns current fuel in lander
		public int GetFuel()
		{
			return fuel;
		}
        
		// adjust speed, fuel, and height
		public void CalculateNewSpeed(int nFuel)
		{
			speed = (speed + 50 - nFuel);
			height -= speed;

            // to keep from getting a height that's negative
            if (height < 0)
			{
				height = 0;
			}
			fuel -= nFuel;
			mlh.AddRound(height, speed);
		}
        
		// sets height
		public void SetHeight(int newHeight)
		{
			if (height < 0)
            {
                height = 0;
            }
			height = newHeight;
		}

        // sets new fuel in lander
        public void SetFuel(int newFuel)
		{
			fuel = newFuel;
		}

		public MarsLanderHistory GetHistory()
		{
			return mlh;
		}
    }
}
