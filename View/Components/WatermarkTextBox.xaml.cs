using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Romfix.View.Components
{
    public sealed partial class WatermarkTextBox : UserControl
    {

        public WatermarkTextBox()
        {
            this.InitializeComponent();
        }




        public string Text
        {
            get { return this.tbWaterMark.Text; }
            set { this.tbWaterMark.Text = value; }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(""));

        


        public string WatermarkText
        {
            get { return (string)GetValue(WatermarkTextProperty); }
            set { SetValue(WatermarkTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WatermarkText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata("Enter Text"));



        public SolidColorBrush WatermarkForeground
        {
            get { return (SolidColorBrush)GetValue(WatermarkForegroundProperty); }
            set { SetValue(WatermarkForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WatermarkForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkForegroundProperty =
            DependencyProperty.Register("WatermarkForeground", typeof(SolidColorBrush), typeof(WatermarkTextBox), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));



        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == WatermarkText)
            {
                tb.Text = "";
                tb.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Foreground = WatermarkForeground;
                tb.Text = WatermarkText;
            }

        }
    }
}
