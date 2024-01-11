using Lab2.Accounts;
namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program program = new Program();
            program.Run();
        }
        public void Run()
        {
            string answer;
            Console.WriteLine("Введіть ім'я: ");
            string firstUser = Console.ReadLine();
            GameAccount player1 = AccountChose(firstUser);
            Console.WriteLine("Введіть ім'я: ");
            string secondUser = Console.ReadLine();
            GameAccount player2 = AccountChose(secondUser);

            Game game = GameType(player1, player2);
            do
            {
                game.PlayGame(player1, player2);
                Console.WriteLine("Зіграти ще раз? (Y/N)");
                answer = Console.ReadLine();
            } while (answer == "Y" || answer == "y");
            player1.GetStats();
        }
        private GameAccount AccountChose(string userName)
        {
            Console.WriteLine("Виберіть тип аккаунту: \n1.StandartAccount \n2.UnrankedAccount \n3.BoostedAccount");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    return new StandartAccount(userName);
                case 2:
                    return new UnrankedAccount(userName);
                case 3:
                    return new BoostedAccount(userName);
                default:
                    Console.WriteLine("Невірно. Введіть число між 1-3");
                    return AccountChose(userName);
            }
        }
        private Game GameType(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("Виберіть тип гри: \n1.StandartGame \n2.HalfGame \n3.DoubleRatingGame");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateStandartGame(player1, player2);
                case 2:
                    return factory.CreateHalfGame(player1, player2);
                case 3:
                    return factory.CreateDoubleRatingGame(player1, player2);
                default:
                    Console.WriteLine("Невірно. Введіть число між 1-3");
                    return GameType(player1, player2);
            }
        }
    }
}
