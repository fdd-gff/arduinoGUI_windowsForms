using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Arduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void getAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            guna2ComboBox1.Items.AddRange(ports);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (guna2ComboBox1.Text==""||guna2ComboBox2.Text=="")
                {
                    label3.Text = "Please select port settings";
                    label3.Visible = true;
                }
                else
                {
                    serialPort1.PortName = guna2ComboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(guna2ComboBox2.Text);
                    serialPort1.Open();
                    guna2Button1.Visible = false;
                    guna2Button2.Visible = true;
                    timer1.Interval = 500;
                    timer1.Enabled = true;
                    this.timer1.Tick += new System.EventHandler(this.timer1_Tick); 

                }

            }
            catch (UnauthorizedAccessException)
            {
                label3.Text = " Unauthorized access";
                label3.Visible = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            guna2Button2.Visible = false;
            guna2Button1.Visible = true;
            timer1.Enabled = false;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2TextBox2.Text = serialPort1.ReadLine();
        }
    }
}
