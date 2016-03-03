
using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing: Creature
    {
        private const int DefaultAttack = 17;
        private const int DefaultDefense = 13;
        private const int DefaultHealth = 70;
        private const decimal DefaultDamage = 18;

        private const int DoubleDamageRounds = 1;
        private const int RoundsDoubleAttackWhenAttacking = 4;
        private const int AddAttackWhenSkipPoints = 3;



        public CyclopsKing() 
            : base(DefaultAttack, DefaultDefense, DefaultHealth, DefaultDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(AddAttackWhenSkipPoints));
            this.AddSpecialty(new DoubleAttackWhenAttacking(RoundsDoubleAttackWhenAttacking));
            this.AddSpecialty(new DoubleDamage(DoubleDamageRounds));
        }
    }
}
