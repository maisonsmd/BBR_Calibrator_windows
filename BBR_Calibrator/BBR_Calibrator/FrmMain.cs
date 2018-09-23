using System;
using System.Threading;

using GeneralAdapters;

using MaterialSkin;
using MaterialSkin.Controls;

namespace BBR_Calibrator {

    public partial class FrmMain : MaterialForm {
        private readonly MaterialSkinManager materialSkinManager;
        private SerialComunication serialComunication;

        private delegate void SetLableDelegate( string text );
        SetLableDelegate SleepTestHandler;
        SetLableDelegate SetLableHandler;


        public FrmMain ( ) {
            InitializeComponent();

            SleepTestHandler = new SetLableDelegate(SleepTest);
            SetLableHandler = new SetLableDelegate(SetLabel);


            serialComunication = SerialComunication.Instance;
            serialComunication.DataReceived += OnDataReceived;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void flipLightTheme ( object sender, EventArgs e ) {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }

        private void OnDataReceived ( string data ) {
            //IAsyncResult result = BeginInvoke(
            //    (ThreadStart)delegate ( ) {
            //        Thread.Sleep(500);
            //        setText(data);
            //    });
            SleepTestHandler?.BeginInvoke(data, SetLableResult, null);
        }

        private void SetLableResult(IAsyncResult result ) {

        }
        private void SleepTest ( string data ) {
            //Console.WriteLine(data);
            //materialLabel1.Text = data;
            Thread.Sleep(500);
            this.Invoke(SetLableHandler, data);
        }
        void SetLabel(string text ) {

            //materialLabel1.Text = text;
            IAsyncResult result = BeginInvoke(
                (ThreadStart)delegate ( ) {
                    materialLabel1.Text = text;
                });
        }

        private int colorSchemeIndex;

        private void changeTheme ( object sender, EventArgs e ) {
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

        private void materialFlatButton1_Click ( object sender, EventArgs e ) {
            SetLableHandler?.Invoke("hello");
        }
    }
}