using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;
            char[] inputChars = inputText.ToCharArray();
            Array.Reverse(inputChars);
            string reversedText = new string(inputChars);
            OutputTextBox.Text = reversedText;
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            LastKeyPressedLabel.Content = $"Last Key Pressed: {e.Key.ToString()}";
            LastKeyPressedLabel.Visibility = Visibility.Visible;
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs f)
        {
            var timer = (DispatcherTimer)sender;
            timer.Stop();
            LastKeyPressedLabel.Visibility = Visibility.Hidden;
            LastKeyPressedLabel.Content = string.Empty;
        }
    }

}
