using System.Security.Cryptography.X509Certificates;

namespace FightArena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List that stores the winners of the round/match
            List<Hero> semiFinalList = new List<Hero>();

            // Method for attacking each other by turns
            // Until one of the participants gets 0 or less HP
            // The winner is then added to the winner list above
            void StartRound(Hero HeroX, Hero HeroY)
            {
                // Making a bool to keep track of whether a person is dead or not
                bool keepGoing = true;

                // A while loop that keeps going until the keepGoing bool is set to false (which is when someone has died)
                while (keepGoing)
                {
                    // If the HeroX has reached 0 or less HP
                    if (HeroX.HitPoints <= 0)
                    {
                        // Then HeroY gets printed as the winner
                        Console.WriteLine(HeroY.HeroName + " has won");
                        // And HeroY will be added to the semiFinalList 
                        semiFinalList.Add(HeroY);
                        // And the loop will stop since the keepGoing bool is set to false
                        keepGoing = false;
                    }

                    else if (HeroY.HitPoints <= 0)
                    {
                        // Does the exact same, just with the opposite contender
                        Console.WriteLine(HeroX.HeroName + " has won");
                        semiFinalList.Add(HeroX);
                        keepGoing = false;

                    }
                    else
                    {
                        // If none of them are 0 or below HP, then they will keep attacking in turns
                        HeroX.Attack(HeroY);
                        HeroY.Attack(HeroX);
                    }
                }
            }

            

            // Creating a new random object so that I can use it for the attack range
            Random randomizer = new Random();

            // Instantiating the class to create an object of the class for every hero
            // Parameters are (decimal hitPoints, decimal attackPoints, decimal defencePoints, string heroName)
            // So Harry will have 120 HP, 2 Attack, 5 Defence and the name Kong Fu Harry
            Hero Harry = new Hero(120, 2, 5, "Kong Fu Harry");
            Hero Dino = new Hero(70, randomizer.Next(6, 9), randomizer.Next(2, 9), "Superhunden Dino");

            // The 2nd parameter of SwitchAttackHero does not matter since it is overwritten in the code and set to
            // Either AttackX or AttackY depending on what the turn is
            SwitchAttackHero Karl = new SwitchAttackHero(90, 2, 5, 2, 5, "Hurtig Karl");

            // The 1st parameter of HumanHero does not matter since it is overwritten to be 90, since human heroes have 90 HP
            HumanHero Gunner = new HumanHero(2, randomizer.Next(1, 14), 5, "Gift Gunner");
            Hero Mikkel = new Hero(40, 9, 9, "Minimusen Mikkel");
            SwitchAttackHero Tiger = new SwitchAttackHero(35, 2, 3, 6, 4, "Katten Tiger");
            Hero Ivan = new Hero(70, 6, 8, "Gummigeden Ivan");
            Hero Egon = new Hero(90, randomizer.Next(5, 8), 4, "Elgen Egon");

            // Creating a list of all the contenders
            List<Hero> contenderList = new List<Hero>();
            {
                // I then add the objects that I have instantiated to the list
                contenderList.Add(Harry);
                contenderList.Add(Dino);
                contenderList.Add(Karl);
                contenderList.Add(Gunner);
                contenderList.Add(Mikkel);
                contenderList.Add(Tiger);
                contenderList.Add(Ivan);
                contenderList.Add(Egon);
            }


            // I am now running the StartRound method and using the Hero objects I put into the contenderList as parameters
            // The winner of the StartRound method will then be added to the semiFinalList
            StartRound(contenderList[0], contenderList[1]);
            StartRound(contenderList[2], contenderList[3]);
            StartRound(contenderList[4], contenderList[5]);
            StartRound(contenderList[6], contenderList[7]);

            // Loops through each object in the semiFinalList
            foreach (Hero hero in semiFinalList)
            {
                // And then displays their name
                Console.WriteLine("On to the next round: " + hero.HeroName);
            }

            // I then wanted to do the same but now with the semiFinalList, and then somehow add it to a final list
            // StartRound(semiFinalList[0], semiFinalList[1]);
            // StartRound(semiFinalList[2], semiFinalList[3]);
            // but the only way I could think of was to make a new method that would do the same but with a different list
            // but I chose not to because 1. I didn't have enough remaining time & 2. there would have to be a much more practical way

        }
    }
}