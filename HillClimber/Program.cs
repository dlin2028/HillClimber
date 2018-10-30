using System;

namespace HillClimber
{
    class Program
    {
        static void Main(string[] args)
        {
            string target = Console.ReadLine();
            char[] current = new char[target.Length];
            int lastError = int.MaxValue;

            Random rnd = new Random();

            for (int i = 0; i < target.Length; i++)
            {
                current[i] += (char)rnd.Next(32, 126);
            }

            int error = 0;
            int mutation;
            while (target.ToCharArray() != current)
            {
                do
                {
                    mutation = rnd.Next(-1, 2);
                } while (mutation == 0);

                int index = rnd.Next(target.Length);
                
                current[index] = (char)(current[index] + mutation);
                if (current[index] < 32)
                {
                    current[index] = (char)126;
                }
                else if (current[index] > 126)
                {
                    current[index] = (char)32;
                }

                error = 0;
                for (int j = 0; j < current.Length; j++)
                {
                    error += Math.Abs(current[j] - target[j]);
                }

                if (error > lastError)
                {
                    current[index] = (char)(current[index] - mutation);
                    if (current[index] < 32)
                    {
                        current[index] = (char)126;
                    }
                    else if (current[index] > 126)
                    {
                        current[index] = (char)32;
                    }
                    error = lastError;
                }
                else
                {
                    lastError = error;
                }
                Console.WriteLine($"{new string(current)} error: {error}");
            }
        }
    }
}


