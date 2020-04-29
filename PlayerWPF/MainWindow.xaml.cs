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
using PlayerWPF.ServiceReference1;
using System.ServiceModel;

namespace PlayerWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class CallbackHandler : ITicTacToeCallback
        {
            List<Button> buttons;
            public CallbackHandler(List<Button> b)
            {
                buttons = new List<Button>();
                buttons = b;
            }
            public bool Action([MessageParameter(Name = "action")] bool action1)
            {
                if (!action1)
                {
                    foreach (var item in buttons)
                    {
                        item.IsEnabled = false;
                    }
                }
                else
                {
                    foreach (var item in buttons)
                    {
                        item.IsEnabled = true;
                    }
                }
                return action1;
            }

            public int GetIDSession(int idsessionCallback)
            {
                idSession = idsessionCallback;
                return idsessionCallback;
            }

            public int Move(Field field, char symbol)
            {
                foreach (var item in buttons)
                {
                    if (item.Name.ToString() == field.ToString())
                    {
                        item.DataContext = symbol;

                        item.IsEnabled = false;
                    }
                }
                return 1;
            }

            public string YouWinner(bool result)
            {
                if (result)
                {
                    MessageBox.Show("You WIN");
                    return "You WIN";
                }
                else
                {
                    MessageBox.Show("You LOSE");
                    return "You LOSE";
                }
            }
        }

        TicTacToeClient player;
        static int idSession;
        public MainWindow()
        {
            InitializeComponent();
            headerPanel.Visibility = Visibility.Visible;
            startGamePanel.Visibility = Visibility.Collapsed;
            createUserPanel.Visibility = Visibility.Collapsed;
            player = new TicTacToeClient(new InstanceContext(new CallbackHandler(new List<Button> { A1, A2, A3, B1, B2, B3, C1, C2, C3 })));

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var id = await player.CreateUserAsync(tbName.Text);
            idPlayer.DataContext = id.ToString();

            startGamePanel.Visibility = Visibility.Visible;
            createUserPanel.Visibility = Visibility.Collapsed;
            headerPanel.Visibility = Visibility.Collapsed;
        }

        private async void A1_Click(object sender, RoutedEventArgs e)
        {
            if (A1.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.A1, tbSym.Text[0]);


        }

        private async void A2_Click(object sender, RoutedEventArgs e)
        {

            if (A2.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.A2, tbSym.Text[0]);

        }

        private async void A3_Click(object sender, RoutedEventArgs e)
        {
            if (A3.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.A3, tbSym.Text[0]);

        }

        private async void B1_Click(object sender, RoutedEventArgs e)
        {
            if (B1.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.B1, tbSym.Text[0]);

        }

        private async void B2_Click(object sender, RoutedEventArgs e)
        {
            if (B2.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.B2, tbSym.Text[0]);

        }

        private async void B3_Click(object sender, RoutedEventArgs e)
        {
            if (B3.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.B3, tbSym.Text[0]);

        }

        private async void C1_Click(object sender, RoutedEventArgs e)
        {
            if (C1.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.C1, tbSym.Text[0]);

        }

        private async void C2_Click(object sender, RoutedEventArgs e)
        {
            if (C2.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.C2, tbSym.Text[0]);

        }

        private async void C3_Click(object sender, RoutedEventArgs e)
        {
            if (C3.Content == null)
                await player.MakeMoveAsync(idSession, Int32.Parse(idPlayer.Content.ToString()), Field.C3, tbSym.Text[0]);

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                if (idPlayer.Content!=null&&p2.Text!="")
                    await player.StartGameAsync(Int32.Parse(idPlayer.Content.ToString()), Int32.Parse(p2.Text));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            startGamePanel.Visibility = Visibility.Collapsed;
            createUserPanel.Visibility = Visibility.Visible;
            headerPanel.Visibility = Visibility.Collapsed;
        }

        private void LoginUser_Click(object sender, RoutedEventArgs e)
        {
           
                startGamePanel.Visibility = Visibility.Visible;
                createUserPanel.Visibility = Visibility.Collapsed;
                headerPanel.Visibility = Visibility.Collapsed;
              
        }
    }
}
