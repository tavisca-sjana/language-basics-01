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
            string firstOperand = equation.Split('*')[0];
            string secondOperand = equation.Split('*')[1].Split('=')[0];
            string resultOperand = equation.Split('=')[1];
            var operand1 = 0;
            var operand2 = 0;
            var result = 0;
            var tempResult = 0;
            
            if(firstOperand.Contains("?"))
            {
                operand2 = Int32.Parse(secondOperand);
                result = Int32.Parse(resultOperand);
                tempResult = result/operand2;
            
                if(result%operand2 == 0)
                    return FindPositionOfMissingDigit(firstOperand,tempResult);
                return -1;
            }

            else if(secondOperand.Contains("?"))
            {
                operand1 = Int32.Parse(firstOperand);
                result = Int32.Parse(resultOperand);
                tempResult = result/operand1;
            
                if(result%operand1 == 0)
                    return FindPositionOfMissingDigit(secondOperand,tempResult);
                return -1;
            }

            else
            {
                operand1 = Int32.Parse(firstOperand);
                operand2 = Int32.Parse(secondOperand);
                tempResult = operand1*operand2;
                
                return FindPositionOfMissingDigit(resultOperand,tempResult);
            }
        }

        //Function to find the missing corresponding digit from the number
        public static int FindPositionOfMissingDigit(string num,int temp)
        {
            //Locates the position of ? in string
            int positionOfMissingDigitInString = 0;
            //Keeps track the position corresponding to ? of digit 
            int positionOfMissingDigitInNumber = 0;
            int rem;
            foreach(var letter in num)
            {
                if(letter == '?')
                {
                    break;
                }
                positionOfMissingDigitInString += 1;
            }

            //Find the position of ? from the end of string
            positionOfMissingDigitInString = num.Length-1-positionOfMissingDigitInString;


            while(temp>0)
            {
                rem = temp%10;
                if(positionOfMissingDigitInString == positionOfMissingDigitInNumber)
                {
                    return rem;
                }
                positionOfMissingDigitInNumber += 1;
                temp /= 10;
            }
            return -1;

        }
    }
}
