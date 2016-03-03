
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Goblin : Creature
    {
        private const int GoblinAttack = 4;
        private const int GoblinHealth = 5;
        private const int GoblinDeffence = 2;
        private const decimal GoblinDamage = 1.5M;

        public Goblin() 
            : base(GoblinAttack, GoblinDeffence, GoblinHealth, GoblinDamage)
        {
        }
    }
}
