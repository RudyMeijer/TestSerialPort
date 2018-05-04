using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSerialPort
{
    public partial class Form1 : Form
    {
        private SerialPort Port;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cmbPort.DataSource = SerialPort.GetPortNames();
            cmbPort.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            try
            {
                Port = new SerialPort(portName: cmbPort.Text, baudRate: 9600, parity: Parity.None);
                Port.Open();
                if (Port.IsOpen) txtReceive.Text = $"Connected to port {Port.PortName}";
                while (Port.IsOpen)
                {
                    txtReceive.Text += Port.ReadExisting();
                    Application.DoEvents();
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Port.Close();
            txtReceive.Text += $"\r\nPort {Port.PortName} closed.";
        }

        private void txtTransmit_TextChanged(object sender, EventArgs e)
        {
            if (Port.IsOpen) Port.Write(txtTransmit.Text.Last().ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Port?.Close();
        }
    }
}
