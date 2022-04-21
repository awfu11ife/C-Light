using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork50
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadOnlyDictionary<string, int> allDetaisType = new Dictionary<string, int> { { "Двигатель", 300 }, { "Коробка передач", 200 }, { "Тормоза", 100 } };

            StartCarServing(allDetaisType);
        }

        static void StartCarServing(IReadOnlyDictionary<string, int> allDetails)
        {
            const string StopWorkCommand = "stop";
            string userInput = null;
            CarService carService = new CarService(allDetails, 20);

            while (userInput != StopWorkCommand)
            {
                carService.ShowWarehouse();
                Console.WriteLine($"\nНа вамеи счету сейчас {carService.CurrentRevenue} рублей");
                Console.WriteLine($"Введите 'Enter', чтобы обслужить следующего клиента, или  {StopWorkCommand}, чтобы завершить рабочий день");
                userInput = Console.ReadLine();

                if (userInput != StopWorkCommand)
                {
                    carService.ServeVisitor(new Visitor(allDetails));
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"День окончен, общая выручка - {carService.CurrentRevenue}");
                    break;
                }
            }
        }
    }

    class CarService
    {
        private List<Detail> _warehouse = new List<Detail>();
        private int _revenue = 0;

        public int CurrentRevenue => _revenue;

        public CarService(IReadOnlyDictionary<string, int> allDetailsType, int numberOfDetails)
        {
            FillWarehouse(allDetailsType, numberOfDetails);
        }

        public void ServeVisitor(Visitor visitor)
        {
            const string NotServeVisitorCommand = "sorry";
            const int NotServeFine = 150;
            const int WrongDetailFine = 300;
            const int WorkPay = 500;
            string userInput = null;
            bool isCorrectInput;

            Console.WriteLine($"У посетителя поломка - {visitor.BrokenDetailName}\n");
            Console.WriteLine($"Введите номер детали, которую хотите поставить клиенту, либо {NotServeVisitorCommand}, чтобы не обсуживать его");

            userInput = Console.ReadLine();

            if (userInput == NotServeVisitorCommand)
            {
                Console.WriteLine($"Клиент ушел, вы заплатили штраф {NotServeFine}");
                PayFine(NotServeFine);
            }
            else
            {
                isCorrectInput = int.TryParse(userInput, out int numberOfDetail);

                if (isCorrectInput)
                {
                    bool isCorrectDetail;

                    if (numberOfDetail >= 0 && numberOfDetail < _warehouse.Count)
                    {
                        isCorrectDetail = visitor.CheckDetailCorrectness(_warehouse[numberOfDetail].Name);

                        if (isCorrectDetail)
                        {
                            Console.WriteLine($"Деталь успешно установлена, вы получили выручку - {_warehouse[numberOfDetail].Price + WorkPay}");
                            _revenue += _warehouse[numberOfDetail].Price + WorkPay;
                            _warehouse.RemoveAt(numberOfDetail);
                        }
                        else
                        {
                            Console.WriteLine($"Вы установили не ту деталь и заплатили штраф - {WrongDetailFine}. Клиент уехал");
                            PayFine(WrongDetailFine);
                            _warehouse.RemoveAt(numberOfDetail);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Детали с таким номером нет, клиент ушел и вы заплатили штраф {NotServeFine}");
                    }
                }
                else
                {
                    Console.WriteLine($"Детали с таким номером нет, клиент ушел и вы заплатили штраф {NotServeFine}");
                }
            }
        }

        public void ShowWarehouse()
        {
            Console.WriteLine("На складе сейчас лежат:\n");

            for (int i = 0; i < _warehouse.Count; i++)
            {
                Console.WriteLine($"{i} - {_warehouse[i].Name}");
            }
        }

        private void PayFine(int fine)
        {
            _revenue -= fine;
        }

        private void FillWarehouse(IReadOnlyDictionary<string, int> allDetailsType, int numberOfDetails)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfDetails; i++)
            {
                _warehouse.Add(new Detail(allDetailsType, random));
            }
        }
    }

    class Visitor
    {
        public string BrokenDetailName { get; private set; }

        public Visitor(IReadOnlyDictionary<string, int> allDetails)
        {
            BrokenDetailName = SetBrokenDetail(allDetails);
        }

        public bool CheckDetailCorrectness(string detailName)
        {
            return BrokenDetailName == detailName;
        }

        private string SetBrokenDetail(IReadOnlyDictionary<string, int> allDetails)
        {
            Random random = new Random();
            string brokenDetailName;

            return brokenDetailName = allDetails.ElementAt(random.Next(0, allDetails.Count)).Key;
        }
    }

    class Detail
    {
        public int Price { get; private set; }
        public string Name { get; private set; }

        public Detail(IReadOnlyDictionary<string, int> allDetailsType, Random random)
        {
            int detailNumber = random.Next(0, allDetailsType.Count);

            Name = allDetailsType.ElementAt(detailNumber).Key;
            Price = allDetailsType.ElementAt(detailNumber).Value;
        }
    }


}
