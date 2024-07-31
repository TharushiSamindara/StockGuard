using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemApp
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();

            //Starting a timer named "timer1"
            timer1.Start();
        }

        int startPoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 2;
            
            //Setting the value of progressBar1 to the current startPoint
            //If progressBar1 value has reached 100 reset it to 0 and stop the timer
            progressBar1.Value = startPoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();

                //Create aninstance of login form and display it
                LoginForm login = new LoginForm();
                this.Hide();
                login.ShowDialog();
            }
        }
    }
}
