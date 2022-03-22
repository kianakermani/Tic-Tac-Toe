using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {

        bool turn = true; // true= x turn; false = o turn
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Game Made By Kiana", "Tic Tac Toe About", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butten_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
                
            }
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            CheckForWinner();


        }
        private void CheckForWinner()
        {
            bool there_is_a_winner = false;

            //horizental checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&& (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                there_is_a_winner = true;
            }
            //vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                there_is_a_winner = true;
            }
            //diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                there_is_a_winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                there_is_a_winner = true;
            }

            if (there_is_a_winner)
            {
                disableButtons();

                string winner = " ";
                if (turn)
                {
                    winner = "O";
                    co.Text = (Int32.Parse(co.Text)+1).ToString();
                }
                else
                {
                    winner = "X";
                    cx.Text = (Int32.Parse(cx.Text) + 1).ToString();
                }
                MessageBox.Show(winner + " wins!", "Yay!", MessageBoxButtons.OK);
                disableButtons();
            }
            else
            {
                if (turn_count == 9)
                {
                    cd.Text = (Int32.Parse(cd.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Bummer!", MessageBoxButtons.OK);
                    disableButtons();


                }
            }

        }//end checkForWinner

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            {

            }

            

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = " ";

                }
                catch
                {

                }
            }

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
            
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = " ";
            }
        }
    }
}
