
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    class Cleave : Spell
    {
        private const int CleaveEnergyCost = 15;

        public Cleave(int damage) 
            : base(damage, CleaveEnergyCost)
        {
        }
    }
}
