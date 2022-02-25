using LuckySteps.enums;
using LuckySteps.interfaces;
using LuckySteps.LogInfo;
using LuckySteps.MembersOfGame;
using System;
using System.IO;

namespace LuckySteps.PlayGame
{
    public class Game
    {
        private TicetOfGame _ticet { get; set; }
        private ILogger _logger { get; set; }

        public Game()
        {
            _ticet = CreatTicet();
            _logger = Logger.GetInstance();
        }
        public void StartGame()
        {
            Console.WriteLine("Write your name:");
            string name = Console.ReadLine();
            IUser user = new User(name);
            
            ShowGame(user);
        }
        private void ShowGame(IUser user)
        {
            foreach (IStep step in _ticet.Steps)
            {
                Console.WriteLine("1.left ,2.right,3.Stop");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        if (Result(step, ColumnDescription.left))
                        {
                            Console.WriteLine("you won");
                            user.Many += step.LeftColumn.Many;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("you lose");
                            user.Many = 0;
                            _logger.Info(" lose" + user.Name);
                            StartGame();
                        }
                        break;
                    case ConsoleKey.D2:
                        if (Result(step, ColumnDescription.right))
                        {
                            user.Many += step.RightColumn.Many;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("you lose");
                            user.Many = 0;
                            _logger.Info(" lose" + user.Name);
                            StartGame();
                        }
                        break;
                    case ConsoleKey.D3:
                        _logger.Info(user.Name + "won" + user.Many);
                        return;
                }
                _logger.Info(user.Name + "won 10 step and won" + user.Many);
            }
        }
        private bool Result(IStep step, ColumnDescription d)
        {
            if (step.TrueColumn == d)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private TicetOfGame CreatTicet()
        {
            TicetOfGame ticet = new TicetOfGame();
            for (int i = 0; i < 10; i++)
            {
                CreatStep();
                ticet.AddStep(CreatStep());
            }
            return ticet;
        }
        private IStep CreatStep()
        {
            IColumn left = new Column(ColumnDescription.left);
            IColumn right = new Column(ColumnDescription.right);
            IStep step = new Step();
            step.ChoosManyColumn();
            return step;
        }
    }
}
