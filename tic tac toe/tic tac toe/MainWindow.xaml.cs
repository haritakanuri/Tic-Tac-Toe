using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using System.Windows.Resources;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tic_tac_toe
{
    public partial class MainWindow : Window
    {
        bool turn = true; //true = X turn false= Y turn
        int turn_count = 0;

        public List<Control> Controls { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            startApp();
        }
        private void startApp()
        {
            //Controls.Add(A1);
            //Controls.Add(A2);
            //Controls.Add(A3);
            //Controls.Add(B1);
            //Controls.Add(B2);
            //Controls.Add(B3);
            //Controls.Add(C1);
            //Controls.Add(C2);
            //Controls.Add(C3);

        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Content = "X";
            else
                b.Content = "O";
            turn = !turn;
            b.IsEnabled = false;
            turn_count++;
            //MessageBox.Show("checkforwinner is working" + "checked");
            checkforwinner();
        }
        private void checkforwinner()
        {
            bool there_is_a_winner = false;

            //Horizontal checks
            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))
                there_is_a_winner = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                there_is_a_winner = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                there_is_a_winner = true;

            //vertical checks
            if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))
                there_is_a_winner = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                there_is_a_winner = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                there_is_a_winner = true;

            //diagnol checks
            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))
                there_is_a_winner = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!C1.IsEnabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                //MessageBox.Show("having trouble with disablebutton");
                
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    o_win_count.Content = (Int32.Parse((o_win_count.Content).ToString()) + 1);
                }
                    
                else
                {
                    X_win_count.Content = (Int32.Parse((X_win_count.Content).ToString()) + 1);
                    winner = "X";
                }

                disabledbuttons();
                MessageBox.Show(winner + "wins" + "Yay!");
            }//end if
            else
            {
                if(turn_count==9)
                {
                    draw_count.Content = (Int32.Parse((draw_count.Content).ToString()) + 1);
                    MessageBox.Show("Draw!" + "Runner");
                }
            }
        }//end checkforwinner

        private void button_click(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("By Harita", "About tic tac toe");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void disabledbuttons()
        {
            try
            {
                A1.IsEnabled = false;
                A2.IsEnabled = false;
                A3.IsEnabled = false;
                B1.IsEnabled = false;
                B2.IsEnabled = false;
                B3.IsEnabled = false;
                C1.IsEnabled = false;
                C2.IsEnabled = false;
                C3.IsEnabled = false;


                //MessageBox.Show("this part has no effect on code");
                //foreach (Control c in Controls)
                //{
                //  Button b = (Button)c;
                //  b.IsEnabled = false;
                //}//end foreach
            }//end try
            catch { }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("this part has no effect on code");
            turn = true;
            turn_count = 0;
            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            C1.IsEnabled = true;
            C2.IsEnabled = true;
            C3.IsEnabled = true;

            //foreach (Control c in Controls)
            //   {
            //   try
            //    {

            //       Button b = (Button)c;
            //       b.IsEnabled = true;
            //     }//end try
            //     catch { }
            //   }//end foreach
        }

        private void button_enter(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if(b.IsEnabled)
            { 
              if (turn)
                b.Content = "X";
              else
                b.Content = "O";
            }//end if
        }

        private void button_leave(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (b.IsEnabled)
            {
                b.Content = "";
            }//end if
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            o_win_count.Content = "0";
            X_win_count.Content = "0";
            draw_count.Content = "0";
        }//each player will have there turn and counts the number of times the player won
    }
}
