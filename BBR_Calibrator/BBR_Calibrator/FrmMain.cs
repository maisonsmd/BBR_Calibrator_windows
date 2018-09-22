using System;

using MaterialSkin;
using MaterialSkin.Controls;

namespace BBR_Calibrator {

	public partial class FrmMain : MaterialForm {
		private readonly MaterialSkinManager materialSkinManager;

		public FrmMain ( ) {
			InitializeComponent();
			materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
			materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
		}

		private void materialRaisedButton1_Click ( object sender, EventArgs e ) {
			Random random = new Random();
			double x = (random.NextDouble() - 0.5) * 1000.0;
			double y = (random.NextDouble() - 0.5) * 1000.0;
			graph2D1.AddPoint(x, y);
		}

		private void materialFlatButton1_Click ( object sender, EventArgs e ) {
			materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
		}

		private int colorSchemeIndex;

		private void materialFlatButton2_Click ( object sender, EventArgs e ) {
			colorSchemeIndex++;
			if (colorSchemeIndex > 2)
				colorSchemeIndex = 0;

			//These are just example color schemes
			switch (colorSchemeIndex) {
				case 0:
					materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
					break;

				case 1:
					materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
					break;

				case 2:
					materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
					break;
			}
		}
	}
}