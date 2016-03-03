
using System.Collections.Generic;
using System.Linq;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Spells;

namespace WinterIsComing.Models.CombatHandlers
{
    class MageCombatHandler :CombatHandlerBase
    {
        private int attackCount;

        public MageCombatHandler(IUnit unit) 
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var target = candidateTargets
                .OrderByDescending(x => x.HealthPoints)
                .ThenBy(x => x.Name)
                .Take(3)
                .ToList();

            return target;
        }

        public override ISpell GenerateAttack()
        {
            ISpell spell;
            if (this.attackCount % 2 == 0)
            {
                var fireBreathDamage = this.Unit.AttackPoints;
                spell = new FireBreath(fireBreathDamage);
            }
            else
            {
                var blizzardDamage = this.Unit.AttackPoints*2;
                spell = new Blizzard(blizzardDamage);
            }

            Validators.EnergyValidator.ValidateEnergyPoints(this.Unit, spell);
            attackCount++;
            this.Unit.EnergyPoints -= spell.EnergyCost;
            return spell;
        }
    }
}
