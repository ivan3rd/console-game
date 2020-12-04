using System;

namespace Console_game
{
    
    class Fighter {
        private string name;
        private string fighterClass;
        private bool isCntrlByAI;
        private int health;
        private string[] inventory;
        
        private int attack;
        public void GetInfo(){
            Console.WriteLine($"Name: {name},\nclass: {fighterClass},\nControled by AI: {isCntrlByAI},");
            Console.WriteLine($"Health: {health}");
        }
        public bool FighterDied(){
            if(this.health<=0){
                Console.WriteLine($"{this.name} has fallen");
                return true;
            }
            return false;
        }
        public int DealDamage(){
            return this.attack;
        }
        public void DamageCount(bool DidItHit, int attack){
            if(!FighterDied()){
            if(DidItHit==true){
                this.health-=attack;
                Console.WriteLine($"{this.name} took damage!");
            }else{Console.WriteLine($"{this.name} doged with grace");}
            Console.WriteLine($"{this.name}, now have {this.health}");
            }else{Console.WriteLine("STOP! STOP!!! HE'S ALREADY DEAD!");}
        }
        public string ChooseDefence(){
            Random rng= new Random();
            int choise = rng.Next(1,3);
            switch(choise){
                case 1:
                    Console.WriteLine("against scisors");
                    return "scisors";
                case 2:
                    Console.WriteLine("against rock");
                    return "rock";
                case 3:
                    Console.WriteLine("against paper");
                    return "paper";
                default:
                    Console.WriteLine("choise of AI where "+choise);
                    return "scisors";
            }
        }
        public Fighter(string name,string fighterClass){
            this.name = name;
            this.fighterClass = fighterClass;
            this.isCntrlByAI = true;
            this.health = 100;
            this.inventory = new string[] {"sword","shield","socks"};
            this.attack = 10;
        }
        public Fighter(string name,string fighterClass,bool isCntrlByAI){
            this.name = name;
            this.fighterClass = fighterClass;
            this.isCntrlByAI = isCntrlByAI;
            this.health = 100;
            this.inventory = new string[] {"sword","shield","socks"};
            this.attack = 10;
        }
    }
    class Program
    {
        
        static bool comperResults(string Attack, string Defence){
            if(Attack=="paper"&&Defence=="rock")
                return true;
            if(Attack=="scisors"&&Defence=="paper")
                return true;
            if(Attack=="rock"&&Defence=="scisors")
                return true;
            else return false;
        }
        static void Attack(Fighter attacker,Fighter target){
            bool didItHit=false;
            string type = Console.ReadLine();

            
            switch(type){
                case "1":
                    Console.Write("You choose paper ");
                    didItHit=comperResults("paper",target.ChooseDefence());
                    break;
                case "2":
                    Console.Write("You choose scisors ");
                    didItHit=comperResults("scisors",target.ChooseDefence());
                    break;
                case "3":
                    Console.Write("You choose rock ");
                    didItHit=comperResults("rock",target.ChooseDefence());
                    break;
            }
            target.DamageCount(didItHit, attacker.DealDamage());
            if(!target.FighterDied())
                Attack(attacker,target);
        }
        static void Main(string[] args)
        {
            Fighter opponent = new Fighter("JHON CENA","Invisible cunt");
            Fighter player = new Fighter("COVID-19","Deadly virus",false);
            opponent.GetInfo();
            
            Attack(player,opponent);
        }
    }
}
