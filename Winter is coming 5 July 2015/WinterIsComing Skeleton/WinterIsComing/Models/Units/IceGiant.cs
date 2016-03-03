using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class IceGiant : Unit
    {
        private const int IceGiantAttack = 150;
        private const int IceGiantHealth = 300;
        private const int IceGiantDefense = 60;
        private const int IceGiantEnergy = 50;
        private const int IceGiantRange = 1;

        public IceGiant(string name, int x, int y) 
            : base(name, x, y, IceGiantRange, IceGiantAttack, 
                  IceGiantHealth, IceGiantDefense, IceGiantEnergy)
        { 
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}
