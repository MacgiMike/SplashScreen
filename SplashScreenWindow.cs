using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections.Generic;


namespace SplashScreen
{
    public partial class SplashScreenWindow : Form
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
        }
        public Screen _SetToScreen { get; set; }
        private Timer _Fade;
        private RGBInfo _RGBBackgroud;
        private RGBInfo _RGBText;
        private SplashScreenSettings _SplashScreenSettings;

        private void SplashScreenWindow_Load(object sender, EventArgs e)
        {
            //Sets the text in the window (if someone would see it by mistake)
            this.Text = "SplashScreen - ver. " + Application.ProductVersion;
            //Let's setup our registry control object so that we can get info from the registry
            RegistryControl RegCtrl = new RegistryControl();

            //Let's see if we are the first instance if the application or if we have been launched from another instance
            if (RegCtrl.AmITheFirstInstance() == true)
            {
                //Ok, so we are teh first instance, let enter that in to the registry if wee need to launche more instances
                RegCtrl.SetFirstInstance();
                //As we are the first instance we need to set up ourself and the other instances
                StartInstances();
                //Now that we are upp and running we can remove the flag from the registry.
                RegCtrl.RemoveFirstInstance();
            }
        }
        private void StartInstances()
        {
            //Call the function that checks it the application should run or not (if not, the application will exit.
            CheckIfSplachScreenShouldRun();
            bool FirstRun = true;
            //Loops thru all the screens att starts a splash screen for each
            foreach (Screen screen in Screen.AllScreens)
            {
                if (FirstRun == true)
                {
                    //If this is the firs instance we need to set it up instade of creating a new instance
                    _SetToScreen = screen;
                    MoveWindowToCorrectScreen();

                    SetupFadeTimer();

                    SetupTheScreen();
                    FirstRun = false;
                }
                else
                {
                    //As we have more than one screenwe need to create an instance for that screen as well
                    SplashScreenWindow splash = new SplashScreenWindow();
                    splash._SetToScreen = screen;
                    splash.MoveWindowToCorrectScreen();
                    splash.SetupFadeTimer();
                    splash.SetupTheScreen();
                    splash.Show();
                }

            }
        }
        private void CheckIfSplachScreenShouldRun()
        {
            //Gets the path of the exe  
            string ExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Checks that the end of the string to see if last char is a \ if not it adds it
            if (ExePath.Substring(ExePath.Length - 1) != @"\")
            {
                ExePath = ExePath + @"\";
            }
            //Compleats the path to the check-file
            string RunFile = ExePath + "RunSplashScreen.txt";
            //Checks if the file exists end exits if not
            if (File.Exists(RunFile) == false)
            {
                Application.Exit();
            }
        }
        private void MoveWindowToCorrectScreen()
        {
            this.Location = _SetToScreen.WorkingArea.Location;
            WindowState = FormWindowState.Maximized;
            this.BringToFront();
            this.Focus();
        }
        private void SetupFadeTimer()
        {
            _Fade = new Timer();
            _Fade.Interval = 25;
            _Fade.Tick += new EventHandler(_Fade_Tick);
        }
        private void SetupTheScreen()
        {
            _RGBText = new RGBInfo();
            _RGBBackgroud = new RGBInfo();
            _SplashScreenSettings = new SplashScreenSettings();
            _SplashScreenSettings.TextBlock1 = new Queue<string>();
            _SplashScreenSettings.TextBlock2 = new Queue<string>();

            _RGBText.R = 255;
            _RGBText.G = 255;
            _RGBText.B = 255;

            _RGBBackgroud.R = 5;
            _RGBBackgroud.G = 65;
            _RGBBackgroud.B = 108;
            
            string ExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (ExePath.Substring(ExePath.Length - 1) != @"\")
            {
                ExePath = ExePath + @"\";
            }
            string TextFile = ExePath + "Texts.txt";
            if (File.Exists(TextFile) == false)
            {
                Application.Exit();
            }
            else
            {
                LoadTexts(TextFile);
            }

            lblTextBlock1.Text = GetNextText(1);
            lblTextBlock2.Text = GetNextText(2);

            this.BackColor = Color.FromArgb(_RGBBackgroud.R, _RGBBackgroud.G, _RGBBackgroud.B);
            lblTextBlock1.ForeColor = Color.FromArgb(_RGBText.R, _RGBText.G, _RGBText.B);
            lblTextBlock2.ForeColor = Color.FromArgb(_RGBText.R, _RGBText.G, _RGBText.B);

            _SplashScreenSettings.IsFadingToDark = true;
            _Fade.Enabled = true;


        }
        private void LoadTexts(string TextFile)
        {
            List<string> Texts = new List<string>();
            StreamReader streamReader = new StreamReader(TextFile);
            while (!streamReader.EndOfStream)
            {
                Texts.Add(streamReader.ReadLine());
            }
            foreach (string Text in Texts)
            {
                if (Text.Substring(0, 2) == "1:")
                {
                    _SplashScreenSettings.TextBlock1.Enqueue(Text.Substring(2));
                }
                if (Text.Substring(0, 2) == "2:")
                {
                    _SplashScreenSettings.TextBlock2.Enqueue(Text.Substring(2));
                }
            }
        }
        private void _Fade_Tick(object sender, EventArgs e)
        {
            int Index = 2;
            this.TopMost = true;
            this.Activate();
            if (_SplashScreenSettings.IsFadingToDark)
            {
                _RGBText.R = _RGBText.R - Index;
                _RGBText.G = _RGBText.G - Index;
                _RGBText.B = _RGBText.B - Index;
                lblTextBlock1.ForeColor = Color.FromArgb(_RGBText.R, _RGBText.G, _RGBText.B);
                lblTextBlock2.ForeColor = Color.FromArgb(_RGBText.R, _RGBText.G, _RGBText.B);
                if (_RGBText.R < 51)
                {
                    _SplashScreenSettings.IsFadingToDark = false;
                    lblTextBlock1.Text = GetNextText(1);
                    lblTextBlock2.Text = GetNextText(2);
                }
            }
            else
            {
                _RGBText.R = _RGBText.R + Index;
                _RGBText.G = _RGBText.G + Index;
                _RGBText.B = _RGBText.B + Index;
                lblTextBlock1.ForeColor = Color.FromArgb(_RGBText.R, _RGBText.G, _RGBText.B);
                lblTextBlock2.ForeColor = Color.FromArgb(_RGBText.R, _RGBText.G, _RGBText.B);
                if (_RGBText.R > 255 - Index)
                {
                    _SplashScreenSettings.IsFadingToDark = true;
                }
            }
        }
        private string GetNextText(int Block)
        {
            string TextToReturn = string.Empty;
            if (Block == 1)
            {
                TextToReturn = _SplashScreenSettings.TextBlock1.Dequeue();
                _SplashScreenSettings.TextBlock1.Enqueue(TextToReturn);
            }
            if (Block == 2)
            {
                TextToReturn = _SplashScreenSettings.TextBlock2.Dequeue();
                _SplashScreenSettings.TextBlock2.Enqueue(TextToReturn);
            }
            return TextToReturn;
        }
        private void Splash_DoubleClick(object sender, EventArgs e)
        {
            int MouselocationX = Cursor.Position.X - this.Location.X;
            int MouselocationY = Cursor.Position.Y - this.Location.Y;
            if (MouselocationX < 100 && MouselocationY < 100)
            {
                Application.Exit();
            }
        }
        private void Splash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q && e.Modifiers == Keys.Alt)
            {
                Application.Exit();
            }
        }
    }
}
