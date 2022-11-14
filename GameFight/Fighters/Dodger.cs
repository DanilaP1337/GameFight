using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFight.Fighters
{
    // Ловкач
    public class Dodger : FighterBase
    {
        public Dodger(string name = "Должен выбрать игрок") : base(name, "Ловкач", "Ловкость рук - Есть 25% шанс запутать противника и незаметно ударить второй рукой. Такой удар считается критическим попаданием (x3)", 3, 4, 3)
        {

        }
        public override int UseUltimateAbility(FighterBase dodger1)
        {
            int chance = random.Next(1, 3);
            switch (chance)
            {
                case 1:
                    int totalDamage5 = dodger1.SecondHand();
                    return totalDamage5;
                case 2:
                    int totalDamage6 = dodger1.ItsDodge();
                    return totalDamage6;
                default:
                    return 0;        
            }
        }
    }
}