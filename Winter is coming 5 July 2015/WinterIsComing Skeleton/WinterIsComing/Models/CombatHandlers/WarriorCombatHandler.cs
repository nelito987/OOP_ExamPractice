

using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    public class WarriorCombatHandler : CombatHandlerBase
    {
        public WarriorCombatHandler(IUnit unit) 
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var nextTarget = candidateTargets
                .OrderBy(x => x.HealthPoints)
                .ThenBy(x => x.Name)
                .Take(1).ToList();

            return nextTarget;
        }

        public override ISpell GenerateAttack()
        {
            var damage = this.Unit.AttackPoints;
            if (this.Unit.HealthPoints <= 80)
            {
                damage += this.Unit.HealthPoints*2;
            }

            var spell = new Cleave(damage);
            if (this.Unit.HealthPoints > 50)
            {
                Validators.EnergyValidator.ValidateEnergyPoints(this.Unit, spell);
                this.Unit.EnergyPoints -= spell.EnergyCost;
            }
            return spell;
        }
    }
}
