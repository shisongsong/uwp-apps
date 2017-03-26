using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace blank_app
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public Library Library = new Library();

        //private void New_Click(object sender, RoutedEventArgs e)
        //{
        //    Email.Text = string.Empty;
        //    Website.Text = string.Empty;
        //    Telephone.Text = string.Empty;
        //}

        //private void Open_Click(object sender, RoutedEventArgs e)
        //{
        //    Email.Text = Library.LoadSetting("Email");
        //    Website.Text = Library.LoadSetting("Website");
        //    Telephone.Text = Library.LoadSetting("Telephone");
        //}

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    Library.SaveSetting("Email", Email.Text);
        //    Library.SaveSetting("Website", Website.Text);
        //    Library.SaveSetting("Telephone", Telephone.Text);
        //}

        private void Pitch_Click(object sender, RoutedEventArgs e)
        {
            Library.Rotate("X", ref Display);
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            Library.Rotate("Y", ref Display);
        }

        private void Yaw_Click(object sender, RoutedEventArgs e)
        {
            Library.Rotate("Z", ref Display);
        }

        private void Go_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                Display.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(Value.Text));
            }
        }
    }
}
