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
            OtherCollections();

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
    }
}
