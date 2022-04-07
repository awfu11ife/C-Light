using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork31
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] map = { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', },
                            { '#', ' ', ' ', ' ', '%', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', },
                            { '#', ' ', ' ', '#', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', '#', },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#', },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', '#', ' ', ' ', '#', },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', 'X', '#', ' ', ' ', '#', },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', },
                            { '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#', },
                            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', }
            };
            char player = '%';
            char finish = 'X';
            int finishPositionX;
            int finishPositionY;
            int playerPositionX;
            int playerPositionY;
            bool isPlaying = true;

            DrawMap(map, player, out playerPositionX, out playerPositionY, finish, out finishPositionX, out finishPositionY);
            Move(map, player, finishPositionX, finishPositionY, ref playerPositionX, ref playerPositionY, ref isPlaying);
        }

        static void DrawMap(char[,] map, char player, out int playerPositionX, out int playerPositionY, char finish, out int finishPositionX, out int finishPositionY)
        {
            playerPositionX = 0;
            playerPositionY = 0;
            finishPositionX = 0;
            finishPositionY = 0;

            Console.CursorVisible = false;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);

                    if (map[i, j] == player)
                    {
                        playerPositionX = i;
                        playerPositionY = j;
                    }

                    if (map[i, j] == finish)
                    {
                        finishPositionX = i;
                        finishPositionY = j;
                    }
                }

                Console.WriteLine();
            }
        }

        static void Move(char[,] map, char player, int finishPositionX, int finishPositionY, ref int playerPositionX, ref int playerPositionY, ref bool isPlaying)
        {

            int playerDirectionX = 0;
            int playerDirectionY = 0;

            while (isPlaying == true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerDirectionX = -1;
                            playerDirectionY = 0;
                            break;

                        case ConsoleKey.DownArrow:
                            playerDirectionX = 1;
                            playerDirectionY = 0;
                            break;

                        case ConsoleKey.LeftArrow:
                            playerDirectionX = 0;
                            playerDirectionY = -1;
                            break;

                        case ConsoleKey.RightArrow:
                            playerDirectionX = 0;
                            playerDirectionY = 1;
                            break;
                    }

                    if (map[playerPositionX + playerDirectionX, playerPositionY + playerDirectionY] != '#')
                    {
                        Console.SetCursorPosition(playerPositionY, playerPositionX);
                        Console.Write(" ");
                        playerPositionX += playerDirectionX;
                        playerPositionY += playerDirectionY;
                        Console.SetCursorPosition(playerPositionY, playerPositionX);
                        Console.Write(player);
                    }
                }

                Win(playerPositionX, playerPositionY, finishPositionX, finishPositionY, ref isPlaying);
            }
        }

        static void Win(int playerPositionX, int playerPositionY, int finishPositionX, int finishPositionY, ref bool isPlaying)
        {
            int winCursorPositionX = 10;
            int winCursorPositionY = 10;

            if (playerPositionX == finishPositionX && playerPositionY == finishPositionY)
            {
                isPlaying = false;
                Console.SetCursorPosition(winCursorPositionY, winCursorPositionX);
                Console.WriteLine("WIN!!!!");
            }
        }
    }
}
