namespace TestSerialPort
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTransmit = new System.Windows.Forms.TextBox();
            this.cmbBaudrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHexmode = new System.Windows.Forms.CheckBox();
            this.chkACK = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(81, 3);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(87, 24);
            this.cmbPort.TabIndex = 1;
            // 
            // txtReceive
            // 
            this.txtReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceive.Location = new System.Drawing.Point(0, 60);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(380, 126);
            this.txtReceive.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(295, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTransmit
            // 
            this.txtTransmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransmit.Location = new System.Drawing.Point(0, 206);
            this.txtTransmit.Multiline = true;
            this.txtTransmit.Name = "txtTransmit";
            this.txtTransmit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTransmit.Size = new System.Drawing.Size(380, 138);
            this.txtTransmit.TabIndex = 4;
            this.txtTransmit.TextChanged += new System.EventHandler(this.txtTransmit_TextChanged);
            // 
            // cmbBaudrate
            // 
            this.cmbBaudrate.FormattingEnabled = true;
            this.cmbBaudrate.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.cmbBaudrate.Location = new System.Drawing.Point(174, 3);
            this.cmbBaudrate.Name = "cmbBaudrate";
            this.cmbBaudrate.Size = new System.Drawing.Size(87, 24);
            this.cmbBaudrate.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Receive:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Transmit:";
            // 
            // chkHexmode
            // 
            this.chkHexmode.AutoSize = true;
            this.chkHexmode.Location = new System.Drawing.Point(81, 30);
            this.chkHexmode.Name = "chkHexmode";
            this.chkHexmode.Size = new System.Drawing.Size(89, 21);
            this.chkHexmode.TabIndex = 8;
            this.chkHexmode.Text = "Hexmode";
            this.chkHexmode.UseVisualStyleBackColor = true;
            this.chkHexmode.CheckedChanged += new System.EventHandler(this.chkHexmode_CheckedChanged);
            // 
            // chkACK
            // 
            this.chkACK.AutoSize = true;
            this.chkACK.Location = new System.Drawing.Point(172, 30);
            this.chkACK.Name = "chkACK";
            this.chkACK.Size = new System.Drawing.Size(57, 21);
            this.chkACK.TabIndex = 9;
            this.chkACK.Text = "ACK";
            this.chkACK.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 347);
            this.Controls.Add(this.chkACK);
            this.Controls.Add(this.chkHexmode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBaudrate);
            this.Controls.Add(this.txtTransmit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTransmit;
        private System.Windows.Forms.ComboBox cmbBaudrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkHexmode;
        private System.Windows.Forms.CheckBox chkACK;
    }
}

