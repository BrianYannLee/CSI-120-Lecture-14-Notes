
//Programmer: Brian Lee
//Date: 05/30/2024

//Title: CSI 120 Lecture 14 Notes
//-------------------------------------------------------------------------------

using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Channels;

//----------------------------------------------------------------------------
namespace CSI_120_Lecture_14_Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitProgram = false;

            do
            {
                MenuSelection.MainMenu();
            } while (!exitProgram);

        }//end of Main
    }//end of Program (class)
    public class InputChecker
    {
        public static int MenuChecker(int firstChoice, int lastChoice)
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < firstChoice || userInput > lastChoice)
            {
                Console.WriteLine("Inalid Input. Try Again.");
            }
            Console.WriteLine();
            return userInput;
        }//end of MenuChecker(method)
        public static int IntChecker()
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            return userInput;
        }//end of IntChecker(method)
        public static double DoubleChecker()
        {
            double userInput;
            while (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            return userInput;
        }//end of DoubleChecker(method)
        public static string StringChecker()
        {
            string? userInput;
            string pattern = @"^[a-zA-Z]+$";

            while ((userInput = Console.ReadLine()) != null && Regex.IsMatch(userInput, pattern))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            return userInput ?? string.Empty;
        }//end of StringChecker(method)

    }//end of InputChecker(class)
    public class MenuSelection
    {
        public static bool MainMenu()
        {
            const int firstChoice = 1;
            const int lastChoice = 4;
            int userInput;
            bool exitProgram = false;

            Console.WriteLine("Please Select Method");
            Console.WriteLine("1. Display Numbers in Rows");
            Console.WriteLine("2. Generate a 2D Array");
            Console.WriteLine("3. Print Diagonal");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            userInput = InputChecker.MenuChecker(firstChoice, lastChoice);

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("Display Numbers in Rows");
                    Console.WriteLine("-------------------");
                    MethodList.DisplayNumbers();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Generate a 2D Array");
                    Console.WriteLine("-------------------");
                    MethodList.GenerateArray();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Print Diagonal");
                    Console.WriteLine("-------------------");
                    MethodList.PrintDiagonal();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Exiting Program");
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("An Error has occured in MainMenu");
                    break;
            }
            return exitProgram;
        }//end of MainMenu(method)

    }//end of MenuSelection(class)
    public class MethodList
    {
        public static void DisplayNumbers()
        {
            int x = 5, y = 10;

            for (int i = 0; i < x ; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }//end of DisplayNumber(method)
        public static void GenerateArray()
        {
            int x = 5, y = 10;
            Random rand = new Random();

            int[,] matrix = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = rand.Next(0, 10);
                }
            }
            PrintArray(matrix);
        }//end of GenerateArray(method)
        public static void PrintArray(int[,] matrix)
        {
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            Console.WriteLine("The Matrix is");

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }//end of PrintArray(method)
        public static void PrintDiagonal()
        {
            int x = 5;
            int y = 5;
            Random rand = new Random();

            int[,] matrix = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = rand.Next(0, 10);
                }
            }
            PrintArray(matrix);
            Console.WriteLine();
            Console.WriteLine("The Diagonal is");
            for (int i = 0; i < x; i++)
            {
                Console.Write($"{matrix[i,i]} ");
            }
        }//end of PrintDiagonal(method)
    }//end of MethodList(class)
}
