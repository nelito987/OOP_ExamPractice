
using System.Text;
using MusicShopManager.Interfaces;
using MusicShopManager.Models;

namespace MusicShop.Models
{
    public class AcousticGuitar: Guitar, IAcousticGuitar
    {
        //private StringMaterial stringMaterial;

        public AcousticGuitar(
            string make, 
            string model, 
            decimal price, 
            string color, 
            string bodyWood, 
            string fingerBoardWood,
            bool caseIncluded,
            StringMaterial stringMaterial) 
            : base(make, model, price, color, bodyWood, fingerBoardWood)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; private set; }
        public StringMaterial StringMaterial { get; private set; }

        public override string ToString()
        {
            //var output = new StringBuilder(base.ToString());
            //output.AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no").AppendLine()
            //      .AppendFormat("String material: {0}", this.StringMaterial.ToString());
            //return output.ToString();

            var acousticGuitar = new StringBuilder();
            acousticGuitar
                .Append(base.ToString())
                .AppendFormat("Case included: {0}", this.CaseIncluded ? "yes" : "no")
                .AppendLine()
                .AppendFormat("String material: {0}", this.StringMaterial.ToString())
                .AppendLine();
            return acousticGuitar.ToString();

        }
    }
}
