using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchMeIfYouCan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = this.PointToClient(Cursor.Position).X.ToString();
            textBox2.Text = this.PointToClient(Cursor.Position).Y.ToString();
            textBox3.Text = button1.Location.X.ToString();
            textBox4.Text = button1.Location.Y.ToString();
            var delta = 25;

            button1.Location = this.PointToClient(Cursor.Position).X > button1.Location.X ?
                                                  new Point(button1.Location.X - delta, button1.Location.Y) :
                                                  new Point(button1.Location.X + delta, button1.Location.Y);
            button1.Location = this.PointToClient(Cursor.Position).Y > button1.Location.Y ?
                                                  new Point(button1.Location.X, button1.Location.Y - delta) :
                                                  new Point(button1.Location.X, button1.Location.Y + delta);

            if (button1.Location.X < 0) button1.Location = new Point(ClientRectangle.Width, button1.Location.Y);
            //if (button1.Location.X > this.Left) button1.Location = new Point(this.Width, button1.Location.Y);
            if (button1.Location.Y < 0) button1.Location = new Point(button1.Location.X, ClientRectangle.Bottom);
            //if (button1.Location.Y > this.Bottom) button1.Location = new Point(button1.Location.X, this.Top);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You caught me, punk!!!");
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (string.Equals((sender as Button)?.Name, @"CloseButton")) MessageBox.Show("You caught me, punk!!!");
            //// Do something proper to CloseButton.
            //else 
            switch (e.CloseReason)
            {
                case CloseReason.TaskManagerClosing:
                    MessageBox.Show("Taks manager?! You're too smart, you, little scum!");
                    break;
                case CloseReason.WindowsShutDown:
                    MessageBox.Show("Only by shutting windows down :-)");
                    break;
                case CloseReason.UserClosing:
                    MessageBox.Show("Don't push that button, nooooooooooooo");
                    break;
            }
            // Then assume that X has been clicked and act accordingly.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = MousePosition.X.ToString();
            textBox2.Text = MousePosition.Y.ToString();
            textBox3.Text = button1.Location.X.ToString();
            textBox4.Text = button1.Location.Y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Location = new Point(this.ClientSize.Width / 2 - button1.Size.Width / 2, this.ClientSize.Height / 2 - button1.Size.Height / 2);
        }
    }
}

