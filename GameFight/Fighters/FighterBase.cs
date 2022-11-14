using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameFight.Fighters
{
    public abstract class FighterBase
    {
        protected Random random; // генерация случайных чисел
        //члены класса
        public event Action IsDead; //боец мертв
        public string Name { get; private set; }
        public string ClassDescription { get; private set; }
        public string UltimateAbilityDescription { get; private set; }

        private int strenght;
        public int Strenght
        {
            get { return strenght; }
            set 
            {   
                strenght = value;
                Damage = value * Constants.damageMultiplayer; 
            }
        }
        public int Damage { get; private set; }

        private int agility;
        public int Agility 
        {
            get { return agility; }
            set
            {
                agility = value;
                DodgeChance = value * Constants.dodgeMultiplayer; 
            }
        }
        public int DodgeChance { get; private set; }

        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                HP = value * Constants.hpMultiplayer;
            }
        }
        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp < 0)
                {
                    hp = 0;
                    IsDead?.Invoke();
                }
            }
        }

        protected FighterBase(string name, string classDescription, string ultimateAbilityDescription, int strenght, int agility, int vitality)
        {
            random = new Random();
            Name = name;
            ClassDescription = classDescription;
            UltimateAbilityDescription = ultimateAbilityDescription;
            Strenght = strenght;
            Agility = agility;
            Vitality = vitality;
        }

        public int Kick()
        {
            int totalDamage = random.Next(Damage - Constants.damageVariety, Damage + Constants.damageVariety);
            Console.WriteLine("{0} ударил(а) и нанес(ла) {1} урона!", Name, totalDamage);
            return totalDamage;
        }

        public virtual int UseUltimateAbility(FighterBase fighters)
        {
            return 0;
        }

        public override string ToString()
        {
            return $"\nИмя: {Name}\nКласс: {ClassDescription}\nСила: {Strenght}\t\tЛовкость: {Agility}\t\tЖивучесть: {Vitality}\nУрон: {Damage}\tШанс увернуться: {DodgeChance}%\tHP: {HP}\nУмение: {UltimateAbilityDescription}";
        }


        public int FireWall()
        {
            int totalDamage1 = random.Next(1, 101);
            int AddDamage = random.Next(1, 51);
            Console.WriteLine("{0} на секунду концентрируется и пускает в противника огненный шар на {1} урона и противник начинает гореть", Name, totalDamage1);
            Console.WriteLine("противник {0} загорелся и дополнительно ему снесло {1} урона", Name, AddDamage);
            return totalDamage1;
        }
        public int IceWall()
        {
            int totalDamage2 = random.Next(1, 201);
            Console.WriteLine("{0} имеет 10% шанс пустить ледяной шар и нанести {1} урона ", Name, totalDamage2);
            return totalDamage2;
        }
        public int Healing()
        {
            int totalHealing = random.Next(HP + Constants.hpMultiplayer);
            Console.WriteLine("{0} имеет шанс исцелиться на {1} здоровья", Name, totalHealing);
            return totalHealing;
        }
        public int SecondSward()
        {
            int totalDamage3 = Damage * random.Next(1, 3);
            Console.WriteLine("{0} имеет 30% шанс заиметь второй меч и нанести {1} урона ", Name, totalDamage3);
            return totalDamage3;
        }
        public int Rage()
        {
            int totalDamage4 = Strenght * 3;
            Console.WriteLine("{0} впадает в ярость! Он(а) трижды бьет щитом и наносит {1} урона!", Name, totalDamage4);
            return totalDamage4;
        }
        public int SecondHand()
        {
            int totalDamage5 = Damage * 3;
            Console.WriteLine("{0} изловчился(ась) и ударил(а) второй рукой! Этот удар оказался критическим и нанес {1} урона!", Name, totalDamage5);
            return totalDamage5;
        }
        public int ItsDodge()
        {
            Console.WriteLine("{0} попытался(ась) незаметно ударить второй рукой, но противник это заметил(а) и увернулся(ась)!", Name);
            return 0;
        }
    }
}
