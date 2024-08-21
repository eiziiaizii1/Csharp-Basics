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
            MultiD_Arrays();
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
    }
}
