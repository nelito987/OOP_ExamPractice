using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Core;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Models.Validators
{
    public static class EnergyValidator
    {
        public static void ValidateEnergyPoints(IUnit unit, ISpell spell)
        {
            if (unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, unit.Name, spell.GetType().Name));
            }
        }
    }
}
