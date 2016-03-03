using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin: Creature
    {
        private const int DefaultAttack = 8;
        private const int DefaultDefense = 8;
        private const int DefaultHealth = 25;
        private const decimal DefaultDamage = 4.5M;

        private const int Rounds = 5;
        private const int DefenseWhenSkip = 3;


        public Griffin() 
            : base(DefaultAttack, DefaultDefense, DefaultHealth, DefaultDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(Rounds));
            this.AddSpecialty(new AddDefenseWhenSkip(DefenseWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
