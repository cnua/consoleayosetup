using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ayo;
using System.Windows.Threading;
namespace WindowsAyo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {                
        AyoGame a ;//= new AyoGame();
        Thickness t ;//= image2.Margin;
        public Window1()
        {
            InitializeComponent();
            InitialiseBoard();
        }


        void InitialiseBoard() 
        {
            a = new AyoGame();
            t = image2.Margin;
            a.AnimationInterval = 250;
            a.Changed += new EventHandler(DisplayConsoleBoard);
        }
        void PlayerVsPlayer(int selectedHole) 
        {

                a.SelectPlayer(selectedHole);
                //expected format of entry is 1 based so adjust for 0 based index
                selectedHole--;
                a.Iterate(selectedHole);
        }
        //void PlayerVsComputer()
        //{
        //    if (a.PlayersTurn == 0)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("Computer's Turn");
        //        System.Threading.Thread.Sleep(1000);
        //        SelectedHole = a.ComputeriseTurnL2_ComputerVsPlayer();
        //        if (SelectedHole == -1)
        //        {
        //            gameOver = true;
        //            Console.ForegroundColor = ConsoleColor.Magenta;
        //            Console.WriteLine("GAME OVER!");
        //            break;
        //        }
        //        else
        //        {
        //            a.SelectPlayer(SelectedHole);
        //            SelectedHole--;
        //            a.Iterate(SelectedHole);
        //        }
        //    }
        //}
        void DisplayConsoleBoard(object sender, EventArgs e)
        {
            AyoGame ag = (AyoGame)sender;
            int[] Board = ag.Board;
            
            //this gives an animated effect
            //Console.Clear();
            //core display
            button1.Content = ag.Board[0];
            button2.Content = ag.Board[1];
            button3.Content = ag.Board[2];
            button4.Content = ag.Board[3];
            button5.Content = ag.Board[4];
            button6.Content = ag.Board[5];
            button7.Content = ag.Board[6];
            button8.Content = ag.Board[7];
            button9.Content = ag.Board[8];
            button10.Content = ag.Board[9];
            button11.Content = ag.Board[10];
            button12.Content = ag.Board[11];
            label1.Content = ag.Accumulator[0];
            label2.Content = ag.Accumulator[1];
            label3.Content = ag.CurrentHole; 
            //this gives an animated effect
            System.Threading.Thread.Sleep(ag.AnimationInterval);
            //button1.Refresh();
            //hand animation sequence
            //Brush br = button1.Background ;
            //AnimateHole(ag);
            if (ag.ActiveHole == 0)
            {
                button1.Background = Brushes.Yellow;
                image2.Visibility = Visibility.Visible;
                //animate the image
                image2.Margin = button1.Margin;  
            }
            else
            {
                button1.Background = Brushes.Gray;
                image1.Visibility = Visibility.Visible;   
            }
            if (ag.ActiveHole == 1)
            {
                button2.Background = Brushes.Yellow;
                image2.Margin = button2.Margin;
            }
            else
            {
                button2.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 2)
            {
                button3.Background = Brushes.Yellow;
                image2.Margin = button3.Margin;
            }
            else
            {
                button3.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 3)
            {
                button4.Background = Brushes.Yellow;
                image2.Margin = button4.Margin;
            }
            else
            {
                button4.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 4)
            {
                button5.Background = Brushes.Yellow;
                image2.Margin = button5.Margin;
            }
            else
            {
                button5.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 5)
            {
                button6.Background = Brushes.Yellow;
                image2.Margin = button6.Margin;
            }
            else
            {
                button6.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 6)
            {
                button7.Background = Brushes.Yellow;
                image2.Margin = button7.Margin;
            }
            else
            {
                button7.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 7)
            {
                button8.Background = Brushes.Yellow;
                image2.Margin = button8.Margin;
            }
            else
            {
                button8.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 8)
            {
                button9.Background = Brushes.Yellow;
                image2.Margin = button9.Margin;
            }
            else
            {
                button9.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 9)
            {
                button10.Background = Brushes.Yellow;
                image2.Margin = button10.Margin;
            }
            else
            {
                button10.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 10)
            {
                button11.Background = Brushes.Yellow;
                image2.Margin = button11.Margin;
            }
            else
            {
                button11.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 11)
            {
                button12.Background = Brushes.Yellow;
                image2.Margin = button12.Margin;
            }
            else
            {
                button12.Background = Brushes.Gray;
            }
            RefreshButtons();
        }
        void RefreshButtons() 
        {
            button1.Refresh();
            button2.Refresh();
            button3.Refresh();
            button4.Refresh();
            button5.Refresh();
            button6.Refresh();
            button7.Refresh();
            button8.Refresh();
            button9.Refresh();
            button10.Refresh();
            button11.Refresh();
            //button12.Refresh();
        }
        void AnimateHole(AyoGame ag)
        {
            if (ag.ActiveHole == 0)
            {
                button1.Background = Brushes.Yellow;
            }
            else 
            {
                button1.Background = Brushes.Gray; 
            }
            if (ag.ActiveHole == 1)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 2)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 3)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 4)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 5)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 6)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 7)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 8)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 9)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 10)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }
            if (ag.ActiveHole == 11)
            {
                button1.Background = Brushes.Yellow;
            }
            else
            {
                button1.Background = Brushes.Gray;
            }

            for (int i = 0; i < 12; i++) 
            {

            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(1);
            image2.Margin = t; 

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(2);
            image2.Margin = t;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(3);
            image2.Margin = t;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(4);
            image2.Margin = t;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(5);
            image2.Margin = t;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(6);
            image2.Margin = t;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(7);
            image2.Margin = t;
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(8);
            image2.Margin = t;
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(9);
            image2.Margin = t;
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(10);
            image2.Margin = t;
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(11);
            image2.Margin = t;
        }
        private void button12_Click(object sender, RoutedEventArgs e)
        {
            PlayerVsPlayer(12);
            image2.Margin = t;
        }

        private void btnComputer_Click(object sender, RoutedEventArgs e)
        {
            if (a.PlayersTurn == 0)
            {
            int SelectedHole = -2;
            //bool gameOver = false;

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Computer's Turn");
            //System.Threading.Thread.Sleep(1000);
            SelectedHole = a.ComputeriseTurnL2_ComputerVsPlayer();
            //if (SelectedHole == -1)
            //{
            //    gameOver = true;
            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.WriteLine("GAME OVER!");
            //    //break;
            //}
            //else
            //{
                a.SelectPlayer(SelectedHole);
                SelectedHole--;
                a.Iterate(SelectedHole);
            //}
            }
        }

        private void btnPlayerVsComputer_Click(object sender, RoutedEventArgs e)
        {
            if (a.PlayersTurn == 1)
            {
                int SelectedHole = -2;
                //bool gameOver = false;

                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("Computer's Turn");
                //System.Threading.Thread.Sleep(1000);
                SelectedHole = a.ComputeriseTurn_PlayerVsComputer();
                //if (SelectedHole == -1)
                //{
                //    gameOver = true;
                //    Console.ForegroundColor = ConsoleColor.Magenta;
                //    Console.WriteLine("GAME OVER!");
                //    //break;
                //}
                //else
                //{
                a.SelectPlayer(SelectedHole);
                SelectedHole--;
                a.Iterate(SelectedHole);
                //}
            }
        }
    }
}
