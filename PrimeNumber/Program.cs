using System;
using Humanizer;

namespace PrimeNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int val;
            while (int.TryParse(Console.ReadLine(), out val)){
                string prime = null;
                try
                {
                    prime = isPrime(val) ? "Prime." : "not Prime.";
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (prime != null) {
                    Console.WriteLine("The number " + val.ToWords() + " is " + prime);
                }
            }
        }

        public static bool isPrime(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Parameter 'num' cannot be less than 0");
            }
            else if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
