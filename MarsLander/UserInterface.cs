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
    class UserInterface
    {
        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to the Mars Lander game!");
        }

        // prints a visual display of the lander's height
		public void PrintLocation( MarsLander ml)
        {
			int height = ml.GetHeight();
            
            // used the modulus operator to detect if the height was evenly divisible by 100
            // if not, it subtracts the remainder
			if ( (height % 100) != 0)
			{
				height -= (height % 100);
			}

			Console.WriteLine();
			for (int i = 1000; i > height; i -= 100)
                Console.WriteLine("{0}m:", i);
            
            // manually building the line with the asterisk
			Console.WriteLine("{0}m: *", height);

            // using a for loop to build the rest
			for (int i = (height - 100); i >= 0; i-=100)
				Console.WriteLine("{0}m:", i);
			
            Console.WriteLine();
        }

        // This prints out the info about the ml
        // For example:
        //      Exact height: 1350 meters
        //      Current (downward) speed: -350 meters/second
        //      Fuel points left: 0
        public void PrintLanderInfo( MarsLander ml)
        {

			Console.WriteLine("Exact  height: {0} meters", ml.GetHeight());
			Console.WriteLine("Current (downward) speed: {0} meters/second", ml.GetSpeed());
			Console.WriteLine("Fuel points left: {0}", ml.GetFuel());
            
        }

        // This will ask the user for how much fuel they want to burn,
        // verify that they've type in an acceptable integer,
        //  (repeatedly asking the user for input if needed),
        // and will then return that number back to the main method
		public int GetFuelToBurn(MarsLander ml)
        {
			int nFuel = 0;
			bool isNum =  false;
			int attempts = 0;

			while (true)
            {
				Console.WriteLine("\nHow many points of fuel would you like to burn?");

                // attempts to convert the string of input into the integer nFuel
				isNum = Int32.TryParse(Console.ReadLine(), out nFuel);

				// to clearly show the end of the turn
                Console.WriteLine("\n=================================================");

                
                // once enough input has been wrong, the user is reminded where everything is
                if (attempts == 1)
				{
					Console.WriteLine("\n");
					Console.WriteLine("Just as a reminder, here's where the lander is: \n");
                    PrintLanderInfo(ml);
                    Console.WriteLine();
					attempts = 0;
				}

                if (isNum == false)
				{
					Console.WriteLine("You need to type a whole number of fuel points to burn!\n");
					attempts++;
				}
				else if (nFuel < 0)
				{
					Console.WriteLine("You can't burn less than 0 points of fuel!");
					attempts++;
				}
				else if (nFuel > ml.GetFuel())
				{
					Console.WriteLine("You don't have {0} points of fuel!", nFuel);
					attempts++;
				}
				else {
					return nFuel;
				}
            }
        }
        
		public void PrintEndOfGameResult(MarsLander ml, int maxSpeed)
		{
			if (ml.GetSpeed() <= maxSpeed)
			{
				Console.WriteLine("\n=================================================");
                Console.WriteLine("                       SUCCESS");
                Console.WriteLine("=================================================\n");
				Console.WriteLine("Congratulations!! \n" +
				                  "You've successfully landed your Mars Lander, without crashing!!!");
			}
			else {
				Console.WriteLine("\n=================================================");
                Console.WriteLine("                       FAILURE");
                Console.WriteLine("=================================================\n");
				Console.WriteLine("The maximum speed for a safe landing is {0}m/s; \n" +
				                  "your lander's current speed is {1}m/s... \n" +
				                  "\nYou have crashed the lander into the surface of Mars, \n" +
				                  "killing everyone on board, costing NASA millions of dollars, \n" +
				                  "and setting the space program back by decades! :(", maxSpeed , ml.GetSpeed());
			}
			PrintHistory(ml.GetHistory());
		}
        // This is provided to you, but you'll need to add stuff elsewhere in order to make it work 
        public void PrintHistory(MarsLanderHistory mlh)
        {
			Console.WriteLine("\nHere's the height/speed info for you:");
            Console.WriteLine("Round #\t\tHeight (in m)\t\tSpeed (downwards, in m/s)");
            for (int i = 0; i < mlh.NumberOfRounds(); i++)
            {
                Console.WriteLine("{0}\t\t{1}\t\t\t{2}", i, mlh.GetHeight(i), mlh.GetSpeed(i));
            }
        }
    }
}
