using System;
using System.Collections.Generic;

namespace LCRGame
{
    public class Dice
    {
        private const string DOT = "P";

        private const string LEFT = "L";

        private const string CENTER = "C";

        private const string RIGHT = "R";

        public int ID { get; set; }

        public Dictionary<int, string> Side { get; set; }

        public string AfterRolledSide { get; set; }

        public Dice(int id)
        {
            ID = id;
            Side = new Dictionary<int, string>();

            FillDiceSides();
        }

        private void FillDiceSides()
        {
            Side.Add(1, DOT);
            Side.Add(2, DOT);
            Side.Add(3, DOT);
            Side.Add(4, LEFT);
            Side.Add(5, CENTER);
            Side.Add(6, RIGHT);
        }

        public string ChooseSide(int sideId)
        {
            string sideName = string.Empty;

            if (Side.TryGetValue(sideId, out sideName))
            {
                AfterRolledSide = sideName;
            }

            return AfterRolledSide;
        }
    }
}