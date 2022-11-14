using GameFight.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GameFight
{
    public class Game
    {
        private Random random;
        private FightState fightState;
        private FighterBase player1;
        private FighterBase player2;

        public Game()
        {   
            random = new Random();
            fightState = FightState.NextRound;
        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("ПЕРВЫЙ ИГРОК СОЗДАЕТ БОЙЦА: \n");
            player1 = CreateFighter();
            Console.Clear();
            Console.WriteLine("ВТОРОЙ ИГРОК СОЗДАЕТ БОЙЦА: \n");
            player2 = CreateFighter();
            Console.Clear();
            StartFight();
        }
        private FighterBase CreateFighter()
        {
            FighterBase fighter;
            int points = Constants.pointsNumber;

            Console.WriteLine("Назовите своего бойца: ");
            string name = Console.ReadLine();

            Console.WriteLine("\n Выберите класс героя:\n1: Воин\n2: Ловкач\n3: Маг");
            string fighterType = Console.ReadLine();

            switch (fighterType)
            {
                case "1":
                    fighter = new Warrior(name);
                    break;
                case "2":
                    fighter = new Dodger(name);
                    break;
                default:
                    fighter = new Mage(name);
                    break;
            }
            while (points > 0)
            {
                Console.Clear();
                Console.WriteLine(fighter);
                Console.WriteLine("Распределите очки умений среди характеристик персонажа:");
                Console.WriteLine("+1 Силы:      +{0} к урону", Constants.damageMultiplayer);
                Console.WriteLine("+1 Ловкости:  +{0}% увернуться от атаки", Constants.dodgeMultiplayer);
                Console.WriteLine("+1 Живучести: +{0} HP", Constants.hpMultiplayer);
                Console.WriteLine();
                Console.WriteLine("Осталось очков умений: {0}", points);
                Console.WriteLine("1: +1 Силы");
                Console.WriteLine("2: +1 Ловкости");
                Console.WriteLine("3: +1 Живучести");
                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strenght += 1;
                        break;
                    case "2":
                        fighter.Agility += 1;
                        break;
                    default:
                        fighter.Vitality += 1;
                        break;
                }
                points -= 1;
             
            }
            fighter.IsDead += () => fightState = FightState.Stopped;
            return fighter;
        }
        private void StartFight()
        {         
                Console.Clear();
                Console.WriteLine("...3...");
                Thread.Sleep(1000);
                Console.WriteLine("...2...");
                Thread.Sleep(1000);
                Console.WriteLine("...1...");
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("...Раунд начался...");
                Thread.Sleep(1000);
                
            
            int round = 1;
            while (fightState == FightState.NextRound)
            {
                Console.Clear();
                Console.WriteLine("РАУНД {0}\n", round);

                CalculateDamage(player1, player2);
                CalculateDamage(player2, player1);

                Console.WriteLine();
                Console.WriteLine("ИГРОК 1");
                Console.WriteLine(player1);              
                Console.WriteLine();
                Console.WriteLine("ИГРОК 2");
                Console.WriteLine(player2);

                Console.ReadLine();
                round += 1;
            }
            Console.WriteLine("\t<<<БОЙ ОКОНЧЕН!>>>");
            if (player1.HP == 0)
                Console.WriteLine("\t<<<Победил>>> " + player2.Name);
            else
                Console.WriteLine("\t<<<Победил>>> " + player1.Name);
            Console.ReadLine();
        }

        private void CalculateDamage(FighterBase agressor, FighterBase victim)
        {
            if (victim.DodgeChance > random.Next(1, 101))
            {
                Console.WriteLine("{0} хотел(а) ударить, но противник увернулся от удара!", agressor.Name);
            }
            else
            {
                victim.HP -= agressor.Kick();
                victim.HP -= agressor.UseUltimateAbility(agressor);
            }
            
        }

    }
}

    

