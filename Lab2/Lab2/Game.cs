using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int playRating { get; set; } = 0;
        public string winner { get; set; }
        public int gameIndex { get; set; }
        public Game(GameAccount player1, GameAccount player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public virtual int getPlayRating(GameAccount player) { return playRating; }
        public void PlayGame(GameAccount Gamer1, GameAccount Gamer2)
        {
            Console.WriteLine("Введіть рейтинг на який грають:");
            playRating = int.Parse(Console.ReadLine());
            while (playRating <= 0 || Gamer1.CurrentRating < playRating || Gamer2.CurrentRating < playRating)
            {
                Console.WriteLine("Рейтинг не може бути меньше 0, або рейтинг одного із гравців менше ніж заданий рейтинг, введіть інший рейтинг");
                playRating = int.Parse(Console.ReadLine());
            }
            Random random = new Random();
            gameIndex += 1;
            Console.WriteLine("Введіть число між 1 і 10: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = random.Next(1, 11);
            if (a > b)
            {
                Console.WriteLine("Гравець 1 виграв");
                player1.WinGame(this, Gamer2.UserName, gameIndex);
                Console.WriteLine("Гравець 2 програв");
                player2.LoseGame(this, Gamer1.UserName, gameIndex);
            }
            if (a < b)
            {
                Console.WriteLine("Гравець 2 виграв");
                player2.WinGame(this, Gamer1.UserName, gameIndex);
                Console.WriteLine("Гравець 1 програв");
                player1.LoseGame(this, Gamer2.UserName, gameIndex);
            }
            if (a == b)
            {
                Console.WriteLine("Нічия");
                player1.DrawGame(this, Gamer2.UserName, gameIndex, Gamer1.CurrentRating);
                player2.DrawGame(this, Gamer1.UserName, gameIndex, Gamer2.CurrentRating);
            }
        }

    }
}
