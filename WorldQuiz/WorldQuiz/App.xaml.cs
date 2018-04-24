using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WorldQuiz
{
	public partial class App : Application
	{
        public static string _dB_PATH = string.Empty;
		public App ()
		{
			InitializeComponent();

			MainPage = new WorldQuiz.MainPage();
		}
        public App(string dBPath)
        {
            InitializeComponent();

            _dB_PATH = dBPath;
            MainPage = new WorldQuiz.MainPage();
        }
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
