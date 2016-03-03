
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        // public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, 
        //int timeToPrepare, bool isVegan, string type)
        public MainCourse(string name, decimal price, int calories, 
            int quantityPerServing, int timeToPrepare, 
            bool isVegan, MainCourseType type) 
            : base(name, price, calories, quantityPerServing,  timeToPrepare, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type { get; }

        public override string ToString()
        {
            //var output = new StringBuilder(base.ToString());
            //output.AppendFormat("Type: {0}", this.Type).AppendLine();
            //return output.ToString().Trim();

            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("Type: {0}", this.Type).AppendLine();
            return sb.ToString();
        }
    }
}
