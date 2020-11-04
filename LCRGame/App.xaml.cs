using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LCRGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public int NumberOfPlayers { get; set; }

        public int NumberOfGamesToSimulate { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            CheckParamsLength(e.Args, 1);

            string[] gameParams = e.Args[0].Split(',');

            CheckParamsLength(gameParams, 2);

            NumberOfPlayers = NumbersChecker(gameParams[0]);
            NumberOfGamesToSimulate = NumbersChecker(gameParams[1]);

            if (NumberOfPlayers < 3)
            {
                MessageBox.Show("Number of Players must be three or more");

                Environment.Exit(0);
            }

            base.OnStartup(e);
        }

        private static int NumbersChecker(string paramToCheck)
        {
            int number;

            if (!int.TryParse(paramToCheck, out number))
            {
                MessageBox.Show("Only numbers are allowed for both params");

                Environment.Exit(0);
            }

            return number;
        }

        private static void CheckParamsLength(string[] paramArray, int paramLength)
        {
            if (paramArray.Length != paramLength)
            {
                MessageBox.Show("Cannot start it without 2 params (separated with ,) \n\nNumber of players and the number of games to simulate");

                Environment.Exit(0);
            }
        }
    }
}
