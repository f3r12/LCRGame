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
        public MainWindow()
        {
            int turnsCounter;
            Dictionary<int, int> GamesByTurns = new Dictionary<int, int>();

            int numberOfPlayers = (Application.Current as App).NumberOfPlayers;
            int numberOfGamesToSimulate = (Application.Current as App).NumberOfGamesToSimulate;

            IGameManager gameManager;
            IDiceManager diceManager;

            for (int i = 1; i <= numberOfGamesToSimulate; i++)
            {
                turnsCounter = 0;
                gameManager = new GameManager(numberOfPlayers);
                gameManager.OpenGame();

                do
                {
                    diceManager = new DiceManager(gameManager);
                    diceManager.RollDice();
                    turnsCounter++;
                } while (!gameManager.HasWinner);

                GamesByTurns.Add(i, turnsCounter);
            }

            int shortestLengthGame = GamesByTurns.Min(g => g.Value);
            int longestLengthGame = GamesByTurns.Max(g => g.Value);
            double averageLengthGame = Math.Ceiling(GamesByTurns.Average(g => g.Value));

            string msg = string.Format("The shortest length game had {0} turns\n\nThe longest length game had {1} turns\n\nThe average length game is {2} turns",
                shortestLengthGame, longestLengthGame, averageLengthGame);
            MessageBox.Show(msg);

            InitializeComponent();
        }
    }
}
