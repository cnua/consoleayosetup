using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ayo;
namespace ConsoleAyo
{
    class Program
    {
        //AyoGame ag = new AyoGame();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Select Play Mode:");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("1:"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Player Vs Player");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("2:"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Player Vs Computer");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("3:"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Computer Vs Player");
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("4:"); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Computer Vs Computer");

            string playMode = Console.ReadLine();
            if (playMode == "1")
            {
                //player vs player mode
                Console.WriteLine("Player Vs Player");
                AyoGame a = new AyoGame();
                Program p = new Program ();
                a.Changed += new EventHandler(p.DisplayConsoleBoard);
                Boolean gameOver = false;
                int SelectedHole = 0;

                while (gameOver == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.Write("1"); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write("2");  
                    Console.WriteLine("Enter number of the hole you want to play from");
                    SelectedHole = Convert.ToInt32(Console.ReadLine());
                    a.SelectPlayer(SelectedHole);
                    //expected format of entry is 1 based so adjust for 0 based index
                    SelectedHole--;
                    a.Iterate(SelectedHole);
                    //ay.DisplayConsoleBoard();
                }
            }
            else if (playMode == "2")
            {
                Console.WriteLine("Player Vs Computer");
                AyoGame a = new AyoGame();
                Program p = new Program();
                a.Changed += new EventHandler(p.DisplayConsoleBoard);
                Boolean gameOver = false;
                int SelectedHole = 0;

                while (gameOver == false)
                {
                    if (a.PlayersTurn == 0)
                    {
                        p.DisplayConsoleBoard(a, EventArgs.Empty);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter number of the hole you want to play from");
                        SelectedHole = Convert.ToInt32(Console.ReadLine());
                        a.SelectPlayer(SelectedHole);
                        //expected format of entry is 1 based so adjust for 0 based index
                        SelectedHole--;
                        a.Iterate(SelectedHole);
                    }
                    if (a.PlayersTurn == 1) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Computer's Turn");
                        System.Threading.Thread.Sleep(1000);
                        SelectedHole = a.ComputeriseTurnL2_PlayerVsComputer();
                        if (SelectedHole == -1) 
                        { 
                            gameOver = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("GAME OVER!");
                            break;
                        }
                        else
                        {
                            a.SelectPlayer(SelectedHole);
                            SelectedHole--;
                            a.Iterate(SelectedHole);
                        }
                    }
                } 
            }
            else if (playMode == "3")
            {
                Console.WriteLine("Computer Vs Player");
                AyoGame a = new AyoGame();
                Program p = new Program();
                a.Changed += new EventHandler(p.DisplayConsoleBoard);
                Boolean gameOver = false;
                int SelectedHole = 0;

                while (gameOver == false)
                {
                    if (a.PlayersTurn == 1)
                    {
                        p.DisplayConsoleBoard(a, EventArgs.Empty);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Enter number of the hole you want to play from");
                        SelectedHole = Convert.ToInt32(Console.ReadLine());
                        a.SelectPlayer(SelectedHole);
                        //expected format of entry is 1 based so adjust for 0 based index
                        SelectedHole--;
                        a.Iterate(SelectedHole);
                    }
                    if (a.PlayersTurn == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Computer's Turn");
                        System.Threading.Thread.Sleep(1000);
                        SelectedHole = a.ComputeriseTurnL2_ComputerVsPlayer ();
                        if (SelectedHole == -1)
                        {
                            gameOver = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("GAME OVER!");
                            break;
                        }
                        else
                        {
                            a.SelectPlayer(SelectedHole);
                            SelectedHole--;
                            a.Iterate(SelectedHole);
                        }
                    }
                } 
            }
            else if (playMode == "4")
            {
                Console.WriteLine("Computer Vs Computer: work in progress");
                AyoGame a = new AyoGame();
                Program p = new Program();
                a.Changed += new EventHandler(p.DisplayConsoleBoard);
                Boolean gameOver = false;
                int SelectedHole = 0;

                while (gameOver == false)
                {
                    if (a.PlayersTurn == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Computer 2nd's Turn");
                        System.Threading.Thread.Sleep(1000);
                        SelectedHole = a.ComputeriseTurnL2_PlayerVsComputer();
                        if (SelectedHole == -1)
                        {
                            gameOver = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("GAME OVER!");
                            break;
                        }
                        else
                        {
                            a.SelectPlayer(SelectedHole);
                            SelectedHole--;
                            a.Iterate(SelectedHole);
                        }
                    }
                    if (a.PlayersTurn == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Computer Starter's Turn");
                        System.Threading.Thread.Sleep(1000);
                        SelectedHole = a.ComputeriseTurnL2_ComputerVsPlayer();
                        if (SelectedHole == -1)
                        {
                            gameOver = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("GAME OVER!");
                            break;
                        }
                        else
                        {
                            a.SelectPlayer(SelectedHole);
                            SelectedHole--;
                            a.Iterate(SelectedHole);
                        }
                    }
                } 
            }
            Console.ReadLine();
            //Console.WriteLine("GAME OVER!");
            //player vs computer algorithm
            //get the hole player wants tyo play from

            //play the hole

            //save the ayo object in the resultant state

            //get the hole the second player wants to play fronm

            //the second player is the computer so use the saved ayo object to determine the best hole to play next

            //play each hole entitled

            //for each hole played; save the accumulator count

            //determine which hole outoput the most tothe accumulator

            //play the resultant hole given

            //loop to the first players turn
        }
        void DisplayConsoleBoard(object sender, EventArgs e)
        {
            AyoGame ag = (AyoGame)sender;
            int[] Board = ag.Board;

            //this gives an animated effect
            Console.Clear();
            //core display
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[{0}] [{1}] [{2}] [{3}] [{4}] [{5}]", Board[11], Board[10], Board[9], Board[8], Board[7], Board[6]);
            Console.WriteLine("[{0}] [{1}] [{2}] [{3}] [{4}] [{5}]", Board[0], Board[1], Board[2], Board[3], Board[4], Board[5]);
            Console.WriteLine("scoop:{0} turnCount0:{1} turnCount:{2} currentPlayer:{3}", ag.Scoop, ag.TurnCount0, ag.TurnCount, ag.CurrentPlayer);
            Console.WriteLine("dropCount:{1} pickCount:{2} checksum:{0}", ag.BoardChecksum, ag.DropCount, ag.PickCount);
            Console.WriteLine("currentPlayer:{0} acc[0]:{1} acc[1]:{2}", ag.CurrentPlayer, ag.Accumulator[0], ag.Accumulator[1]);
            Console.WriteLine("playersTurn:{0} chopCount:{1} currentHole:{2} activeHole:{3}", ag.PlayersTurn, ag.ChopCount,ag.CurrentHole,ag.ActiveHole);
            Console.WriteLine("-------------------------------------------------");
            //this gives an animated effect
            System.Threading.Thread.Sleep(ag.AnimationInterval);
            

        }
    }

}
