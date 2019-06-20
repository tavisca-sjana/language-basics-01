using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            string [] num1 = equation.Split('*');
            string [] num2 = num1[1].Split('=');
            string num3 = num2[1];
            var operand1 = 0;
            var operand2 = 0;
            var result = 0;
            var temp = 0;
            
            if(num1[0].Contains("?"))
            {
                operand2 = Int32.Parse(num2[0]);
                result = Int32.Parse(num3);
                temp = result/operand2;
            
                if(result%operand2 == 0)
                    return FindMissingDigit(num1[0],temp);
                return -1;
            }

            else if(num2[0].Contains("?"))
            {
                operand1 = Int32.Parse(num1[0]);
                result = Int32.Parse(num3);
                temp = result/operand1;
            
                if(result%operand1 == 0)
                    return FindMissingDigit(num2[0],temp);
                return -1;
            }

            else
            {
                operand1 = Int32.Parse(num1[0]);
                operand2 = Int32.Parse(num2[0]);
                temp = operand1*operand2;
                
                return FindMissingDigit(num3,temp);
            }
        }

        //Function to find the missing corresponding digit from the number
        public static int FindMissingDigit(string num,int temp)
        {
            //Locates the position of ? in string
            int positionInString = 0;
            //Keeps track the position corresponding to ? of digit 
            int positionInNumber = 0;
            int rem;
            foreach(var letter in num)
            {
                if(letter == '?')
                {
                    break;
                }
                positionInString += 1;
            }

            //Find the position of ? from the end of string
            positionInString = num.Length-1-positionInString;


            while(temp>0)
            {
                rem = temp%10;
                if(positionInString == positionInNumber)
                {
                    return rem;
                }
                positionInNumber += 1;
                temp /= 10;
            }
            return -1;

        }
    }
}
