using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    class IceGiantCombatHandler : CombatHandlerBase
    {
        public IceGiantCombatHandler(IUnit unit) 
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                return candidateTargets.Take(1).ToList();
            }
            return candidateTargets.ToList();
        }

        public override ISpell GenerateAttack()
        {
            var damage = this.Unit.AttackPoints;
            var spell = new Stomp(damage);
            Validators.EnergyValidator.ValidateEnergyPoints(this.Unit, spell);
            this.Unit.AttackPoints += 5;
            this.Unit.EnergyPoints -= spell.EnergyCost;
            return spell;
        }
    }
}
