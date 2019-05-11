using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public class UiServices
    {
        public int RollDice()
        {
            var random = new Random();
            int randomNumber = random.Next(1, 7);
            return randomNumber;
        }

        public void changeHeroStats(Hero hero, Event point)
        {

            if(hero.Armor > 0)
            {
                point.HealthModifier -= 5;
            }
            if(hero.Food <= 0)
            {
                hero.Health -= 5;
            }
            Console.WriteLine($"Point:{hero.StartPoint} {point.Title}");
            Console.WriteLine(point.Description);
            hero.Armor += point.ArmorModifier;
            hero.Health += point.HealthModifier;
            hero.Food += point.FoodModifier;




        }

       
    }
}
