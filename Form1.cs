using ASCS.Lib.RemoteGatewayComponent.GPRS.Test;
using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestSerialPort
{
    public partial class Form1 : Form
    {
        private SerialPort Port;
        private bool bHexmode;
        private eGateSimulation eGateSim;
        private readonly byte STX = 0x02;
        private readonly byte ACK = 0x05;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            eGateSim = new eGateSimulation();
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
                //Port.Handshake = Handshake.XOnXOff;
                txtTransmit.Clear();
                if (Port.IsOpen) txtReceive.Text = $"Connected to port {Port.PortName}        ";

                var output = new StringBuilder();
                while (Port.IsOpen)
                {
                    var n = Port.BytesToRead;
                    if (n > 0)
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(Port.ReadExisting());
                        txtReceive.Text += Show(bytes);

                        if (bytes[0] == STX && bytes.Length==9)
                        {
                            var list = eGateSim.GenerateAckMessage(bytes);
                            var outp = list.ToArray();
                            Port.Write(outp,0,outp.Length);
                            txtTransmit.Text += Show(outp);
                        }
                        //foreach (var c in s)
                        //{
                        //    if (c <= 32 || bHexmode)
                        //    {
                        //        output.Append($"[{(int)c:X2}]");
                        //    }
                        //    else output.Append(c);
                        //}
                    }
                    Application.DoEvents();
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); Port?.Close(); }
        }

        private string Show(byte[] input)
        {
            string s = Encoding.ASCII.GetString(input);

            if (!bHexmode) return s;
            var output = new StringBuilder();

            foreach (var c in input) output.Append($"[{(int)c:X2}]");

            return output.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Port.Close();
            txtReceive.Text += $"\r\nPort {Port.PortName} closed.";
        }

        private void txtTransmit_TextChanged(object sender, EventArgs e)
        {
            if (Port.IsOpen && txtTransmit.Text.Length > 0) Port.Write(txtTransmit.Text.Last().ToString());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Port?.Close();
        }

        private void chkHexmode_CheckedChanged(object sender, EventArgs e)
        {
            bHexmode = chkHexmode.Checked;
            txtReceive.Clear();
            txtTransmit.Clear();
        }
    }
}
