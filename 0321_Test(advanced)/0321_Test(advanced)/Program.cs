using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;

namespace _0321_Test_advanced_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //문제 1번 주어진 문자열에서 특정 문자의 위치를 찾는 함수
            Console.Write("문자열 입력 : ");
            string text = Console.ReadLine();
            Console.Write("확인할 문자 입력 : ");
            char key = char.Parse(Console.ReadLine());

            Console.WriteLine(FindKeyIndex(text, key));

            //문제 2번 소수인지 아닌지 판별하는 함수
            Console.Write("숫자 입력 : ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(IsPrime(number));

            //문제 3번 각 자리 수의 합을 구하는 함수
            Console.Write("숫자 입력 : ");
            int number1 = int.Parse(Console.ReadLine());
            SumOfDigits(number1);

            //문제 4번 주어진 두 배열의 공통항목을 찾는 함수
            Console.Write("배열1 입력 : ");
            string[] strarray1 = Console.ReadLine().Split(' ');
            int[] array1 = new int[strarray1.Length];
            for (int i = 0; i < strarray1.Length; i++)
            {
                array1[i] = int.Parse(strarray1[i]);
            }
            Console.Write("배열2 입력 : ");
            string[] strarray2 = Console.ReadLine().Split(' ');
            int[] array2 = new int[strarray2.Length];
            for (int i = 0; i < strarray2.Length; i++)
            {
                array2[i] = int.Parse(strarray2[i]);
            }
            Console.Write("{ ");
            foreach (int a in Best(array1, array2))
            {
                Console.Write($"{a}, ");
            }
            Console.Write("\b\b }");

            //문제 5번 주어진 숫자와 가장 가까운 수를 구하는 함수
            Console.Write("배열 입력 : ");
            string[] strarray3 = Console.ReadLine().Split(' ');
            int[] array3 = new int[strarray3.Length];
            for (int i = 0; i < strarray3.Length; i++)
            {
                array3[i] = int.Parse(strarray3[i]);
            }
            Console.Write("숫자 입력 : ");
            int number3 = int.Parse(Console.ReadLine());
            Console.WriteLine(Close(array3, number3));

            //문제 6번 주어진 배열에서 가장 많이 나타나는 숫자를 구하는 함수
            Console.Write("배열 입력 : ");
            string[] strarray4 = Console.ReadLine().Split(' ');
            int[] array4 = new int[strarray4.Length];
            for (int i = 0; i < strarray4.Length; i++)
            {
                array4[i] = int.Parse(strarray4[i]);
            }
            Console.WriteLine(ModeNum(array4));


        }
        public static int FindKeyIndex(string text, char key)
        {
            int count = 0;

            foreach (char a in text)
            {
                if(a == key)
                {
                    break;
                }
                count++;
            }
            if(count == text.Length)
            {
                count = -1;
            }
            return count;
        }
        
        public static bool IsPrime(int number)
        {
            for(int i =2; i<number; i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int SumOfDigits(int number)
        {
            int sum = 0;
            if(number == 0)
            {
                sum += number % 10;
                number /= 10; 
            }
            return sum;
        }

        public static int[] Best(int[] array1, int[] array2)
        {
            List<int> list = new List<int>();
            for(int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    if (array1[i] == array2[j])
                    {
                        list.Add(array1[i]);
                        break;
                    }   
                }
            }        
            for(int i =0; i<list.Count; i++)
            {
                for(int j = i + 1; j< list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        list.RemoveAt(j);
                    }
                }
            }
            return list.ToArray();
        }

        public static int Close(int[] array, int number)
        {
            List<int> list = new List<int>();
            int differ;
            for (int i = 0; i < array.Length; i++)
            {               
                if(array[i] - number >= 0) 
                {
                    differ = array[i] - number;
                    list.Add(differ);
                }
                else
                {
                    differ = number - array[i];
                    list.Add(differ);
                }                   
            }
            return array[list.IndexOf(list.Min())];
        }

        public static int ModeNum(int[] array)
        {
            int mode = 0;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        temp++;
                    }
                }
                if (temp > count)
                {
                    count = temp;
                    mode = array[i];
                }
            }
            return mode;    
        }

        

    }
}
