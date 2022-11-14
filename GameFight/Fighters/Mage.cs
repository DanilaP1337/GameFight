using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameFight.Fighters
{
    // Маг
    public class Mage : FighterBase
    {
        public Mage(string name = "Должен выбрать игрок") : base(name, "Маг", "Концентрация - Ничто не способно вывести мага из равновесия. Маг на секунду концентрируется и пускает в противника огненный шар на 1-60 урона", 2, 3, 5)
        { 

        }
        public override int UseUltimateAbility(FighterBase mage1)
        {
            int chance = random.Next(1,4);
            switch (chance )
            {
                case 1:
                    int totalDamage = mage1.FireWall();
                    return totalDamage;
                case 2:
                    int totalDamage2 = mage1.IceWall();
                    return totalDamage2;
                case 3:
                    int totalHealing = mage1.Healing();
                    return totalHealing;
                default:
                    return 0;
            }
        }
    }
}
