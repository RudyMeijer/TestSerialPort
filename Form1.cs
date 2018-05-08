using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace TestSerialPort
{
    public partial class Form1 : Form
    {
        private SerialPort Port;
        private bool bHexmode;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cmbPort.DataSource = SerialPort.GetPortNames();
            cmbPort.SelectedIndex = 0;
            cmbBaudrate.SelectedIndex = 1; // default 115200
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            try
            {
                Port = new SerialPort(portName: cmbPort.Text, baudRate: int.Parse(cmbBaudrate.Text), parity: Parity.None);
                Port.Open();
                Port.Handshake = Handshake.XOnXOff;
                if (Port.IsOpen) txtReceive.Text = $"Connected to port {Port.PortName}        ";
                while (Port.IsOpen)
                {
                    var n = Port.BytesToRead;
                    if (n > 0)
                    {
                        var c = (char)Port.ReadChar();
                        var s = c.ToString();
                        if (c <= 32 || bHexmode)
                        {
                            s = $"[{(int)c:X2}]";
                        }
                        txtReceive.Text += s;
                    }
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

        private void chkHexmode_CheckedChanged(object sender, EventArgs e)
        {
            bHexmode = chkHexmode.Checked;
        }
    }
}
