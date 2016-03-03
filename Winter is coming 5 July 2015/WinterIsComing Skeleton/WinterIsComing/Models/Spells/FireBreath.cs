
namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        private const int FireBreathCost = 30;

        public FireBreath(int damage) 
            : base(damage, FireBreathCost)
        {
        }
    }
}
