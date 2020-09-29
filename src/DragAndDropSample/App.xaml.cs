using System;
using DragAndDropSample.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragAndDropSample
{
    public partial class App : Application
    {

        public App ()
        {
            Device.SetFlags(new string[] { "DragAndDrop_Experimental" });

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
