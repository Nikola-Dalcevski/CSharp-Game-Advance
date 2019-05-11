using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

using System.IO;
using Services;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
                UiServices service = new UiServices();
                var path = @"C:\Users\nikola.dalchevski\Desktop\Game\AdventureGame\Services\Events\events.json";
                StreamReader sr = new StreamReader(path);
                var json = JsonConvert.DeserializeObject<List<Event>>(sr.ReadToEnd());
               




            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Hero nikola = new Hero("Nikola");
                nikola.StartPoint = 0;
                Console.WriteLine("Game Starts");
                while (true)
                {
                    Console.WriteLine($"Player: {nikola.Name}");
                    Console.WriteLine($"Health: {nikola.Health}");
                    Console.WriteLine($"Armor: {nikola.Armor}");
                    Console.WriteLine($"Food: {nikola.Food}");

                    Console.WriteLine("Press enter to roll the dice");
                    Console.ReadLine();

                    int diceNumber = service.RollDice();
                    Console.WriteLine(diceNumber);
                    nikola.StartPoint += diceNumber;


                    if ( nikola.Health <= 0 )
                    {
                        Console.WriteLine("Game Over");
                        Console.ReadLine();
                        break;
                    }
                    if (nikola.StartPoint > json.Count - 1)
                    {
                        Console.WriteLine("You won");
                        Console.ReadLine();
                        break;
                    }


                    Event findEvent = json[nikola.StartPoint];
                    if(findEvent.Type.ToString() == "Good")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }else if (findEvent.Type.ToString() == "Bad")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(findEvent.Type.ToString() == "Neutral")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    service.changeHeroStats(nikola, findEvent);







                }

                Console.WriteLine("Do you whant to start anadore game Y/n");
                string answer = Console.ReadLine();
                if (answer == "N" || answer == "n") break;
                
                
            }
            
             
                

        }
    }
}
