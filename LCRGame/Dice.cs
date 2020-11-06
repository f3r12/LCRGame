using System;
using System.Collections.Generic;

namespace LCRGame
{
    public class Dice
    {
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
            Side.Add(1, Constants.DOT);
            Side.Add(2, Constants.LEFT);
            Side.Add(3, Constants.DOT);
            Side.Add(4, Constants.CENTER);
            Side.Add(5, Constants.DOT);
            Side.Add(6, Constants.RIGHT);
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