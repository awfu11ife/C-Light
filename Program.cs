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
            int fireBallDamage = 20;
            int fireBallPlayerDamage = 5;
            int fireRageDamage = 50;
            int maxFireRageUseHealth = 50;
            int freezePlayerHeal = 30;
            int poisingDamage = 10;
            int maxPoisingRounds = 5;
            int bossHealth = 300;
            int bossDamage;
            int maxBossDamage = 40;
            int minBossDamage = 20;
            int freezeBossHeal = 10;
            int currentPoisinRoundNumber = 1;
            bool canBossAttack = true;
            bool isBossPoisoned = false;
            Random random = new Random();

            Console.WriteLine("На вашем пути встал сильный босс, скорее в бой!");

            while(playerHealth > 0 & bossHealth > 0)
            {
                Console.WriteLine($"В вашем арссенале есть следующие заклинания:\n" +
                    $"1 - Огненный шар (наносит врагу {fireBallDamage} урона, отнимает у игрока {fireBallPlayerDamage} единиц здоровья)\n" +
                    $"2 - Ярость огня (наносит врагу {fireRageDamage} урона, возможно использовать только при уровне здоровья меньше {maxFireRageUseHealth})\n" +
                    $"3 - Заморозка (Не даёт боссу наносить урон один ход, позволяет игроку воссановить {freezePlayerHeal} единиц здоровья, при этом босс востанавливает {freezeBossHeal} единиц здоровья)\n" +
                    $"4 - Отгравление (В течении последующих {maxPoisingRounds} ходов наносит {poisingDamage} урона врагу)\n");
                Console.WriteLine($"У вас {playerHealth} хп");
                Console.WriteLine($"У босса {bossHealth} хп");
                Console.WriteLine("Введите номер желаемого заклинания:");
                spellNumber = Convert.ToInt32(Console.ReadLine());

                switch (spellNumber)
                {
                    case 1:
                        playerDamage = fireBallDamage;
                        playerHealth -= fireBallPlayerDamage;
                        break;

                    case 2:
                        if (playerHealth < maxFireRageUseHealth)
                        {
                            playerDamage = fireRageDamage;
                        }
                        else
                        {
                            Console.WriteLine($"Вы ошиблись! Сейсас у вас не меньше {maxFireRageUseHealth} хп, ход переходит боссу!\n");
                        }
                        break;

                    case 3:
                        canBossAttack = false;
                        playerHealth += freezePlayerHeal;
                        bossHealth += freezeBossHeal;
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
                    bossDamage = random.Next(minBossDamage, maxBossDamage);
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
                    bossHealth -= poisingDamage;
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
