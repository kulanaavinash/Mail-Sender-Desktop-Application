using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Mail_Sender_Desktop_Application
{
    public partial class Form2 : Form
    {
        int mov;
        int movX;
        int movY;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string to, from, pass, messageBody;
            MailMessage message = new MailMessage();
            to = textmail.Text;
            from = "";
            pass = "";
            messageBody = txtmsg.Text;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = "From : " + "<br>Message: "+ messageBody;
            message.Subject = txtsub.Text;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                DialogResult code = MessageBox.Show("Email Sent Successfully", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (code == DialogResult.OK)
                {
                    textmail.Clear();
                    txtsub.Clear();
                    txtmsg.Clear();
                        
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textmail_Enter(object sender, EventArgs e)
        {
            if(textmail.Text == " Email")
            {
                textmail.Clear();
                textmail.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void textmail_Leave(object sender, EventArgs e)
        {
            if (textmail.Text == "")
            {
                textmail.ForeColor = Color.FromArgb(200, 200, 200);
                textmail.Text = "  Email";
            }
        }

        private void txtsub_Enter(object sender, EventArgs e)
        {
            if (txtsub.Text == " Subject")
            {
                txtsub.Clear();
                txtsub.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtsub_Leave(object sender, EventArgs e)
        {
            if (txtsub.Text == "")
            {
                txtsub.ForeColor = Color.FromArgb(200, 200, 200);
                txtsub.Text = "  Subject";
            }
        }

        private void txtmsg_Enter(object sender, EventArgs e)
        {
            if (txtmsg.Text == " Message")
            {
                txtmsg.Clear();
                txtmsg.ForeColor = Color.FromArgb(83, 179, 233);
            }
        }

        private void txtmsg_Leave(object sender, EventArgs e)
        {
            if (txtmsg.Text == "")
            {
                txtmsg.ForeColor = Color.FromArgb(200, 200, 200);
                txtmsg.Text = "  Message";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov ==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
