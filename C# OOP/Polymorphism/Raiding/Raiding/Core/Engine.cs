using Softriding.Core.Contracts;
using Softriding.Factory;
using Softriding.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Softriding.Core
{
    public class Engine : IEngine
    {
        private readonly HeroFactory heroFactory;
        private readonly BossFactory bossFactory;

        private readonly ICollection<BaseHero> heroes;
        public Engine()
        {
            this.bossFactory = new BossFactory();
            this.heroes = new HashSet<BaseHero>();
            this.heroFactory = new HeroFactory();
        }
        public void Run()
        {

            int numOFHeroes = int.Parse(Console.ReadLine());
            int counter = 0;
           
            while (numOFHeroes != counter)
            {
               
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    BaseHero hero = heroFactory.Create(type, name);
                    heroes.Add(hero);
                    counter++;
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            Boss boss = bossFactory.Create(bossPower);
            int sumOfHeroePower = 0;
            foreach (var s in heroes)
            {
                Console.WriteLine(s.CastAbility());
            }
            foreach (var sthing in heroes)
            {
                sumOfHeroePower += sthing.Power;
            }
            if (boss.Power <= sumOfHeroePower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
