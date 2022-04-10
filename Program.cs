using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork41
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }
        static void StartGame()
        {
            const string TakeCard = "takecard";
            const string ShowCards = "showcards";
            const string Exit = "exit";
            string userInput = null;

            CardDeck cardDeck = new CardDeck(new List<Card>());
            Player player = new Player(new List<Card>(0));
            cardDeck.CreateDeck();

            while (userInput != Exit)
            {
                Console.WriteLine($"Вам доступны следующие команды:\n" +
                    $"{TakeCard} - вять случайную карту\n" +
                    $"{ShowCards} - показать ваши карты\n" +
                    $"{Exit} - выйти\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case TakeCard:
                        player.TakeCard(cardDeck);
                        break;

                    case ShowCards:
                        player.ShowCards();
                        break;

                    case Exit:
                        break;

                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }
    }

    class Player
    {
        private List<Card> _receivedCards = new List<Card>();

        public Player(List<Card> recevedCards)
        {
            _receivedCards = recevedCards;
        }

        public void ShowCards()
        {

            if (_receivedCards.Count > 0)
            {
                foreach (var card in _receivedCards)
                {
                    Console.WriteLine($"{card.Value} {card.Suit} ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Вы ещё не взяли ни одной карты\n");
            }
        }

        public void TakeCard(CardDeck cardDeck)
        {
            _receivedCards.Add(cardDeck.RemoveCard());
        }

    }

    class CardDeck
    {
        private List<Card> _allCards;
        private string[] _values = new string[] { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
        private string[] _suits = new string[] { "Пики", "Червы", "Бубны", "Крести" };

        public CardDeck(List<Card> allCards)
        {
            _allCards = allCards;
        }
       
        public Card RemoveCard()
        {
            Random random = new Random();

            if (_allCards.Count > 0)
            {
                Card currentCard = _allCards[random.Next(0, _allCards.Count)];
                _allCards.Remove(currentCard);
                Console.WriteLine("Вы взяли карту\n");
                return currentCard;
            }
            else
            {
                Console.WriteLine("Вы забрали все карты\n");
                return null;
            }
        }

        public void CreateDeck()
        {
            for (int i = 0; i < _suits.Length; i++)
            {
                for (int j = 0; j < _values.Length; j++)
                {
                    _allCards.Add(new Card(_values[j], _suits[i]));
                }
            }
        }
    }

    class Card
    {
        private string _value;
        private string _suit;

        public string Value => _value;
        public string Suit => _suit;

        public Card(string value, string suit)
        {
            _value = value;
            _suit = suit;
        }
    }
}
