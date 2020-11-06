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

namespace LCRGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IGameManager gameManager;

        private IDiceManager diceManager;

        private int numberOfPlayers;

        private int numberOfGamesToSimulate;

        private StringBuilder Log;

        public MainWindow()
        {
            Log = new StringBuilder(1000);

            numberOfPlayers = (Application.Current as App).NumberOfPlayers;
            numberOfGamesToSimulate = (Application.Current as App).NumberOfGamesToSimulate;

            gameManager = new GameManager(numberOfPlayers);
            gameManager.OpenGame();

            InitializeComponent();

            RefreshBindings();
        }

        private void SimulateButton_Click(object sender, RoutedEventArgs e)
        {
            Log.Clear();
            int turnsCounter;
            Dictionary<int, int> GamesByTurns = new Dictionary<int, int>();

            for (int i = 1; i <= numberOfGamesToSimulate; i++)
            {
                Log.AppendLine(string.Format(Constants.STARTING_GAME_MSG, i));

                turnsCounter = 1;
                gameManager = new GameManager(numberOfPlayers);
                gameManager.OpenGame();

                do
                {
                    diceManager = new DiceManager(gameManager, Log);
                    diceManager.RollDice();
                    turnsCounter++;

                    RefreshBindings();
                } while (gameManager.Winner == null);

                GamesByTurns.Add(i, turnsCounter);
                Log.AppendLine(string.Format(Constants.TURNS_COUNT_MSG, turnsCounter));
            }

            int shortestLengthGame = GamesByTurns.Min(g => g.Value);
            int longestLengthGame = GamesByTurns.Max(g => g.Value);
            double averageLengthGame = Math.Ceiling(GamesByTurns.Average(g => g.Value));

            Log.AppendLine(string.Format(Constants.SHORTEST_LENGTH_GAME_MSG, shortestLengthGame));
            Log.AppendLine(string.Format(Constants.LONGEST_LENGTH_GAME_MSG, longestLengthGame));
            Log.AppendLine(string.Format(Constants.AVERAGE_LENGTH_GAME_MSG, averageLengthGame));

            RefreshBindings();
        }

        private void RefreshBindings()
        {
            PlayersData.ItemsSource = gameManager.ListOfPlayers;
            LogBox.Text = Log.ToString();
        }
    }
}
