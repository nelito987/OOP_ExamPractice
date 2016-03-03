
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Models.Validators
{
    public static class PositionValidator
    {
        public static void PositionCheck(int coordinate)
        {
            if (coordinate < 0 || coordinate > 4)
            {
                throw new InvalidPositionException("Coordinates has to be in range 0...4");
            }
        }
    }
}
