using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragAndDropSample.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void DropGestureRecognizer_DragOver(System.Object sender, Xamarin.Forms.DragEventArgs e)
        {
            StackLayout sl = ((StackLayout)(sender as DropGestureRecognizer).Parent);
            sl.BackgroundColor = Color.Green;
        }

        void DropGestureRecognizer_DragLeave(System.Object sender, Xamarin.Forms.DragEventArgs e)
        {
            StackLayout sl = ((StackLayout)(sender as DropGestureRecognizer).Parent);
            sl.BackgroundColor = Color.LightGray;
        }

        void DropGestureRecognizer_Drop(System.Object sender, Xamarin.Forms.DropEventArgs e)
        {
            StackLayout sl = ((StackLayout)(sender as DropGestureRecognizer).Parent);
            sl.BackgroundColor = Color.LightGray;

            // add new box to the stack
            var btn = new Button();
            btn.BackgroundColor = (Color)e.Data.Properties["Color"];
            sl.Children.Add(btn);

            btn.Clicked += ButtonRemove_Clicked;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            var i = Int32.Parse(btn.Text);
            btn.Text = (++i).ToString();
        }

        void DragGestureRecognizer_DragStarting(System.Object sender, Xamarin.Forms.DragStartingEventArgs e)
        {
            Debug.WriteLine("started drag");
            Button btn = (sender as Element).Parent as Button;
            e.Data.Properties.Add("Color",btn.BackgroundColor);
        }

        void ButtonRemove_Clicked(System.Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            StackLayout sl = btn.Parent as StackLayout;
            sl.Children.Remove(btn);
        }
    }
}
