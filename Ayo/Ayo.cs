using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Ayo
{
    public class AyoGame
    {
        #region declarations
        //constants
        const int GRID_COUNT = 12;
        const int CHOP_FIGURE = 4;
        const int SEEDS_PER_HOLE = 4;
        const int ANIMATION_PAUSE = 50;
        //readonly
        int[] board = new int[GRID_COUNT] { SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE, SEEDS_PER_HOLE };
        int scoop ;//= 0;
        int[] accumulator = new int[2];
        int dropCount ;//= 0;
        int turnCount0;// = 0;
        int turnCount ;//= 0;
        int pickCount ;//= 0;
        int chopCount ;//= 0;
        int currentPlayer ;//= 0;
        int previousPlayer ;//= 0;
        int currentHole = -1;
        int activeHole = -1;
        //readwrite
        int animationInterval = 50;

        #endregion

        #region events
        public event EventHandler Changed;
        public event EventHandler ChangedPlayer1;
        public event EventHandler ChangedPlayer2;
        // Invoke the Changed event; called whenever list changes:
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
        protected virtual void OnChangedPlayer1(EventArgs e)
        {
            if (ChangedPlayer1 != null)
                ChangedPlayer1(this, e);
        }
        protected virtual void OnChangedPlayer2(EventArgs e)
        {
            if (ChangedPlayer2 != null)
                ChangedPlayer2(this, e);
        }
        #endregion

        # region Defense routines
        int getThe6LeastAccumulatorWhenIPlayfromHole(AyoGame board_iAlreadyPlayed_YouReply)
        {
            int [] acc = new int[6];
            AyoGame localg = board_iAlreadyPlayed_YouReply.clone();
            for (int i = 0; i < 6; i++) 
            { 
                localg.SelectPlayer(i);
                localg.Iterate(i);
                if (localg.board[i] > 0)
                {
                    acc[i] = localg.accumulator[0];
                }
                else
                {
                    acc[i] = 1000;
                }            
            }
            //--iterate through the result and return the lowest scored
            //int result = -1;
            int leastscore = acc[0];
            for (int i = 0; i < 6; i++) 
            {
                if (acc[i] < leastscore) 
                {
                    leastscore = acc[i];
                }
            }

            return leastscore;
        }
        public int GetTheGridIShouldPlayFromToMinimiseYourGainWhenYouPlay() 
        {
            int[] acc = new int[6];
            int thegrid = -1;
            int leastscore = 1000;
            //int result = -1;
            for (int i = 6; i < 12; i++) 
            {
                AyoGame myturntoplay = this.clone();
                myturntoplay.SelectPlayer(i);
                myturntoplay.Iterate(i);
                acc[i-6] = getThe6LeastAccumulatorWhenIPlayfromHole(myturntoplay);
            }
            for (int i = 0; i < 6; i++) 
            {
                if (acc[i] < leastscore)
                {
                    leastscore = acc[i];
                    if (acc[i] == 0) 
                    {
                        thegrid = 6;
                    }
                    else if (acc[i] == 1)
                    {
                        thegrid = 7;
                    }
                    else if (acc[i] == 3)
                    {
                        thegrid = 8;
                    }
                    else if (acc[i] == 4)
                    {
                        thegrid = 9;
                    }
                    else if (acc[i] == 5)
                    {
                        thegrid = 10;
                    }
                    else if (acc[i] == 6)
                    {
                        thegrid = 11;
                    }
                }
            }
            thegrid++;
            return thegrid;
        }
        #endregion

        #region computerise turn
        public int ComputeriseTurn_PlayerVsComputer()
        {
            int result = -1;
            if (playersTurn() == 1)
            {
                if (board[6] > 0)
                {
                    result = 7;
                }
                else if (board[7] > 0)
                {
                    result = 8;
                }
                else if (board[8] > 0)
                {
                    result = 9;
                }
                else if (board[9] > 0)
                {
                    result = 10;
                }
                else if (board[10] > 0)
                {
                    result = 11;
                }
                else if (board[11] > 0)
                {
                    result = 12;
                }
                else
                {
                    result = -1;
                }
            }
            return result;
        }
        public int ComputeriseTurn_ComputerVsPlayer()
        {
            int result = -1;
            if (playersTurn() == 0)
            {
                if (board[0] > 0)
                {
                    result = 1;
                }
                else if (board[1] > 0)
                {
                    result = 2;
                }
                else if (board[2] > 0)
                {
                    result = 3;
                }
                else if (board[3] > 0)
                {
                    result = 4;
                }
                else if (board[4] > 0)
                {
                    result = 5;
                }
                else if (board[5] > 0)
                {
                    result = 6;
                }
                else
                {
                    result = -1;
                }
            }
            return result;
        }
        public int ComputeriseTurnL2_PlayerVsComputer()
        {
            int result = -1;
            int []acc = new int [2];
            if (playersTurn() == 1)
            {
                if (board[6] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(6);
                    ay.Iterate(6);
                    if (ay.accumulator[1] > this.accumulator[1])
                    {
                        acc[0] = 6;
                        acc[1] = ay.accumulator[1];
                        result = 7;
                    }
                }
                if (board[7] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(7);
                    ay.Iterate(7);
                    if (ay.accumulator[1] > this.accumulator[1])
                    {
                        if(ay.accumulator[1]> acc[1])
                        {
                        acc[0] = 7;
                        acc[1] = ay.accumulator[1];
                        result = 8;
                        }
                    }
                }
                if (board[8] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(8);
                    ay.Iterate(8);
                    if (ay.accumulator[1] > this.accumulator[1])
                    {
                        if (ay.accumulator[1] > acc[1])
                        {
                            acc[0] = 8;
                            acc[1] = ay.accumulator[1];
                            result = 9;
                        }
                    }
                }
                if (board[9] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(9);
                    ay.Iterate(9);
                    if (ay.accumulator[1] > this.accumulator[1])
                    {
                        if (ay.accumulator[1] > acc[1])
                        {
                            acc[0] = 9;
                            acc[1] = ay.accumulator[1];
                            result = 10;
                        }
                    }
                }
                if (board[10] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(10);
                    ay.Iterate(10);
                    if (ay.accumulator[1] > this.accumulator[1])
                    {
                        if (ay.accumulator[1] > acc[1])
                        {
                            acc[0] = 10;
                            acc[1] = ay.accumulator[1];
                            result = 11;
                        }
                    }
                }
                if (board[11] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(11);
                    ay.Iterate(11);
                    if (ay.accumulator[1] > this.accumulator[1])
                    {
                        if (ay.accumulator[1] > acc[1])
                        {
                            acc[0] = 11;
                            acc[1] = ay.accumulator[1];
                            result = 12;
                        }
                    }
                }
                if (result==-1)
                {
                    result = ComputeriseTurn_PlayerVsComputer();
                }
            }
            return result;
        }
        public int ComputeriseTurnL2_ComputerVsPlayer()
        {
            int result = -1;
            int[] acc = new int[2];
            if (playersTurn() == 0)
            {
                if (board[0] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(0);
                    ay.Iterate(0);
                    if (ay.accumulator[0] > this.accumulator[0])
                    {
                        acc[0] = 0;
                        acc[1] = ay.accumulator[0];
                        result = 1;
                    }
                }
                if (board[1] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(1);
                    ay.Iterate(1);
                    if (ay.accumulator[0] > this.accumulator[0])
                    {
                        if (ay.accumulator[0] > acc[1])
                        {
                            acc[0] = 1;
                            acc[1] = ay.accumulator[0];
                            result = 2;
                        }
                    }
                }
                if (board[2] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(2);
                    ay.Iterate(2);
                    if (ay.accumulator[0] > this.accumulator[0])
                    {
                        if (ay.accumulator[0] > acc[1])
                        {
                            acc[0] = 2;
                            acc[1] = ay.accumulator[0];
                            result = 3;
                        }
                    }
                }
                if (board[3] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(3);
                    ay.Iterate(3);
                    if (ay.accumulator[0] > this.accumulator[0])
                    {
                        if (ay.accumulator[0] > acc[1])
                        {
                            acc[0] = 3;
                            acc[1] = ay.accumulator[0];
                            result = 4;
                        }
                    }
                }
                if (board[4] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(4);
                    ay.Iterate(4);
                    if (ay.accumulator[0] > this.accumulator[0])
                    {
                        if (ay.accumulator[0] > acc[1])
                        {
                            acc[0] = 4;
                            acc[1] = ay.accumulator[0];
                            result = 5;
                        }
                    }
                }
                if (board[5] > 0)
                {
                    AyoGame ay = this.clone();
                    ay.SelectPlayer(5);
                    ay.Iterate(5);
                    if (ay.accumulator[0] > this.accumulator[0])
                    {
                        if (ay.accumulator[0] > acc[1])
                        {
                            acc[0] = 5;
                            acc[1] = ay.accumulator[0];
                            result = 6;
                        }
                    }
                }
                if (result == -1)
                {
                    result = ComputeriseTurn_ComputerVsPlayer();
                }
            }
            return result;
        }
        #endregion

        #region autos
        public void Iterate(int fromHole)
        {
            //return if the hole is empty
            if (Board[fromHole] == 0) 
            {
                return; 
            }
            if (currentPlayer == previousPlayer && turnCount > 0)
            {
                return;
            }
            currentHole = fromHole;
            TakeFromHole(fromHole); turnCount++;

            int currentPosition = 0;
            bool finish = false;
            while (finish==false)
            {
                if (scoop == 0 && Board[currentPosition]>1)
                {
                    TakeFromHole(currentPosition); 

                }
                currentPosition = GetNextHole(fromHole);
                fromHole = currentPosition;

                DropSeed(currentPosition);

                if (Board[currentPosition] == CHOP_FIGURE)
                {
                    Chop(currentPosition);
                }
                
                if (scoop == 0 && (Board[currentPosition] == 1 || Board[currentPosition] == 0))
                {
                    finish = true;
                }
                previousPlayer = currentPlayer;
            }

        }
        int GetNextHole(int i)
        {
            i++;
            if (i == GRID_COUNT) { i = 0; }
            return i;
        }
        int GetBoardChecksum() 
        {
            int cs=0;
            for(int i=0;i<Board.Length ;i++)
            {
                cs+=Board[i];
            }

            return cs+scoop+accumulator[0]+accumulator[1];
        }
        void TakeFromHole(int fromHole)
        {
            //remove the contents of the selected hole 
            scoop = Board[fromHole];
            Board[fromHole] = 0;
            pickCount++;
            activeHole = fromHole;
            OnChanged(EventArgs.Empty);
        }
        void DropSeed(int currentPosition)
        {
            Board[currentPosition]++;
            scoop--;

            dropCount++;
            activeHole = currentPosition;
            OnChanged(EventArgs.Empty);
        }
        void Chop(int currentPosition)
        {
            //check if its ay score condition and chop
            //if (Board[currentPosition] == 4)
            //{
            accumulator[currentPlayer] += Board[currentPosition];
            Board[currentPosition] = 0;
            chopCount++;
            activeHole = currentPosition;
            OnChanged(EventArgs.Empty);

            //}
        }
        int GetPreviousHole(int i)
        {

            i--;
            if (i == -1) { i = 7; }
            return i;
        }
        public void SelectPlayer(int gridSelected) 
        {
            if (gridSelected < ((GRID_COUNT/2)+1))
            {
                currentPlayer = 0;
            }
            else
            {
                currentPlayer = 1;
            }
            
        }
        int playersTurn()
        {
            int result = 0;
            if (turnCount != 0)
            {
                result = turnCount % 2;
            }
            return result;
        }
        public Ayo.AyoGame clone() 
        {
            AyoGame a = new AyoGame();
            this.accumulator.CopyTo (a.accumulator,0);
            this.board.CopyTo (a.board,0);
            a.chopCount = this.chopCount;
            a.currentPlayer = this.currentPlayer;
            a.dropCount = this.dropCount;
            a.pickCount = this.pickCount;
            a.PlayerName = this.PlayerName;
            a.previousPlayer = this.previousPlayer;
            a.scoop = this.scoop;
            a.turnCount0 = this.turnCount0;
            a.turnCount = this.turnCount;
            
            return a;
        } 
        int GeneratePlayerTurn(int currentPlayer)
        {
            int [] arr = (int[]) board.Clone();
            int[] result = new int[5];
            for (int i = 0; i < result.Length; i++)
            {
                AyoGame a = this.clone();
            }

            return 0;
        }
        #endregion

        #region properties
        string PlayerName { get; set; }

        public int BoardChecksum
        {
            get
            {
                return GetBoardChecksum();
            }
        }
        public int [] Accumulator
        {
            get
            {
                return accumulator;
            }
        }
        public int[] Board
        {
            get
            {
                return board;
            }
        }
        public int ChopCount
        {
            get
            {
                return chopCount;
            }
        }
        public int CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
        }
        public int DropCount
        {
            get
            {
                return dropCount;
            }
        }
        public int CurrentHole
        {
            get
            {
                return currentHole;
            }
        }
        public int PickCount
        {
            get
            {
                return pickCount;
            }
        }
        public int PreviousPlayer
        {
            get
            {
                return previousPlayer;
            }
        }
        public int Scoop
        {
            get
            {
                return scoop;
            }
        }
        public int ActiveHole
        {
            get
            {
                return activeHole;
            }
        }
        public int TurnCount0
        {
            get
            {
                return turnCount0;
            }
        }
        public int TurnCount
        {
            get
            {
                return turnCount;
            }
        }
        public int PlayersTurn
        {
            get
            {
                return playersTurn();
            }
        }
        public int AnimationInterval
        {
            get
            {
                return animationInterval;
            }
            set 
            {
                animationInterval = value;
            }
        }
        #endregion
    }

}
