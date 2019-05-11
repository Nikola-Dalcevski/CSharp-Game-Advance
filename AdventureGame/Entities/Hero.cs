using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
    public class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Food { get; set; }
        public int StartPoint { get; set; }

        public Hero(string name)
        {
            Health = 60;
            Armor = 40;
            Food = 60;
            StartPoint = 0;
            Name = name;
        }
    }
}
