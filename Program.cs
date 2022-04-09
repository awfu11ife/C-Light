using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork39
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player('@', 10, 8);
            Draw draw = new Draw();

            draw.Player(player);
        }
    }

    class Player
    {
        private char _skin;
        private int _positionX;
        private int _positionY;

        public char Skin => _skin;
        public int PositionX => _positionX;
        public int PositionY => _positionY;
        
        public Player(char skin, int positionX, int positionY)
        {
            _skin = skin;
            _positionX = positionX;
            _positionY = positionY;
        }
    }

    class Draw
    {
        public void Player(Player player)
        {
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.WriteLine(player.Skin);
        }
    }
}
