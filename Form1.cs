using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO2
{
    public partial class Form1 : Form
    {
        private bool gameOver = false;
        private bool turn = true;
        public Form1()
        {
            InitializeComponent();
            A1.Click += Button;
            A2.Click += Button;
            A3.Click += Button;
            B1.Click += Button;
            B3.Click += Button;
            B2.Click += Button;
            C1.Click += Button;
            C2.Click += Button;
            C3.Click += Button;



            A1.Enabled = false;
            A2.Enabled = false;
            A3.Enabled = false;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = false;
            C1.Enabled = false;
            C2.Enabled = false;
            C3.Enabled = false;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            gameOver = false;
            A1.Enabled = true;
            A2.Enabled = true;
            A3.Enabled = true;
            B1.Enabled = true;
            B2.Enabled = true;
            B3.Enabled = true;
            C1.Enabled = true;
            C2.Enabled = true;
            C3.Enabled = true;


        }
        private void Button(object sender,EventArgs e)
        {
            if (turn)
            {
                Button C = sender as Button;
                C.Text = "X";
              
                Computer_move();
               
            }
        }

        private Button find_corner_O(string txt)
        {
            if(A1.Text == "O")
            {
                if (A3.Text == "") 
                {
                    return A3;
                }
                if(C3.Text == "")
                {
                    return C3;
                }
                if(C1.Text == "")
                {
                    return C1;
                }
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                {
                    return A1;
                }
                if (C3.Text == "")
                {
                    return C3;
                }
                if (C1.Text == "")
                {
                    return C1;
                }
            }

            if (C1.Text == "O")
            {
                if (A3.Text == "")
                {
                    return A3;
                }
                if (C3.Text == "")
                {
                    return C3;
                }
                if (A1.Text == "")
                {
                    return A1;
                }
            }


            if (C3.Text == "O")
            {
                if (A3.Text == "")
                {
                    return A3;
                }
                if (A1.Text == "")
                {
                    return A1;
                }
                if (C1.Text == "")
                {
                    return C1;
                }
            }


            if (A1.Text == "") { return A1; }
            if (A3.Text == "") { return A3; }
            if (C1.Text == "") { return C1; }
            if (C3.Text == "") { return C3; }

            return null;
        }

        private Button check_block_X(string txt)
        {
            //horizontal
            if (A1.Text == "X" && A2.Text == "X" && A3.Text == "")
            {
                return A3;
            }
            if (A2.Text == "X" && A3.Text == "X" && A1.Text == "")
            {
                return A1;
            }
            if (A1.Text == "X" && A3.Text == "X" && A2.Text == "")
            {
                return A2;
            }

            if (B1.Text == "X" && B2.Text == "X" && B3.Text == "")
            {
                return B3;
            }
            if (B2.Text == "X" && B3.Text == "X" && B1.Text == "")
            {
                return B1;
            }
            if (B1.Text == "X" && B3.Text == "X" && B1.Text == "")
            {
                return B1;
            }


            if (C1.Text == "X" && C2.Text == "X" && C3.Text == "")
            {
                return C3;
            }
            if (C2.Text == "X" && C3.Text == "X" && C1.Text == "")
            {
                return C1;
            }
            if (C1.Text == "X" && C3.Text == "X" && C2.Text == "")
            {
                return C2;
            }

            //vertical

            if (A1.Text == "X" && B1.Text == "X" && C1.Text == "")
            {
                return C1;
            }
            if (A1.Text == "X" && C1.Text == "X" && B1.Text == "")
            {
                return B1;
            }
            if (B1.Text == "X" && C1.Text == "X" && A1.Text == "")
            {
                return A1;
            }



            if (A2.Text == "X" && B2.Text == "X" && C2.Text == "")
            {
                return C2;
            }
            if (A2.Text == "X" && C2.Text == "X" && B2.Text == "")
            {
                return B2;
            }
            if (B2.Text == "X" && C2.Text == "X" && A2.Text == "")
            {
                return A2;
            }


            if (A3.Text == "X" && B3.Text == "X" && C3.Text == "")
            {
                return C2;
            }
            if (A3.Text == "X" && C3.Text == "X" && B3.Text == "")
            {
                return B3;
            }
            if (B3.Text == "X" && C3.Text == "X" && A3.Text == "")
            {
                return A3;
            }

            //Diagonal
            if (A1.Text == "X" && B2.Text == "X" && C3.Text == "")
            {
                return C3;
            }
            if (A1.Text == "X" && C3.Text == "X" && B2.Text == "")
            {
                return B2;
            }
            if (B2.Text == "X" && C3.Text == "X" && A1.Text == "")
            {
                return A1;
            }

            if (A3.Text == "X" && B2.Text == "X" && C1.Text == "")
            {
                return C1;
            }
            if (C1.Text == "X" && B2.Text == "X" && A3.Text == "")
            {
                return A3;
            }
            if (C1.Text == "X" && A3.Text == "X" && B2.Text == "")
            {
                return B2;
            }

            return null;
        }

        private void Computer_move()
        {
            Button b = null;
            b = check_win_O("O");
            if (b == null)
            {
                b = check_block_X("X");
                if (b == null)
                {
                    b = find_corner_O("O");
                    if(b == null)
                    {
                        b = find_free_place();
                    }
                }
            }

            

            if (b!= null)
            {
                MakeMove(b);
            }
            else
            {
                MessageBox.Show("Game Over!");
            }
            
        }

        private void check_Winner_X(string v)
        {
            if (A1.Text == v && A2.Text == v && A3.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }
            if (B1.Text == v && B2.Text == v && B3.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }
            if (C1.Text == v && C2.Text == v && C3.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }



            if (A1.Text == v && B1.Text == v && C1.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }
            if (A2.Text == v && B2.Text == v && C2.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }
            if (A3.Text == v && B3.Text == v && C3.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }



            if (A1.Text == v && B2.Text == v && C3.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }
            if (C1.Text == v && B2.Text == v && A3.Text == v)
            {
                MessageBox.Show("Human Won");
                gameOver = true;
            }
        }

        private void check_Winner_O(string v)
        {
            if(A1.Text == v && A2.Text == v && A3.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }
            if (B1.Text == v && B2.Text == v && B3.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }
            if (C1.Text == v && C2.Text == v && C3.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }



            if(A1.Text == v && B1.Text == v && C1.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }
            if (A2.Text == v && B2.Text == v && C2.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }
            if (A3.Text == v && B3.Text == v && C3.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }



            if(A1.Text == v && B2.Text == v && C3.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }
            if (C1.Text == v && B2.Text == v && A3.Text == v)
            {
                MessageBox.Show("Computer Won");
                gameOver = true;
            }
        }

        private void MakeMove(Button b)
        {
            b.Text = "O";
            check_Winner_O("O");
            check_Winner_X("X");
            if (gameOver == true)
            {
                A1.Text = "";
                A2.Text = "";
                A3.Text = "";
                B3.Text = "";
                B2.Text = "";
                B1.Text = "";
                C3.Text = "";
                C2.Text = "";
                C1.Text = "";
            }
        }

        private Button find_free_place()
        {
            foreach (Button k in Controls)
            {
                Button b = k as Button;
                
                if(b.Text == "")
                {
                    return b;
                }
            }
            return null;
        }

        private Button check_win_O(string txt)
        {
            //horizontal
            if(A1.Text == "O" && A2.Text == "O" && A3.Text == "")
            {
                return A3;
            }
            if (A2.Text == "O" && A3.Text == "O" && A1.Text == "")
            {
                return A1;
            }
            if (A1.Text == "O" && A3.Text == "O" && A2.Text == "")
            {
                return A2;
            }

            if (B1.Text == "O" && B2.Text == "O" && B3.Text == "")
            {
                return B3;
            }
            if (B2.Text == "O" && B3.Text == "O" && B1.Text == "")
            {
                return B1;
            }
            if (B1.Text == "O" && B3.Text == "O" && B1.Text == "")
            {
                return B1;
            }


            if (C1.Text == "O" && C2.Text == "O" && C3.Text == "")
            {
                return C3;
            }
            if (C2.Text == "O" && C3.Text == "O" && C1.Text == "")
            {
                return C1;
            }
            if (C1.Text == "O" && C3.Text == "O" && C2.Text == "")
            {
                return C2;
            }

            //vertical

            if(A1.Text == "O" && B1.Text == "O" && C1.Text == "")
            {
                return C1;
            }
            if (A1.Text == "O" && C1.Text == "O" && B1.Text == "")
            {
                return B1;
            }
            if (B1.Text == "O" && C1.Text == "O" && A1.Text == "")
            {
                return A1;
            }



            if (A2.Text == "O" && B2.Text == "O" && C2.Text == "")
            {
                return C2;
            }
            if (A2.Text == "O" && C2.Text == "O" && B2.Text == "")
            {
                return B2;
            }
            if (B2.Text == "O" && C2.Text == "O" && A2.Text == "")
            {
                return A2;
            }


            if (A3.Text == "O" && B3.Text == "O" && C3.Text == "")
            {
                return C2;
            }
            if (A3.Text == "O" && C3.Text == "O" && B3.Text == "")
            {
                return B3;
            }
            if (B3.Text == "O" && C3.Text == "O" && A3.Text == "")
            {
                return A3;
            }

            //Diagonal
            if (A1.Text == "O" && B2.Text == "O" && C3.Text == "")
            {
                return C3;
            }
            if (A1.Text == "O" && C3.Text == "O" && B2.Text == "")
            {
                return B2;
            }
            if(B2.Text == "O" && C3.Text == "O" &&  A1.Text == "")
            {
                return A1;
            }

            if (A3.Text == "O" && B2.Text == "O" && C1.Text == "")
            {
                return C1;
            }
            if (C1.Text == "O" && B2.Text == "O" && A3.Text == "")
            {
                return A3;
            }
            if (C1.Text == "O" && A3.Text == "O" && B2.Text == "")
            {
                return B2;
            }

            return null;
        }
    }
}
