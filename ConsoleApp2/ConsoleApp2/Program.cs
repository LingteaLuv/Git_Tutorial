namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int intarr = int.Parse(str);

            bool change = int.TryParse(str, out intarr);
            Console.WriteLine(change);

            Console.WriteLine(intarr);
            //foreach(int a in intarr)
            //{
            //    Console.Write(a);
            //}
        }
    }
}
