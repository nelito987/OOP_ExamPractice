
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class BassGuitars: Guitar, IBassGuitar
    {
        private const int BassStrings = 4;

        public BassGuitars(
            string make, 
            string model, 
            decimal price, 
            string color, 
            string bodyWood, 
            string fingerBoardWood) 
            : base(make, model, price, color, bodyWood, fingerBoardWood)
        {
        }

        public override int NumberOfStrings
        {
            get { return BassStrings; }
        }

        public override bool IsElectronic
        {
            get { return true; }
        }
    }
}
