using System;
using System.Text;
using WinterIsComing.Contracts;
using WinterIsComing.Core.Exceptions;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit: IUnit
    {
        private int x;
        private int y;
        private string name;
        private int attackPoints;
        private int healthPoints;
        private int defencePoints;
        private int energyPoints;
        private int rangeOfattack;
        

        protected Unit(string name, int x, int y, int range, int attackPoints, 
            int healthPoints, int defensePoints, int energyPoints)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Range = range;
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
            //this.CombatHandler = combatHandler;
            
        }

        public int X
        {
            get { return this.x; }
            set
            {
                Validators.PositionValidator.PositionCheck(value);
                this.x = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            set
            {
                Validators.PositionValidator.PositionCheck(value);
                this.y = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validators.StringValidator.StringCheck(value);
                this.name = value;
            }
        }
        public int Range { get; }
        public int AttackPoints { get; set; }
        public int HealthPoints { get; set; }
        public int DefensePoints { get; set; }
        public int EnergyPoints { get; set; }

        public ICombatHandler CombatHandler { get; protected set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(">{0} - {1} at ({2},{3})", this.Name, this.GetType().Name, this.X, this.Y).AppendLine();
            if (this.HealthPoints > 0)
            {
                output.AppendFormat("-Health points = " + this.HealthPoints).AppendLine();
                output.AppendFormat("-Attack points = " + this.AttackPoints).AppendLine();
                output.AppendFormat("-Defense points = " + this.DefensePoints).AppendLine();
                output.AppendFormat("-Energy points = " + this.EnergyPoints).AppendLine();
                output.AppendFormat("-Range = " + this.Range);
            }
            else
            {
                output.Append("(Dead)");
            }

            return output.ToString();
        }
    }
}
