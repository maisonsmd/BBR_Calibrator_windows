namespace BBR_Calibrator {
	partial class FrmMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing ) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( ) {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TextViewLogData = new System.Windows.Forms.RichTextBox();
            this.TabSelectorMain = new MaterialSkin.Controls.MaterialTabSelector();
            this.TabControlMain = new MaterialSkin.Controls.MaterialTabControl();
            this.TabPageHome = new System.Windows.Forms.TabPage();
            this.btnOpenPort = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnClosePort = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TabPageLog = new System.Windows.Forms.TabPage();
            this.TabControlLog = new MaterialSkin.Controls.MaterialTabControl();
            this.TabPageLogData = new System.Windows.Forms.TabPage();
            this.CheckBoxEnableLogging = new MaterialSkin.Controls.MaterialCheckBox();
            this.TabPageLogEvents = new System.Windows.Forms.TabPage();
            this.TextViewEvents = new System.Windows.Forms.RichTextBox();
            this.TabSelectorLog = new MaterialSkin.Controls.MaterialTabSelector();
            this.TabControlMain.SuspendLayout();
            this.TabPageHome.SuspendLayout();
            this.TabPageLog.SuspendLayout();
            this.TabControlLog.SuspendLayout();
            this.TabPageLogData.SuspendLayout();
            this.TabPageLogEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextViewLogData
            // 
            this.TextViewLogData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextViewLogData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextViewLogData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextViewLogData.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextViewLogData.DetectUrls = false;
            this.TextViewLogData.EnableAutoDragDrop = true;
            this.TextViewLogData.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextViewLogData.ForeColor = System.Drawing.Color.White;
            this.TextViewLogData.Location = new System.Drawing.Point(0, 6);
            this.TextViewLogData.MaxLength = 1000;
            this.TextViewLogData.Name = "TextViewLogData";
            this.TextViewLogData.ShortcutsEnabled = false;
            this.TextViewLogData.Size = new System.Drawing.Size(780, 386);
            this.TextViewLogData.TabIndex = 0;
            this.TextViewLogData.Text = "";
            // 
            // TabSelectorMain
            // 
            this.TabSelectorMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabSelectorMain.BaseTabControl = this.TabControlMain;
            this.TabSelectorMain.Depth = 0;
            this.TabSelectorMain.Location = new System.Drawing.Point(-1, 63);
            this.TabSelectorMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabSelectorMain.Name = "TabSelectorMain";
            this.TabSelectorMain.Size = new System.Drawing.Size(815, 37);
            this.TabSelectorMain.TabIndex = 5;
            this.TabSelectorMain.Text = "materialTabSelector1";
            // 
            // TabControlMain
            // 
            this.TabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlMain.Controls.Add(this.TabPageHome);
            this.TabControlMain.Controls.Add(this.TabPageLog);
            this.TabControlMain.Depth = 0;
            this.TabControlMain.Location = new System.Drawing.Point(-1, 106);
            this.TabControlMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(815, 529);
            this.TabControlMain.TabIndex = 6;
            // 
            // TabPageHome
            // 
            this.TabPageHome.Controls.Add(this.btnOpenPort);
            this.TabPageHome.Controls.Add(this.btnClosePort);
            this.TabPageHome.Location = new System.Drawing.Point(4, 24);
            this.TabPageHome.Name = "TabPageHome";
            this.TabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageHome.Size = new System.Drawing.Size(807, 501);
            this.TabPageHome.TabIndex = 0;
            this.TabPageHome.Text = "Home";
            this.TabPageHome.UseVisualStyleBackColor = true;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.AutoSize = true;
            this.btnOpenPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenPort.Depth = 0;
            this.btnOpenPort.Icon = null;
            this.btnOpenPort.Location = new System.Drawing.Point(79, 24);
            this.btnOpenPort.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Primary = true;
            this.btnOpenPort.Size = new System.Drawing.Size(57, 36);
            this.btnOpenPort.TabIndex = 1;
            this.btnOpenPort.Text = "open";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.BtnOpenPort_Click);
            // 
            // btnClosePort
            // 
            this.btnClosePort.AutoSize = true;
            this.btnClosePort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClosePort.Depth = 0;
            this.btnClosePort.Icon = null;
            this.btnClosePort.Location = new System.Drawing.Point(10, 24);
            this.btnClosePort.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Primary = true;
            this.btnClosePort.Size = new System.Drawing.Size(63, 36);
            this.btnClosePort.TabIndex = 0;
            this.btnClosePort.Text = "close";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.BtnClosePort_Click);
            // 
            // TabPageLog
            // 
            this.TabPageLog.Controls.Add(this.TabControlLog);
            this.TabPageLog.Controls.Add(this.TabSelectorLog);
            this.TabPageLog.Location = new System.Drawing.Point(4, 24);
            this.TabPageLog.Name = "TabPageLog";
            this.TabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLog.Size = new System.Drawing.Size(807, 501);
            this.TabPageLog.TabIndex = 1;
            this.TabPageLog.Text = "Log";
            this.TabPageLog.UseVisualStyleBackColor = true;
            // 
            // TabControlLog
            // 
            this.TabControlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlLog.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControlLog.Controls.Add(this.TabPageLogEvents);
            this.TabControlLog.Controls.Add(this.TabPageLogData);
            this.TabControlLog.Depth = 0;
            this.TabControlLog.Location = new System.Drawing.Point(9, 46);
            this.TabControlLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlLog.Name = "TabControlLog";
            this.TabControlLog.SelectedIndex = 0;
            this.TabControlLog.Size = new System.Drawing.Size(788, 449);
            this.TabControlLog.TabIndex = 7;
            // 
            // TabPageLogData
            // 
            this.TabPageLogData.Controls.Add(this.TextViewLogData);
            this.TabPageLogData.Controls.Add(this.CheckBoxEnableLogging);
            this.TabPageLogData.Location = new System.Drawing.Point(4, 27);
            this.TabPageLogData.Name = "TabPageLogData";
            this.TabPageLogData.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLogData.Size = new System.Drawing.Size(780, 418);
            this.TabPageLogData.TabIndex = 0;
            this.TabPageLogData.Text = "DATA";
            this.TabPageLogData.UseVisualStyleBackColor = true;
            // 
            // CheckBoxEnableLogging
            // 
            this.CheckBoxEnableLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxEnableLogging.AutoSize = true;
            this.CheckBoxEnableLogging.Depth = 0;
            this.CheckBoxEnableLogging.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckBoxEnableLogging.Location = new System.Drawing.Point(3, 395);
            this.CheckBoxEnableLogging.Margin = new System.Windows.Forms.Padding(0);
            this.CheckBoxEnableLogging.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckBoxEnableLogging.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBoxEnableLogging.Name = "CheckBoxEnableLogging";
            this.CheckBoxEnableLogging.Ripple = true;
            this.CheckBoxEnableLogging.Size = new System.Drawing.Size(120, 30);
            this.CheckBoxEnableLogging.TabIndex = 5;
            this.CheckBoxEnableLogging.Text = "enable logging";
            this.CheckBoxEnableLogging.UseVisualStyleBackColor = true;
            // 
            // TabPageLogEvents
            // 
            this.TabPageLogEvents.Controls.Add(this.TextViewEvents);
            this.TabPageLogEvents.Location = new System.Drawing.Point(4, 27);
            this.TabPageLogEvents.Name = "TabPageLogEvents";
            this.TabPageLogEvents.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLogEvents.Size = new System.Drawing.Size(780, 418);
            this.TabPageLogEvents.TabIndex = 1;
            this.TabPageLogEvents.Text = "EVENTS";
            this.TabPageLogEvents.UseVisualStyleBackColor = true;
            // 
            // TextViewEvents
            // 
            this.TextViewEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextViewEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextViewEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextViewEvents.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextViewEvents.Font = new System.Drawing.Font("Monaco", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextViewEvents.ForeColor = System.Drawing.Color.White;
            this.TextViewEvents.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextViewEvents.Location = new System.Drawing.Point(0, 0);
            this.TextViewEvents.Margin = new System.Windows.Forms.Padding(5);
            this.TextViewEvents.MaxLength = 2000;
            this.TextViewEvents.Name = "TextViewEvents";
            this.TextViewEvents.ShortcutsEnabled = false;
            this.TextViewEvents.Size = new System.Drawing.Size(780, 422);
            this.TextViewEvents.TabIndex = 2;
            this.TextViewEvents.Text = "";
            // 
            // TabSelectorLog
            // 
            this.TabSelectorLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabSelectorLog.BaseTabControl = this.TabControlLog;
            this.TabSelectorLog.Depth = 0;
            this.TabSelectorLog.Location = new System.Drawing.Point(548, 6);
            this.TabSelectorLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabSelectorLog.Name = "TabSelectorLog";
            this.TabSelectorLog.Size = new System.Drawing.Size(249, 37);
            this.TabSelectorLog.TabIndex = 6;
            this.TabSelectorLog.Text = "TabSelectorLog";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(812, 647);
            this.Controls.Add(this.TabControlMain);
            this.Controls.Add(this.TabSelectorMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "BBR Calibrator";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageHome.ResumeLayout(false);
            this.TabPageHome.PerformLayout();
            this.TabPageLog.ResumeLayout(false);
            this.TabControlLog.ResumeLayout(false);
            this.TabPageLogData.ResumeLayout(false);
            this.TabPageLogData.PerformLayout();
            this.TabPageLogEvents.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion
        private System.Windows.Forms.RichTextBox TextViewLogData;
        private MaterialSkin.Controls.MaterialTabSelector TabSelectorMain;
        private MaterialSkin.Controls.MaterialTabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPageHome;
        private System.Windows.Forms.TabPage TabPageLog;
        private MaterialSkin.Controls.MaterialCheckBox CheckBoxEnableLogging;
        private MaterialSkin.Controls.MaterialRaisedButton btnOpenPort;
        private MaterialSkin.Controls.MaterialRaisedButton btnClosePort;
        private MaterialSkin.Controls.MaterialTabControl TabControlLog;
        private System.Windows.Forms.TabPage TabPageLogData;
        private System.Windows.Forms.TabPage TabPageLogEvents;
        private MaterialSkin.Controls.MaterialTabSelector TabSelectorLog;
        private System.Windows.Forms.RichTextBox TextViewEvents;
    }
}

