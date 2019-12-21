using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace HangmanWPF
{

    public partial class Game : Window
    {

        private int numAttemps;
        private int numberOfTries;
        private List<string> dashes;
        private string secretWord;
        private Draw draw;
       
        public Game(int numAttemps)
        {
            InitializeComponent();
            this.numAttemps = numAttemps;
            PlayGame();

        }

        private void PlayGame()
        {
            secretWord = GetRandomWord("words.txt");
            MessageBox.Show(secretWord);
            dashes = new List<string>();
            draw = new Draw(hangmanCanvas);
            DrawPost(); 
            CreateDashes(secretWord, dashes);
            DisplayDashes();
            UpdateAttemptTextbox();
            numberOfTries = numAttemps;
        }

        private void UpdateAttemptTextbox()
        {
            numberAttempsTextBox.Text = numAttemps.ToString();
        }

        private List<string> GetWord()
        {
            List<string> temp = new List<string>();
            foreach (var item in dashes)
            {
                temp.Add(item);
            }

            for (int i = 0; i < temp.Count; i++)
            {
                temp[i] = temp[i].Replace(" ", "");
            }

            return temp;
        }

        private string GetWordFromList(List<string> word)
        {
            string temp = "";
            foreach (var item in word)
            {
                temp += item;
            }

            return temp;
        }

        private void DisplayDashes()
        {
            string temp = "";
            foreach (var c in dashes)
            {
                temp += c;
            }

            secretWordTextBox.FontSize = 30;
            secretWordTextBox.Text = temp;
        }

        private void CheckForWin()
        {
            bool flag = true;
            List<string> wordList = GetWord();
            string word = GetWordFromList(wordList);
            if (word.Equals(secretWord)) {
                DisplayMessageBox(flag);
            }
        }
        

        private void DrawPost()
        {
            draw.DrawLine(130, 218, 130, 5, 10);
            draw.DrawLine(135, 5, 65, 5, 10);
            draw.DrawLine(60, 50, 60, 0, 10);
        }

        private static string GetRandomWord(string fileName)
        {
            string[] allLines = File.ReadAllLines(fileName);
            Random rnd1 = new Random();
            string word = allLines[rnd1.Next(allLines.Length)];
            return word;
        }

        private void CreateDashes(string word, List<string> dashes)
        {
            for (int i = 0; i < word.Length; i++)
            {
                dashes.Add("__ ");
            }
        }
 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string letter = btn.Content.ToString().ToLower();
            if (secretWord.Contains(letter))
            {
                btn.IsEnabled = false;
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == Convert.ToChar(letter))
                    {
                        dashes[i] = dashes[i].Replace("__ ", letter + "  ");
                    }
                }
                DisplayDashes();
                CheckForWin();        
            }
            else
            {
                btn.IsHitTestVisible = false;
                btn.Background = Brushes.Red;
                numAttemps--;
                UpdateAttemptTextbox();
                if (numAttemps > 0 ) // fix bug where it wont finish drawing mouth
                {
                    DrawMan();
                }
                else
                {
                    DisplayMessageBox(false);
                }
            }
        }

        private void DisplayMessageBox(bool flag)
        {
            MessageBoxResult result = MessageBoxResult.No;
            if (flag)
                result = MessageBox.Show("You won!! Want to play again?", "Winner!!!", MessageBoxButton.YesNo);
            else
                result = result = MessageBox.Show("You lost! The word was " + secretWord + ". Want to play again?", "Loser", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    MainWindow main = new MainWindow();
                    this.Close();
                    main.Show();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Thanks for playing!");
                    this.Close();
                    break;
            }
        }

        private void DrawMan()
        {
            if (numAttemps == numberOfTries - 1)
            {
                draw.DrawHead(32, 32, 49, 72);
            }
            if (numAttemps == numberOfTries - 2)
            {
                draw.DrawBody(60, 130, 60, 80, 2); 

            }
            if (numAttemps == numberOfTries - 3)
            {
                draw.DrawLeftArm(40, 105, 60, 80, 2);

            }
            if (numAttemps == numberOfTries - 4)
            {
                draw.DrawRightArm(80, 105, 60, 80, 2); 

            }
            if (numAttemps == numberOfTries - 5)
            {
                draw.DrawLeftLeg(40, 150, 60, 130, 2); 

            }
            if (numAttemps == numberOfTries - 6)
            {
                draw.DrawRightLeg(80, 150, 60, 130, 2); 
            }

            if (numAttemps == numberOfTries - 7)
            {
                draw.DrawLeftEye(3, 3, 59, 91);
            }

            if (numAttemps == numberOfTries - 8)
            {
                draw.DrawRightEye(3, 3, 59, 80);
            }

            if (numAttemps == numberOfTries - 9)
            {
                draw.DrawMouth(54, 70, 68, 70, 2);
            }
        }
    }
}
