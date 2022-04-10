using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork40
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase(new List<Player>());

            dataBase.StartWork();
        }
    }

    class Player
    {
        private string _nickname;
        private int _playerID;
        private int _level;
        private bool _isBanned;

        public int PlayerID => _playerID;

        public Player(string nickName, int playerID, int level, bool isBanned)
        {
            _nickname = nickName;
            _playerID = playerID;
            _level = level;
            _isBanned = isBanned;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Ник - {_nickname}, ID - {_playerID}, Level - {_level}, Забанен - {_isBanned}");
        }

        public void Ban()
        {
            if (_isBanned == false)
                _isBanned = true;
            else
                Console.WriteLine($"Игрок с ID {_playerID} уже забанен");
        }

        public void Unban()
        {
            if (_isBanned == true)
                _isBanned = false;
            else
                Console.WriteLine("Этот игрок не забанен");
        }
    }

    class DataBase
    {
        private List<Player> _players;

        public DataBase(List<Player> players)
        {
            _players = players;
        }

        public void StartWork()
        {
            const string StopCommand = "stop";
            const string AddPlayer = "add";
            const string ShowPlayers = "showall";
            const string BanPlayer = "ban";
            const string UnbanPlayer = "unban";
            const string DeletePlayer = "delete";
            string userInput = null;

            while (userInput != StopCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды:\n" +
                    $"{StopCommand} - остановить работу\n" +
                    $"{AddPlayer} - добавить игрока\n" +
                    $"{BanPlayer} - забанить игрока\n" +
                    $"{UnbanPlayer} - разбанить игрока\n" +
                    $"{DeletePlayer} - удалить игрока из базы данных\n" +
                    $"{ShowPlayers} - показать всех игроков\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case StopCommand:
                        break;

                    case AddPlayer:
                        AddNewPlayer();
                        break;

                    case BanPlayer:
                        this.BanPlayer();
                        break;

                    case UnbanPlayer:
                        this.UnbanPlayer();
                        break;

                    case DeletePlayer:
                        this.DeletePlayer();
                        break;

                    case ShowPlayers:
                        ShowAllPlayers();
                        break;

                    default:
                        Console.WriteLine("Я не знаю такой команды");
                        break;
                }
            }
        }
        private void AddNewPlayer()
        {
            bool isCorrectID = false;
            int playerID = 0;

            while (isCorrectID == false)
            {
                Console.WriteLine("Введите ID");
                playerID = Convert.ToInt32(Console.ReadLine());

                if (_players.Count > 0)
                {
                    foreach (var player in _players)
                    {
                        if (player.PlayerID == playerID)
                        {
                            Console.WriteLine("Игрок с таким ID уже есть");
                            break;
                        }
                        else
                        {
                            isCorrectID = true;
                        }
                    }
                }
                else
                {
                    isCorrectID = true;
                }

            }

            Console.WriteLine("Введите ник");
            string nickName = Console.ReadLine();
            Console.WriteLine("Введите уровень");
            int level = Convert.ToInt32(Console.ReadLine());
            bool isBanned = false;

            _players.Add(new Player(nickName, playerID, level, isBanned));
        }

        private void ShowAllPlayers()
        {
            if (_players.Count > 0)
            {
                foreach (var player in _players)
                {
                    player.ShowInfo();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("В базе данных пока нет игроков\n");
            }
        }

        private void BanPlayer()
        {
            Console.WriteLine("Введите ID игрока, которго хотите забанить");
            int playerID = Convert.ToInt32(Console.ReadLine());

            foreach (var player in _players)
            {
                if (player.PlayerID == playerID)
                {
                    player.Ban();
                }
            }
        }

        private void UnbanPlayer()
        {
            Console.WriteLine("Введите ID игрока, которго хотите разбанить");
            int playerID = Convert.ToInt32(Console.ReadLine());

            foreach (var player in _players)
            {
                if (player.PlayerID == playerID)
                {
                    player.Unban();
                }
            }
        }

        private void DeletePlayer()
        {
            Console.WriteLine("Введите ID игрока, которго хотите удалить из базы данных");
            int playerID = Convert.ToInt32(Console.ReadLine());

            foreach (var player in _players)
            {
                if (player.PlayerID == playerID)
                {
                    _players.Remove(player);
                    break;
                }
            }
        }
    }
}
