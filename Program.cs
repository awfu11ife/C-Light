using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork19
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerHealth = 100;
            int playerDamage = 0;
            int spellNumber;
            int bossHealth = 300;
            int bossDamage;
            int currentPoisinRoundNumber = 1;
            bool canBossAttack = true;
            bool isBossPoisoned = false;

            Random random = new Random();

            Console.WriteLine("На вашем пути встал сильный босс, скорее в бой!");

            while(playerHealth > 0 & bossHealth > 0)
            {
                Console.WriteLine("В вашем арссенале есть следующие заклинания:\n" +
                    "1 - Огненный шар (наносит врагу 20 урона, отнимает у игрока 5 единиц здоровья)\n" +
                    "2 - Ярость огня (наносит врагу 50 урона, возможно использовать только при уровне здоровья меньше 50)\n" +
                    "3 - Заморозка (Не даёт боссу наносить урон один ход, позволяет игроку воссановить 30 единиц здоровья, при этом босс востанавливает 10 единиц здоровья)\n" +
                    "4 - Отгравление (В течении последующих 5 ходов наносит 10 урона врагу)\n");
                Console.WriteLine($"У вас {playerHealth} хп");
                Console.WriteLine($"У босса {bossHealth} хп");
                Console.WriteLine("Введите номер желаемого заклинания:");
                spellNumber = Convert.ToInt32(Console.ReadLine());

                switch (spellNumber)
                {
                    case 1:
                        playerDamage = 20;
                        playerHealth -= 5;
                        break;

                    case 2:
                        if (playerHealth < 50)
                        {
                            playerDamage = 50;
                        }
                        else
                        {
                            Console.WriteLine("Вы ошиблись! Сейсас у вас не меньше 50 хп, ход переходит боссу!\n");
                        }
                        break;

                    case 3:
                        canBossAttack = false;
                        playerHealth += 30;
                        bossHealth += 10;
                        break;

                    case 4:
                        isBossPoisoned = true;
                        break;

                    default:
                        Console.WriteLine("Вы непрравильно прочитати заклинание! Ход переходит боссу!\n");
                        break;
                }
                bossHealth -= playerDamage;
                playerDamage = 0;
                Console.WriteLine("\nТеперь атакует босс\n");

                if (canBossAttack == true)
                {
                    bossDamage = random.Next(20, 40);
                    playerHealth -= bossDamage;
                    Console.WriteLine($"Босс нанёс вам {bossDamage} единиц урона");
                }
                else
                {
                    Console.WriteLine($"Атака не прошла, босс заморожен");
                    canBossAttack = true;
                }
                if (isBossPoisoned == true && currentPoisinRoundNumber <= 5)
                {
                    bossHealth -= 10;
                    currentPoisinRoundNumber++;
                }
                else
                {
                    currentPoisinRoundNumber = 0;
                    isBossPoisoned = false;
                }
            }

            if (playerHealth <= 0)
            {
                Console.WriteLine("\nВы проиграли!");
            }
            else if (bossHealth <= 0)
            {
                Console.WriteLine("\nБосс повержен! Вы победили!");
            }
            else
            {
                Console.WriteLine("\nВы оба погибли...");
            }
        }
    }
}
