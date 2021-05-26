using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mail_Sender_Desktop_Application
{
    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtuser.Text=="admin" && txtpassword.Text=="1234")
            {
                new Form2().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("The Username or password entered is incorrect, Try Again");
                txtuser.Clear();
                txtpassword.Clear();
                txtuser.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpassword.Clear();
            txtuser.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
