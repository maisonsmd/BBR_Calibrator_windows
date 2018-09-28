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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.TextViewData = new System.Windows.Forms.RichTextBox();
            this.TabSelectorMain = new MaterialSkin.Controls.MaterialTabSelector();
            this.TabControlMain = new MaterialSkin.Controls.MaterialTabControl();
            this.TabPageHome = new System.Windows.Forms.TabPage();
            this.BtnRequest = new MaterialSkin.Controls.MaterialRaisedButton();
            this.BtnConnect = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TabPageIMU = new System.Windows.Forms.TabPage();
            this.TabPageMotors = new System.Windows.Forms.TabPage();
            this.TabPageRobot = new System.Windows.Forms.TabPage();
            this.TabPageLog = new System.Windows.Forms.TabPage();
            this.TabControlLog = new MaterialSkin.Controls.MaterialTabControl();
            this.TabPageLogEvents = new System.Windows.Forms.TabPage();
            this.TextViewEvents = new System.Windows.Forms.RichTextBox();
            this.TabPageLogData = new System.Windows.Forms.TabPage();
            this.CheckBoxEnableDataInLogging = new MaterialSkin.Controls.MaterialCheckBox();
            this.TabPageDataOut = new System.Windows.Forms.TabPage();
            this.CheckBoxEnableDataOutLogging = new MaterialSkin.Controls.MaterialCheckBox();
            this.TextViewDataOut = new System.Windows.Forms.RichTextBox();
            this.TabSelectorLog = new MaterialSkin.Controls.MaterialTabSelector();
            this.GraphXZ = new BBR_Calibrator.GraphicHelpers.Graph2D();
            this.GraphYZ = new BBR_Calibrator.GraphicHelpers.Graph2D();
            this.GraphXY = new BBR_Calibrator.GraphicHelpers.Graph2D();
            this.BtnClearEvents = new MaterialSkin.Controls.MaterialFlatButton();
            this.BtnClearDataIn = new MaterialSkin.Controls.MaterialFlatButton();
            this.BtnClearIMU = new MaterialSkin.Controls.MaterialRaisedButton();
            this.BtnStartIMU = new MaterialSkin.Controls.MaterialRaisedButton();
            this.BtnStopIMU = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TimerRequestIMU = new System.Windows.Forms.Timer(this.components);
            this.CheckBoxScaled = new System.Windows.Forms.CheckBox();
            this.BtnClearScale = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.LblHeading = new System.Windows.Forms.Label();
            this.TabControlMain.SuspendLayout();
            this.TabPageHome.SuspendLayout();
            this.TabPageIMU.SuspendLayout();
            this.TabPageLog.SuspendLayout();
            this.TabControlLog.SuspendLayout();
            this.TabPageLogEvents.SuspendLayout();
            this.TabPageLogData.SuspendLayout();
            this.TabPageDataOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextViewData
            // 
            this.TextViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextViewData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextViewData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextViewData.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextViewData.DetectUrls = false;
            this.TextViewData.EnableAutoDragDrop = true;
            this.TextViewData.Font = new System.Drawing.Font("Monospac821 BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextViewData.ForeColor = System.Drawing.Color.White;
            this.TextViewData.Location = new System.Drawing.Point(6, 6);
            this.TextViewData.MaxLength = 1000;
            this.TextViewData.Name = "TextViewData";
            this.TextViewData.ShortcutsEnabled = false;
            this.TextViewData.Size = new System.Drawing.Size(768, 381);
            this.TextViewData.TabIndex = 0;
            this.TextViewData.Text = "";
            // 
            // TabSelectorMain
            // 
            this.TabSelectorMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabSelectorMain.BaseTabControl = this.TabControlMain;
            this.TabSelectorMain.Depth = 0;
            this.TabSelectorMain.Font = new System.Drawing.Font("Roboto", 10F);
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
            this.TabControlMain.Controls.Add(this.TabPageIMU);
            this.TabControlMain.Controls.Add(this.TabPageMotors);
            this.TabControlMain.Controls.Add(this.TabPageRobot);
            this.TabControlMain.Controls.Add(this.TabPageLog);
            this.TabControlMain.Depth = 0;
            this.TabControlMain.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabControlMain.Location = new System.Drawing.Point(-1, 106);
            this.TabControlMain.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(815, 543);
            this.TabControlMain.TabIndex = 6;
            this.TabControlMain.TabStop = false;
            // 
            // TabPageHome
            // 
            this.TabPageHome.Controls.Add(this.BtnRequest);
            this.TabPageHome.Controls.Add(this.BtnConnect);
            this.TabPageHome.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageHome.Location = new System.Drawing.Point(4, 26);
            this.TabPageHome.Name = "TabPageHome";
            this.TabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageHome.Size = new System.Drawing.Size(807, 513);
            this.TabPageHome.TabIndex = 0;
            this.TabPageHome.Text = "Home";
            this.TabPageHome.UseVisualStyleBackColor = true;
            // 
            // BtnRequest
            // 
            this.BtnRequest.AutoSize = true;
            this.BtnRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnRequest.Depth = 0;
            this.BtnRequest.Icon = null;
            this.BtnRequest.Location = new System.Drawing.Point(9, 48);
            this.BtnRequest.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnRequest.Name = "BtnRequest";
            this.BtnRequest.Primary = true;
            this.BtnRequest.Size = new System.Drawing.Size(80, 36);
            this.BtnRequest.TabIndex = 3;
            this.BtnRequest.Text = "Request";
            this.BtnRequest.UseVisualStyleBackColor = true;
            this.BtnRequest.Click += new System.EventHandler(this.BtnRequest_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.AutoSize = true;
            this.BtnConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnConnect.Depth = 0;
            this.BtnConnect.Icon = null;
            this.BtnConnect.Location = new System.Drawing.Point(9, 6);
            this.BtnConnect.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Primary = true;
            this.BtnConnect.Size = new System.Drawing.Size(84, 36);
            this.BtnConnect.TabIndex = 2;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // TabPageIMU
            // 
            this.TabPageIMU.Controls.Add(this.LblHeading);
            this.TabPageIMU.Controls.Add(this.label1);
            this.TabPageIMU.Controls.Add(this.BtnClearScale);
            this.TabPageIMU.Controls.Add(this.CheckBoxScaled);
            this.TabPageIMU.Controls.Add(this.BtnStopIMU);
            this.TabPageIMU.Controls.Add(this.BtnStartIMU);
            this.TabPageIMU.Controls.Add(this.BtnClearIMU);
            this.TabPageIMU.Controls.Add(this.GraphXZ);
            this.TabPageIMU.Controls.Add(this.GraphYZ);
            this.TabPageIMU.Controls.Add(this.GraphXY);
            this.TabPageIMU.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageIMU.Location = new System.Drawing.Point(4, 26);
            this.TabPageIMU.Name = "TabPageIMU";
            this.TabPageIMU.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageIMU.Size = new System.Drawing.Size(807, 513);
            this.TabPageIMU.TabIndex = 2;
            this.TabPageIMU.Text = "IMU";
            this.TabPageIMU.UseVisualStyleBackColor = true;
            // 
            // TabPageMotors
            // 
            this.TabPageMotors.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageMotors.Location = new System.Drawing.Point(4, 26);
            this.TabPageMotors.Name = "TabPageMotors";
            this.TabPageMotors.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMotors.Size = new System.Drawing.Size(807, 513);
            this.TabPageMotors.TabIndex = 3;
            this.TabPageMotors.Text = "Motors";
            this.TabPageMotors.UseVisualStyleBackColor = true;
            // 
            // TabPageRobot
            // 
            this.TabPageRobot.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageRobot.Location = new System.Drawing.Point(4, 26);
            this.TabPageRobot.Name = "TabPageRobot";
            this.TabPageRobot.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRobot.Size = new System.Drawing.Size(807, 513);
            this.TabPageRobot.TabIndex = 4;
            this.TabPageRobot.Text = "Robot";
            this.TabPageRobot.UseVisualStyleBackColor = true;
            // 
            // TabPageLog
            // 
            this.TabPageLog.Controls.Add(this.TabControlLog);
            this.TabPageLog.Controls.Add(this.TabSelectorLog);
            this.TabPageLog.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageLog.Location = new System.Drawing.Point(4, 26);
            this.TabPageLog.Name = "TabPageLog";
            this.TabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLog.Size = new System.Drawing.Size(807, 513);
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
            this.TabControlLog.Controls.Add(this.TabPageDataOut);
            this.TabControlLog.Depth = 0;
            this.TabControlLog.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabControlLog.Location = new System.Drawing.Point(9, 46);
            this.TabControlLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabControlLog.Name = "TabControlLog";
            this.TabControlLog.SelectedIndex = 0;
            this.TabControlLog.Size = new System.Drawing.Size(788, 457);
            this.TabControlLog.TabIndex = 7;
            // 
            // TabPageLogEvents
            // 
            this.TabPageLogEvents.Controls.Add(this.BtnClearEvents);
            this.TabPageLogEvents.Controls.Add(this.TextViewEvents);
            this.TabPageLogEvents.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageLogEvents.Location = new System.Drawing.Point(4, 29);
            this.TabPageLogEvents.Name = "TabPageLogEvents";
            this.TabPageLogEvents.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLogEvents.Size = new System.Drawing.Size(780, 424);
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
            this.TextViewEvents.Font = new System.Drawing.Font("Roboto", 10F);
            this.TextViewEvents.ForeColor = System.Drawing.Color.White;
            this.TextViewEvents.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextViewEvents.Location = new System.Drawing.Point(8, 8);
            this.TextViewEvents.Margin = new System.Windows.Forms.Padding(5);
            this.TextViewEvents.MaxLength = 4000;
            this.TextViewEvents.Name = "TextViewEvents";
            this.TextViewEvents.ShortcutsEnabled = false;
            this.TextViewEvents.Size = new System.Drawing.Size(764, 408);
            this.TextViewEvents.TabIndex = 2;
            this.TextViewEvents.TabStop = false;
            this.TextViewEvents.Text = "";
            // 
            // TabPageLogData
            // 
            this.TabPageLogData.Controls.Add(this.BtnClearDataIn);
            this.TabPageLogData.Controls.Add(this.TextViewData);
            this.TabPageLogData.Controls.Add(this.CheckBoxEnableDataInLogging);
            this.TabPageLogData.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageLogData.Location = new System.Drawing.Point(4, 29);
            this.TabPageLogData.Name = "TabPageLogData";
            this.TabPageLogData.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLogData.Size = new System.Drawing.Size(780, 424);
            this.TabPageLogData.TabIndex = 0;
            this.TabPageLogData.Text = "DATA IN";
            this.TabPageLogData.UseVisualStyleBackColor = true;
            // 
            // CheckBoxEnableDataInLogging
            // 
            this.CheckBoxEnableDataInLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxEnableDataInLogging.AutoSize = true;
            this.CheckBoxEnableDataInLogging.Depth = 0;
            this.CheckBoxEnableDataInLogging.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckBoxEnableDataInLogging.Location = new System.Drawing.Point(6, 390);
            this.CheckBoxEnableDataInLogging.Margin = new System.Windows.Forms.Padding(0);
            this.CheckBoxEnableDataInLogging.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckBoxEnableDataInLogging.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBoxEnableDataInLogging.Name = "CheckBoxEnableDataInLogging";
            this.CheckBoxEnableDataInLogging.Ripple = true;
            this.CheckBoxEnableDataInLogging.Size = new System.Drawing.Size(120, 30);
            this.CheckBoxEnableDataInLogging.TabIndex = 5;
            this.CheckBoxEnableDataInLogging.Text = "enable logging";
            this.CheckBoxEnableDataInLogging.UseVisualStyleBackColor = true;
            // 
            // TabPageDataOut
            // 
            this.TabPageDataOut.Controls.Add(this.CheckBoxEnableDataOutLogging);
            this.TabPageDataOut.Controls.Add(this.TextViewDataOut);
            this.TabPageDataOut.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabPageDataOut.Location = new System.Drawing.Point(4, 29);
            this.TabPageDataOut.Name = "TabPageDataOut";
            this.TabPageDataOut.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageDataOut.Size = new System.Drawing.Size(780, 424);
            this.TabPageDataOut.TabIndex = 2;
            this.TabPageDataOut.Text = "DATA OUT";
            this.TabPageDataOut.UseVisualStyleBackColor = true;
            // 
            // CheckBoxEnableDataOutLogging
            // 
            this.CheckBoxEnableDataOutLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBoxEnableDataOutLogging.AutoSize = true;
            this.CheckBoxEnableDataOutLogging.Depth = 0;
            this.CheckBoxEnableDataOutLogging.Font = new System.Drawing.Font("Roboto", 10F);
            this.CheckBoxEnableDataOutLogging.Location = new System.Drawing.Point(6, 391);
            this.CheckBoxEnableDataOutLogging.Margin = new System.Windows.Forms.Padding(0);
            this.CheckBoxEnableDataOutLogging.MouseLocation = new System.Drawing.Point(-1, -1);
            this.CheckBoxEnableDataOutLogging.MouseState = MaterialSkin.MouseState.HOVER;
            this.CheckBoxEnableDataOutLogging.Name = "CheckBoxEnableDataOutLogging";
            this.CheckBoxEnableDataOutLogging.Ripple = true;
            this.CheckBoxEnableDataOutLogging.Size = new System.Drawing.Size(120, 30);
            this.CheckBoxEnableDataOutLogging.TabIndex = 6;
            this.CheckBoxEnableDataOutLogging.Text = "enable logging";
            this.CheckBoxEnableDataOutLogging.UseVisualStyleBackColor = true;
            // 
            // TextViewDataOut
            // 
            this.TextViewDataOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextViewDataOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.TextViewDataOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextViewDataOut.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextViewDataOut.DetectUrls = false;
            this.TextViewDataOut.EnableAutoDragDrop = true;
            this.TextViewDataOut.Font = new System.Drawing.Font("Roboto", 10F);
            this.TextViewDataOut.ForeColor = System.Drawing.Color.White;
            this.TextViewDataOut.Location = new System.Drawing.Point(6, 6);
            this.TextViewDataOut.MaxLength = 1000;
            this.TextViewDataOut.Name = "TextViewDataOut";
            this.TextViewDataOut.ShortcutsEnabled = false;
            this.TextViewDataOut.Size = new System.Drawing.Size(768, 382);
            this.TextViewDataOut.TabIndex = 1;
            this.TextViewDataOut.Text = "";
            // 
            // TabSelectorLog
            // 
            this.TabSelectorLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TabSelectorLog.BaseTabControl = this.TabControlLog;
            this.TabSelectorLog.Depth = 0;
            this.TabSelectorLog.Font = new System.Drawing.Font("Roboto", 10F);
            this.TabSelectorLog.Location = new System.Drawing.Point(452, 6);
            this.TabSelectorLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.TabSelectorLog.Name = "TabSelectorLog";
            this.TabSelectorLog.Size = new System.Drawing.Size(345, 37);
            this.TabSelectorLog.TabIndex = 6;
            this.TabSelectorLog.Text = "TabSelectorLog";
            // 
            // GraphXZ
            // 
            this.GraphXZ.AbsoluteMaxValue = 100D;
            this.GraphXZ.Font = new System.Drawing.Font("Roboto", 10F);
            this.GraphXZ.GridColor = System.Drawing.Color.Gray;
            this.GraphXZ.Location = new System.Drawing.Point(9, 245);
            this.GraphXZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GraphXZ.Name = "GraphXZ";
            this.GraphXZ.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.GraphXZ.PointSize = 3;
            this.GraphXZ.Size = new System.Drawing.Size(200, 200);
            this.GraphXZ.TabIndex = 0;
            this.GraphXZ.XAxisLabel = "X";
            this.GraphXZ.YAxisLabel = "Z";
            // 
            // GraphYZ
            // 
            this.GraphYZ.AbsoluteMaxValue = 100D;
            this.GraphYZ.Font = new System.Drawing.Font("Roboto", 10F);
            this.GraphYZ.GridColor = System.Drawing.Color.Gray;
            this.GraphYZ.Location = new System.Drawing.Point(245, 22);
            this.GraphYZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GraphYZ.Name = "GraphYZ";
            this.GraphYZ.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.GraphYZ.PointSize = 3;
            this.GraphYZ.Size = new System.Drawing.Size(200, 200);
            this.GraphYZ.TabIndex = 0;
            this.GraphYZ.XAxisLabel = "Z";
            this.GraphYZ.YAxisLabel = "Y";
            // 
            // GraphXY
            // 
            this.GraphXY.AbsoluteMaxValue = 100D;
            this.GraphXY.Font = new System.Drawing.Font("Roboto", 10F);
            this.GraphXY.GridColor = System.Drawing.Color.Gray;
            this.GraphXY.Location = new System.Drawing.Point(9, 22);
            this.GraphXY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GraphXY.Name = "GraphXY";
            this.GraphXY.PointColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.GraphXY.PointSize = 3;
            this.GraphXY.Size = new System.Drawing.Size(200, 200);
            this.GraphXY.TabIndex = 0;
            this.GraphXY.XAxisLabel = "X";
            this.GraphXY.YAxisLabel = "Y";
            // 
            // BtnClearEvents
            // 
            this.BtnClearEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClearEvents.AutoSize = true;
            this.BtnClearEvents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnClearEvents.Depth = 0;
            this.BtnClearEvents.Icon = null;
            this.BtnClearEvents.Location = new System.Drawing.Point(706, 10);
            this.BtnClearEvents.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnClearEvents.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnClearEvents.Name = "BtnClearEvents";
            this.BtnClearEvents.Primary = false;
            this.BtnClearEvents.Size = new System.Drawing.Size(63, 36);
            this.BtnClearEvents.TabIndex = 3;
            this.BtnClearEvents.Text = "clear";
            this.BtnClearEvents.UseVisualStyleBackColor = true;
            this.BtnClearEvents.Click += new System.EventHandler(this.BtnClearEvents_Click);
            // 
            // BtnClearDataIn
            // 
            this.BtnClearDataIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClearDataIn.AutoSize = true;
            this.BtnClearDataIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnClearDataIn.Depth = 0;
            this.BtnClearDataIn.Icon = null;
            this.BtnClearDataIn.Location = new System.Drawing.Point(707, 9);
            this.BtnClearDataIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnClearDataIn.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnClearDataIn.Name = "BtnClearDataIn";
            this.BtnClearDataIn.Primary = false;
            this.BtnClearDataIn.Size = new System.Drawing.Size(63, 36);
            this.BtnClearDataIn.TabIndex = 8;
            this.BtnClearDataIn.Text = "clear";
            this.BtnClearDataIn.UseVisualStyleBackColor = true;
            this.BtnClearDataIn.Click += new System.EventHandler(this.BtnClearDataIn_Click);
            // 
            // BtnClearIMU
            // 
            this.BtnClearIMU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClearIMU.AutoSize = true;
            this.BtnClearIMU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnClearIMU.Depth = 0;
            this.BtnClearIMU.Icon = null;
            this.BtnClearIMU.Location = new System.Drawing.Point(550, 425);
            this.BtnClearIMU.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnClearIMU.Name = "BtnClearIMU";
            this.BtnClearIMU.Primary = true;
            this.BtnClearIMU.Size = new System.Drawing.Size(63, 36);
            this.BtnClearIMU.TabIndex = 1;
            this.BtnClearIMU.Text = "clear";
            this.BtnClearIMU.UseVisualStyleBackColor = true;
            this.BtnClearIMU.Click += new System.EventHandler(this.BtnClearIMU_Click);
            // 
            // BtnStartIMU
            // 
            this.BtnStartIMU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStartIMU.AutoSize = true;
            this.BtnStartIMU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnStartIMU.Depth = 0;
            this.BtnStartIMU.Icon = null;
            this.BtnStartIMU.Location = new System.Drawing.Point(550, 467);
            this.BtnStartIMU.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnStartIMU.Name = "BtnStartIMU";
            this.BtnStartIMU.Primary = true;
            this.BtnStartIMU.Size = new System.Drawing.Size(124, 36);
            this.BtnStartIMU.TabIndex = 2;
            this.BtnStartIMU.Text = "start reading";
            this.BtnStartIMU.UseVisualStyleBackColor = true;
            this.BtnStartIMU.Click += new System.EventHandler(this.BtnStartIMU_Click);
            // 
            // BtnStopIMU
            // 
            this.BtnStopIMU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStopIMU.AutoSize = true;
            this.BtnStopIMU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnStopIMU.Depth = 0;
            this.BtnStopIMU.Icon = null;
            this.BtnStopIMU.Location = new System.Drawing.Point(680, 468);
            this.BtnStopIMU.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnStopIMU.Name = "BtnStopIMU";
            this.BtnStopIMU.Primary = true;
            this.BtnStopIMU.Size = new System.Drawing.Size(117, 36);
            this.BtnStopIMU.TabIndex = 3;
            this.BtnStopIMU.Text = "stop reading";
            this.BtnStopIMU.UseVisualStyleBackColor = true;
            this.BtnStopIMU.Click += new System.EventHandler(this.BtnStopIMU_Click);
            // 
            // TimerRequestIMU
            // 
            this.TimerRequestIMU.Tick += new System.EventHandler(this.TimerRequestIMU_Tick);
            // 
            // CheckBoxScaled
            // 
            this.CheckBoxScaled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxScaled.AutoSize = true;
            this.CheckBoxScaled.Location = new System.Drawing.Point(550, 397);
            this.CheckBoxScaled.Name = "CheckBoxScaled";
            this.CheckBoxScaled.Size = new System.Drawing.Size(74, 22);
            this.CheckBoxScaled.TabIndex = 4;
            this.CheckBoxScaled.Text = "scaled?";
            this.CheckBoxScaled.UseVisualStyleBackColor = true;
            this.CheckBoxScaled.CheckedChanged += new System.EventHandler(this.CheckBoxScaled_CheckedChanged);
            // 
            // BtnClearScale
            // 
            this.BtnClearScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClearScale.AutoSize = true;
            this.BtnClearScale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnClearScale.Depth = 0;
            this.BtnClearScale.Icon = null;
            this.BtnClearScale.Location = new System.Drawing.Point(619, 425);
            this.BtnClearScale.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnClearScale.Name = "BtnClearScale";
            this.BtnClearScale.Primary = true;
            this.BtnClearScale.Size = new System.Drawing.Size(108, 36);
            this.BtnClearScale.TabIndex = 5;
            this.BtnClearScale.Text = "clear scale";
            this.BtnClearScale.UseVisualStyleBackColor = true;
            this.BtnClearScale.Click += new System.EventHandler(this.BtnClearScale_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "heading:";
            // 
            // LblHeading
            // 
            this.LblHeading.AutoSize = true;
            this.LblHeading.Location = new System.Drawing.Point(616, 354);
            this.LblHeading.Name = "LblHeading";
            this.LblHeading.Size = new System.Drawing.Size(16, 18);
            this.LblHeading.TabIndex = 7;
            this.LblHeading.Text = "0";
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
            this.Sizable = false;
            this.Text = "BBR Calibrator";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageHome.ResumeLayout(false);
            this.TabPageHome.PerformLayout();
            this.TabPageIMU.ResumeLayout(false);
            this.TabPageIMU.PerformLayout();
            this.TabPageLog.ResumeLayout(false);
            this.TabControlLog.ResumeLayout(false);
            this.TabPageLogEvents.ResumeLayout(false);
            this.TabPageLogEvents.PerformLayout();
            this.TabPageLogData.ResumeLayout(false);
            this.TabPageLogData.PerformLayout();
            this.TabPageDataOut.ResumeLayout(false);
            this.TabPageDataOut.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        public System.Windows.Forms.RichTextBox TextViewData;
        public MaterialSkin.Controls.MaterialTabSelector TabSelectorMain;
        public MaterialSkin.Controls.MaterialTabControl TabControlMain;
        public System.Windows.Forms.TabPage TabPageHome;
        public System.Windows.Forms.TabPage TabPageLog;
        public MaterialSkin.Controls.MaterialCheckBox CheckBoxEnableDataInLogging;
        public MaterialSkin.Controls.MaterialTabControl TabControlLog;
        public System.Windows.Forms.TabPage TabPageLogData;
        public System.Windows.Forms.TabPage TabPageLogEvents;
        public MaterialSkin.Controls.MaterialTabSelector TabSelectorLog;
        public System.Windows.Forms.RichTextBox TextViewEvents;
        public System.Windows.Forms.TabPage TabPageIMU;
        public System.Windows.Forms.TabPage TabPageMotors;
        public System.Windows.Forms.TabPage TabPageRobot;
        public GraphicHelpers.Graph2D GraphXZ;
        public GraphicHelpers.Graph2D GraphYZ;
        public GraphicHelpers.Graph2D GraphXY;
        private System.Windows.Forms.TabPage TabPageDataOut;
        public MaterialSkin.Controls.MaterialCheckBox CheckBoxEnableDataOutLogging;
        public System.Windows.Forms.RichTextBox TextViewDataOut;
        private MaterialSkin.Controls.MaterialRaisedButton BtnConnect;
        private MaterialSkin.Controls.MaterialRaisedButton BtnRequest;
        private MaterialSkin.Controls.MaterialFlatButton BtnClearEvents;
        private MaterialSkin.Controls.MaterialFlatButton BtnClearDataIn;
        private MaterialSkin.Controls.MaterialRaisedButton BtnStopIMU;
        private MaterialSkin.Controls.MaterialRaisedButton BtnStartIMU;
        private MaterialSkin.Controls.MaterialRaisedButton BtnClearIMU;
        private System.Windows.Forms.Timer TimerRequestIMU;
        private System.Windows.Forms.CheckBox CheckBoxScaled;
        private MaterialSkin.Controls.MaterialRaisedButton BtnClearScale;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label LblHeading;
    }
}

