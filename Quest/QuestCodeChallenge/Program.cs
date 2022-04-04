using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal resultData = 0;
            string error = "";
            string input = "";
            input = Console.ReadLine();

            while (input.Length > 0)
            {

                if (!MathCalculation.CheckUserInputs(input))
                {
                    Console.WriteLine("Please input valid Math Expression");
                }
                else
                {
                    resultData = MathCalculation.Calculate(input, out error);
                    if (error.Length > 0)
                    {
                        Console.WriteLine(error);
                    }
                    else
                    {
                        Console.WriteLine("=" + resultData.ToString());
                    }
                }
                input = Console.ReadLine();
            }

        }
    }
}
