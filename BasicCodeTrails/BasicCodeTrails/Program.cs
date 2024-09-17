using System.Numerics;

namespace BasicCodeTrails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EnumCodes.EnumTest();
            //Console.WriteLine(PropertiesCodes.PlayerName);
            //PropertiesCodes.PlayerName = "mahmut";
            //Console.WriteLine(PropertiesCodes.PlayerName);
            //MultiD_Arrays();
            //Dictionaries();
            //OtherCollections();
            //ParamsTest();
            //OptionalParametersTest();
            //ClassTest();
            InterfaceTest();
        }

        static void MultiD_Arrays()
        {
            //Cannot be jagged array
            int[,] arr2D = new int[3, 5];
            Console.WriteLine(arr2D.Length);
            Console.WriteLine(arr2D.GetLength(0));

            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                for(int j = 0; j < arr2D.GetLength(1); j++){
                    Console.WriteLine($"{i}, {j}: {arr2D[i, j]}");
                }
            }

            Console.WriteLine("------------------------------------");
            // Can be jagged array
            int[][] arrMultiD = new int[5][];
            Console.WriteLine(arrMultiD.Length);
            Console.WriteLine(arrMultiD.GetLength(0));

            for (int i = 0; i < arrMultiD.GetLength(0); i++)
            {
                Console.WriteLine(arrMultiD[i] == null);
                arrMultiD[i] = new int[5];
            }
        }
        enum ResourceType
        {
            Stone,
            Wood,
            Gold
        }
        static void Dictionaries()
        {
            //Dictionary<ResourceType,int> resourceTypeAmount = new Dictionary<ResourceType,int>();
            Dictionary<ResourceType, int> resourceTypeAmount = new Dictionary<ResourceType, int>() 
            {   {ResourceType.Stone,123 },
                {ResourceType.Wood,456 },
                {ResourceType.Gold,13 },
            };

            foreach (KeyValuePair<ResourceType,int> pair in resourceTypeAmount)
            {
                Console.WriteLine($"Resource: {pair.Key}, Amount: {pair.Value}");
            }
            Console.WriteLine("------------------------------------------");
            foreach (ResourceType rType in resourceTypeAmount.Keys)
            {
                Console.WriteLine($"Resource: {rType}");
            }

            Console.WriteLine("------------------------");
            //resourceTypeAmount.Add(ResourceType.Gold, 31);
            Console.WriteLine(resourceTypeAmount[ResourceType.Gold]);
            //resourceTypeAmount.Add(ResourceType.Stone, 46354);

            if (resourceTypeAmount.TryGetValue(ResourceType.Stone, out int stoneAmount)) {
                Console.WriteLine(stoneAmount);
            }
            
            resourceTypeAmount.Remove(ResourceType.Gold);
        }
        static void OtherCollections()
        {
            Stack<string> animals = new Stack<string>();

            animals.Push("MONKEYYY");
            animals.Push("Cat");

            Console.WriteLine(animals.Pop());

            Queue<string> humans = new Queue<string>();
            humans.Enqueue("Trump");
            humans.Enqueue("Biden");
            Console.WriteLine(humans.Dequeue());

            HashSet<string> set1 = new HashSet<string>();

            set1.Add("a");
            set1.Add("a");
            Console.WriteLine(set1.Count);
        }
        static void ParamsTest()
        {
            ParameterCounter("a","b","c");

            static void ParameterCounter(params string[] names)
            {
                Console.WriteLine(names.Length);
            }
        }
        private enum AttackUnitType
        {
            Melee,
            Ranged
        }
        private static void SpawnAttackUnit(
            Vector3 spawnPosition = default, 
            AttackUnitType unitType = AttackUnitType.Melee, 
            Quaternion spawnRotation = default, 
            int healthAmount = 100)
        {
            Console.WriteLine($"Position {spawnPosition}\nRoatation:{spawnRotation}\nUnit Type:{unitType}\nHealth:{healthAmount}");
        }
        static void OptionalParametersTest()
        {
            SpawnAttackUnit();
            Console.WriteLine("-----------------------------------");
            SpawnAttackUnit(new Vector3(1, 2, 3), AttackUnitType.Ranged, Quaternion.Identity,85);
        }
        public abstract class Unit
        {
            protected float speed;
            public virtual void Move()
            {
                Console.WriteLine($"Unit is moving at {speed} m/s");
            }

            public abstract void Attack();

            ~Unit() //Derstructor
            { 
                Console.WriteLine("UNIT DESTRUCTED");
            } 
        }
        public class Player : Unit
        {
            private string playerName ;
            public Player(string playerName)
            {
                this.playerName = playerName;
                speed = 5;
            }

            public override void Move()
            {
                Console.WriteLine($"Player is moving at {speed} m/s");
            }

            public void BackFlip() { }

            public override string ToString()
            {
                return $"Player: {playerName}";
            }

            public override void Attack()
            {
            }
        }
        public class Enemy : Unit
        {
            public override void Attack()
            {
            }

            public override void Move()
            {
                Console.WriteLine($"ENEMY is moving at {speed} m/s");
            }
        }
        public sealed class a
        {

        }
        //public class b : a { }; //Sealed classes can't be extended
        public static void ClassTest()
        {
            //Unit unit = new Unit(); // Unit is abstract cannot be created
            Player player = new Player("MONKEEEEEEEEEEEEEE");
            Enemy enemy = new Enemy();

            Console.WriteLine(player.ToString());

            //unit.Move();
            player.Move();
            enemy.Move();

            Unit unit2 = player;
            unit2.Move();
            //unit2.BackFlip(); //NOT VALID

            List<Unit> list = new List<Unit>
            {
                player,
                enemy
            };
            
        }

        public interface IAttackable
        {
            //public int Health {  get; set; } // THIS IS VALID
            public void Damage();
            public void Arrest() {
                Console.WriteLine("arrest");
            }
        }
        
        public interface IMoveable { }
        public interface IHasInventory { }

        public class Soldier : IAttackable, IMoveable, IHasInventory
        {
            public void Damage()
            {
                Console.WriteLine("Soldier damage");
            }
        }

        public class Police : IAttackable, IMoveable
        {
            public void Damage()
            {
                Console.WriteLine("Police damage");
            }
            public void Arrest()
            {
                Console.WriteLine("Police arrest");
            }
        }

        public static void AttackObject(IAttackable attackable)
        {
            attackable.Damage();
        }

        public static void InterfaceTest()
        {
            IAttackable attackableS = new Soldier();
            IAttackable attackableP = new Police();
            attackableS.Damage();

            AttackObject(attackableS);
            AttackObject(attackableP);

            attackableS.Arrest();
            attackableP.Arrest();
        }

    }
}
