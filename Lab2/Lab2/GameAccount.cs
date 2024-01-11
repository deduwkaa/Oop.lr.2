using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        public GameAccount(string userName)
        {
            UserName = userName;
            CurrentRating = 100;
            GamesCount = 0;
        }
        public void WinGame(Game game, string player, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating += rating;
            GamesCount++;
            GameResults.Add(new GameResult(player, "Виграв", rating, gameIndex, CurrentRating));
        }
        public void LoseGame(Game game, string player, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            if (CurrentRating > 1)
            {
                CurrentRating -= rating;
                if (CurrentRating < 1)
                {
                    CurrentRating = 1;
                }
            }
            GamesCount++;
            GameResults.Add(new GameResult(player, "Програв", rating, gameIndex, CurrentRating));
        }
        public void DrawGame(Game game, string player, int gameIndex, int currentRating)
        {
            GamesCount++;
            int rating = RatingCalc(game.getPlayRating(this));
            GameResults.Add(new GameResult(player, "Нічия", rating, gameIndex, currentRating));
        }
        public void GetStats()
        {
            foreach (GameResult result in GameResults)
            {
                Console.WriteLine($"Проти {result.Opponent}, {result.Winner}, Рейтинг: {result.CurrentRating}, Номер гри #{result.GameIndex}");
            }
        }
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
