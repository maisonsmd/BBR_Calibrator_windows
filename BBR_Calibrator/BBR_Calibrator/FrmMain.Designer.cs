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
			this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
			this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
			this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
			this.graph2D1 = new BBR_Calibrator.GraphicHelpers.Graph2D();
			this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
			this.materialTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// materialTabControl1
			// 
			this.materialTabControl1.Controls.Add(this.tabPage1);
			this.materialTabControl1.Controls.Add(this.tabPage2);
			this.materialTabControl1.Depth = 0;
			this.materialTabControl1.Location = new System.Drawing.Point(12, 110);
			this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialTabControl1.Name = "materialTabControl1";
			this.materialTabControl1.SelectedIndex = 0;
			this.materialTabControl1.Size = new System.Drawing.Size(820, 445);
			this.materialTabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.White;
			this.tabPage1.Controls.Add(this.materialFlatButton2);
			this.tabPage1.Controls.Add(this.materialFlatButton1);
			this.tabPage1.Controls.Add(this.materialRaisedButton1);
			this.tabPage1.Controls.Add(this.graph2D1);
			this.tabPage1.Controls.Add(this.materialRadioButton1);
			this.tabPage1.Location = new System.Drawing.Point(4, 24);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(812, 417);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// materialRaisedButton1
			// 
			this.materialRaisedButton1.AutoSize = true;
			this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialRaisedButton1.Depth = 0;
			this.materialRaisedButton1.Icon = null;
			this.materialRaisedButton1.Location = new System.Drawing.Point(417, 121);
			this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialRaisedButton1.Name = "materialRaisedButton1";
			this.materialRaisedButton1.Primary = true;
			this.materialRaisedButton1.Size = new System.Drawing.Size(195, 36);
			this.materialRaisedButton1.TabIndex = 4;
			this.materialRaisedButton1.Text = "materialRaisedButton1";
			this.materialRaisedButton1.UseVisualStyleBackColor = true;
			this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
			// 
			// materialRadioButton1
			// 
			this.materialRadioButton1.AutoSize = true;
			this.materialRadioButton1.Depth = 0;
			this.materialRadioButton1.Font = new System.Drawing.Font("Roboto", 10F);
			this.materialRadioButton1.Location = new System.Drawing.Point(3, 3);
			this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
			this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
			this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialRadioButton1.Name = "materialRadioButton1";
			this.materialRadioButton1.Ripple = true;
			this.materialRadioButton1.Size = new System.Drawing.Size(163, 30);
			this.materialRadioButton1.TabIndex = 2;
			this.materialRadioButton1.TabStop = true;
			this.materialRadioButton1.Text = "materialRadioButton1";
			this.materialRadioButton1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 24);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(812, 417);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// materialTabSelector1
			// 
			this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
			this.materialTabSelector1.Depth = 0;
			this.materialTabSelector1.Location = new System.Drawing.Point(-1, 64);
			this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialTabSelector1.Name = "materialTabSelector1";
			this.materialTabSelector1.Size = new System.Drawing.Size(845, 40);
			this.materialTabSelector1.TabIndex = 2;
			this.materialTabSelector1.Text = "materialTabSelector1";
			// 
			// materialFlatButton1
			// 
			this.materialFlatButton1.AutoSize = true;
			this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButton1.Depth = 0;
			this.materialFlatButton1.Icon = null;
			this.materialFlatButton1.Location = new System.Drawing.Point(448, 246);
			this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButton1.Name = "materialFlatButton1";
			this.materialFlatButton1.Primary = false;
			this.materialFlatButton1.Size = new System.Drawing.Size(67, 36);
			this.materialFlatButton1.TabIndex = 5;
			this.materialFlatButton1.Text = "THEME";
			this.materialFlatButton1.UseVisualStyleBackColor = true;
			this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
			// 
			// graph2D1
			// 
			this.graph2D1.AbsoluteMaxValue = 1000D;
			this.graph2D1.Location = new System.Drawing.Point(40, 56);
			this.graph2D1.Name = "graph2D1";
			this.graph2D1.PointSize = 10;
			this.graph2D1.Size = new System.Drawing.Size(236, 236);
			this.graph2D1.TabIndex = 3;
			// 
			// materialFlatButton2
			// 
			this.materialFlatButton2.AutoSize = true;
			this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.materialFlatButton2.Depth = 0;
			this.materialFlatButton2.Icon = null;
			this.materialFlatButton2.Location = new System.Drawing.Point(523, 246);
			this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
			this.materialFlatButton2.Name = "materialFlatButton2";
			this.materialFlatButton2.Primary = false;
			this.materialFlatButton2.Size = new System.Drawing.Size(123, 36);
			this.materialFlatButton2.TabIndex = 6;
			this.materialFlatButton2.Text = "Color scheme";
			this.materialFlatButton2.UseVisualStyleBackColor = true;
			this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(844, 567);
			this.Controls.Add(this.materialTabSelector1);
			this.Controls.Add(this.materialTabControl1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FrmMain";
			this.Text = "BBR Calibrator";
			this.materialTabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
		private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
		private GraphicHelpers.Graph2D graph2D1;
		private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
		private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
		private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
	}
}

