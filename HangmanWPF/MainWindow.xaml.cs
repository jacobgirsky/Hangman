using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangmanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int EASY_ATTEMPTS = 11;
        const int MEDIUM_ATTEMPTS = 9;
        const int HARD_ATTEMPTS = 6;

        private int numAttempts;

        public MainWindow()
        {
            InitializeComponent();
            numAttempts = 0;
        }

        private void easyButton_Click(object sender, RoutedEventArgs e)
        {
            
            ChangeButtonColorBlack(sender);
            ChangeButtonColorWhite(mediumButton);
            ChangeButtonColorWhite(hardButton);
            numAttempts = EASY_ATTEMPTS;
        }

        private void mediumButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonColorBlack(sender);
            ChangeButtonColorWhite(easyButton);
            ChangeButtonColorWhite(hardButton);
            numAttempts = MEDIUM_ATTEMPTS;
        }

        private void hardButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeButtonColorBlack(sender);
            ChangeButtonColorWhite(easyButton);
            ChangeButtonColorWhite(mediumButton);
            numAttempts = HARD_ATTEMPTS;

        }

        private void ChangeButtonColorBlack(object sender)
        {
            Button btn = sender as Button;
            btn.Background = Brushes.Black;
            btn.Foreground = Brushes.White;
        }

        private void ChangeButtonColorWhite(object sender)
        {
            Button btn = sender as Button;
            btn.Background = Brushes.White;
            btn.Foreground = Brushes.Black;
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (numAttempts > 0)
            {
                Game g = new Game(numAttempts);
                this.Close();
                g.Show();
            }
            else
            {
                MessageBox.Show("Please select a difficutly level!");
            }
        }
    }
}
