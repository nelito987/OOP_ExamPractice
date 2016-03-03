using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    class AncientBehemoth : Creature
    {
        private const int DefAttack = 19;
        private const int DefHealth = 300;
        private const int DefDeffence = 19;
        private const decimal DefDamage = 40;

        private const decimal ReduseEnemyPercentage = 80;
        private const int DoubleDefenceRounds = 5;

        public AncientBehemoth() 
            : base(DefAttack, DefDeffence, DefHealth, DefDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(ReduseEnemyPercentage));
            this.AddSpecialty(new DoubleDefenseWhenDefending(DoubleDefenceRounds));
        }


    }
}
