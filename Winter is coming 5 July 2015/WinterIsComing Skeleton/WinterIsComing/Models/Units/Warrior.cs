
using WinterIsComing.Contracts;


namespace WinterIsComing.Models.Units
{
    using CombatHandlers;

    public class Warrior: Unit
    {
        private const int WarriorAttack = 120;
        private const int WarriorHealth = 180;
        private const int WarriorDefense = 70;
        private const int WarriorEnergy = 60;
        private const int WarriorRange = 1;

        public Warrior(string name, int x, int y) 
            : base(name, x, y, WarriorRange, WarriorAttack, WarriorHealth, 
                  WarriorDefense, WarriorEnergy)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }
    }
}
