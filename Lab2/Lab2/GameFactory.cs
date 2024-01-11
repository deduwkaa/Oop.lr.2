﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Games;

namespace Lab2
{
    internal class GameFactory
    {
        public Game CreateStandartGame(GameAccount player1, GameAccount player2)
        {
            return new StandartGame(player1, player2);
        }
        public Game CreateHalfGame(GameAccount player1, GameAccount player2)
        {
            return new HalfGame(player1, player2);
        }
        public Game CreateDoubleRatingGame(GameAccount player1, GameAccount player2)
        {
            return new DoubleRatingGame(player1, player2);
        }
    }
}
