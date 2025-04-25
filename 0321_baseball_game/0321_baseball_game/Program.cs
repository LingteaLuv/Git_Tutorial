namespace _0321_baseball_game
{
    internal class Program
    {

        public static void Start(out int[] array)
        {
            Random number = new Random();
            int[] arrayGen = new int[9];
            array = new int[4];

            for (int i = 0; i < arrayGen.Length; i++)
            {
                arrayGen[i] = i + 1;
            }
            for (int i = 0; i < arrayGen.Length; i++)
            {
                int a = number.Next(i + 1, 10);
                int temp = arrayGen[a - 1];
                arrayGen[a - 1] = arrayGen[i];
                arrayGen[i] = temp;
            }
            for (int i = 0; i < 4; i++)
            {
                array[i] = arrayGen[i];
            }

            Console.Write("랜덤으로 생성된 4자리 숫자 : ");

            foreach (int a in array)
            {
                Console.Write(a);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] array;
            int[] inputArray = new int[4];
            bool gameOver = false;
            int count = 1;

            Start(out array);

            while (gameOver == false)
            {
                inputArray = Input(ref count);
                Update(array, inputArray, ref gameOver, count);
            }

            End(count, array, inputArray);
        }

        public static int[] Input(ref int count)
        {
            Console.WriteLine($"\n----------{count++}번째 기회 입니다----------");
            Console.Write("4자리 숫자를 입력해주세요 : ");
            int input = int.Parse(Console.ReadLine());
            List<int> inputList = new List<int>();
            while (input != 0)
            {
                inputList.Add(input % 10);
                input /= 10;
            }
            inputList.Reverse();
            return inputList.ToArray();
        }

        public static void Update(int[] array, int[] inputArray, ref bool gameOver, int count)
        {
            int strike = 0;
            int ball = 0;
            for (int i = 0; i < 4; i++)
            {
                if (array[i] == inputArray[i])
                {
                    strike++;
                }
                else
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (array[i] == inputArray[j])
                        {
                            ball++;
                        }
                    }
                }
            }
            if (strike == 4)
            {
                Console.WriteLine("Home Run!");
            }
            else if (strike == 0 && ball == 0)
            {
                Console.WriteLine("Out!");
            }
            else
            {
                Console.WriteLine($"Strike : {strike} Ball : {ball}");
            }

            gameOver = IsCorrect(array, inputArray, count);
        }

        public static bool IsCorrect(int[] array, int[] inputArray, int count)
        {
            return array.SequenceEqual(inputArray) || count == 11 ? true : false;
        }

        public static void End(int count, int[] array, int[] inputArray)
        {
            if (array.SequenceEqual(inputArray))
            {
                Console.WriteLine("승리했습니다!");
            }
            else
            {
                Console.WriteLine("기회를 모두 사용하였습니다. GameOver~");
            }
        }
    }
}

