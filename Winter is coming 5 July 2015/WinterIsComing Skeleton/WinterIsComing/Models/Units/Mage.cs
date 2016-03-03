
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    class Mage : Unit
    {
        private const int MageAttack = 80;
        private const int MageHealth = 80;
        private const int MageDefense = 40;
        private const int MageEnergy = 120;
        private const int MageRange = 2;

        public Mage(string name, int x, int y) 
            : base(name, x, y, 
                  MageRange, MageAttack, MageHealth, 
                  MageDefense, MageEnergy)
        {
            this.CombatHandler = new MageCombatHandler(this);
        }
    }
}
