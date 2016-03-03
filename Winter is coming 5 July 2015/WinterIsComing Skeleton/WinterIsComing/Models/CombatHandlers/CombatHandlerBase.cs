
using System;
using System.Collections.Generic;
using WinterIsComing.Contracts;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Models.CombatHandlers
{
    public abstract class CombatHandlerBase : ICombatHandler
    {
        protected CombatHandlerBase(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit { get; set; }

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);


        public abstract ISpell GenerateAttack();

        //public void ValidateTargets(IEnumerable<IUnit> candidateTargets)
        //{
        //    if (candidateTargets == null)
        //    {
        //        throw new ArgumentNullException("targets", "Target list can not be null");
        //    }
        //}
        //
        //public void ValidateEnergyPoints(IUnit unit, ISpell spell)
        //{
        //    if (unit.EnergyPoints < spell.EnergyCost)
        //    {
        //        throw new NotEnoughEnergyException(
        //            string.Format("{0} does not have enough energy to cast {1}", unit.Name, spell.GetType().Name));
        //    }
        //}
    }
}
