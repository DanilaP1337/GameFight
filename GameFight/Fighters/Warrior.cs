using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFight.Fighters
{
    //Воин
    public class Warrior : FighterBase
    {
        public Warrior(string name = "Должен выбрать игрок") : base (name, "Воин", "Ярость - Боль делает воина только сильнее. После удара воин впадает в ярость и трижды бьет противника щитом. Урон каждого удара равен показателю силы", 5, 0, 5)
        {

        }
        public override int UseUltimateAbility(FighterBase warrior1)
        {
            int chance = random.Next(1, 3);
            switch (chance)
            {
                case 1:
                    int totalDamage3 = warrior1.SecondSward();
                    return totalDamage3;
                case 2:
                    int totalDamage4 = warrior1.Rage();
                    return totalDamage4;
                default:
                    return 0;
            }
        }
    }
}

