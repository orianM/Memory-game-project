using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_game_project
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix;
            int matrixSize;
            while (true)
            {
                Console.WriteLine("Please enter an positive even number less than 8");
                matrixSize = int.Parse(Console.ReadLine());
                if (matrixSize <= 8 && matrixSize % 2 == 0 && matrixSize > 0)
                {
                    matrix = CreateMatrix(matrixSize);
                    break;
                }
            }
            int numberOfPairs = matrix.Length / 2;

            Random randomNum = new Random();
            for (int i = 1; i <= numberOfPairs; i++)
            {
                int counter = 0;

                while (counter < 2)
                {
                    int row = randomNum.Next(0, matrix.GetLength(0));
                    int column = randomNum.Next(0, matrix.GetLength(1));

                    if (matrix[row, column] == 0)
                    {
                        matrix[row, column] = i;
                    }
                    else continue;
                    counter++;
                }
            }

            PrintMatrix(matrix);
            int points = 0;
            while (true)
            {
                int row1 = 0;
                int column1 = 0;
                int row2 = 0;
                int column2 = 0;
                while (points != numberOfPairs)
                {
                    Console.WriteLine("Choose 1st card row(zero based)");
                    row1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Choose 1st card column(zero based)");
                    column1 = int.Parse(Console.ReadLine());

                    if (CheckInRange(row1, column1, matrixSize, matrix) && matrix[row1, column1] != 0)
                    {
                        Console.WriteLine($"Your 1st card is: {matrix[row1, column1]}");

                        Console.WriteLine("Choose 2st card row(zero based)");
                        row2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Choose 2st card column(zero based)");
                        column2 = int.Parse(Console.ReadLine());

                        if (CheckInRange(row2, column2, matrixSize, matrix) && matrix[row2, column2] != 0)
                        {
                            Console.WriteLine($"Your 2nd card is: {matrix[row2, column2]}");

                            if (CheckIfMatching(row1, column1, row2, column2, matrix))
                            {
                                matrix[row1, column1] = 0;
                                matrix[row2, column2] = 0;

                                points++;
                            }
                        }
                        else
                        {
                            Console.WriteLine();

                            Console.WriteLine("Chosen card is out of range or already found, try again.");

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("Chosen card is out of range or already found, try again.");

                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("You win!");
                break;
            }
        }

        public static int[,] CreateMatrix(int myMatrix)
        {
            int[,] createMatrix = new int[myMatrix, myMatrix];
            return createMatrix;
        }

        public static void PrintMatrix(int[,] matrixToPrint)
        {
            for (int i = 0; i < matrixToPrint.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrixToPrint.GetLength(1); j++)
                {
                    Console.Write("x" + "\t");
                }
                Console.WriteLine();
            }
        }

        public static bool CheckInRange(int rowOfMatrix, int columnOfMatrix, int sizeOfMatrix, int[,] matrikCheckFor)
        {
            if (rowOfMatrix == sizeOfMatrix || rowOfMatrix < 0 || rowOfMatrix > sizeOfMatrix)
            {
                return false;
            }
            else if (columnOfMatrix == sizeOfMatrix || columnOfMatrix < 0 || columnOfMatrix > sizeOfMatrix)
            {
                return false;
            }
            else
                return true;
        }

        public static bool CheckIfMatching(int firstRow, int firstColumn, int secondRow, int secondColumn, int[,] theMatrix)
        {
            if (theMatrix[firstRow, firstColumn] == theMatrix[secondRow, secondColumn])
            {
                return true;
            }
            else
                return false;
        }
    }
}
