using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MatrixManipulator
{
    private int[,] matrix;

    public MatrixManipulator(int[,] matrix)
    {
        this.matrix = matrix;
    }

    public void SwapColumnsIfFirstGreaterThanSecond()
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, 0] > matrix[i, 1])
            {
                int temp = matrix[i, 0];
                matrix[i, 0] = matrix[i, 1];
                matrix[i, 1] = temp;
            }
        }
    }

    public void PrintMatrix()
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        int[,] matrix = {
            {5, 10},
            {15, 20},
            {25, 30},
            {35, 40},
            {45, 50}
        };

        MatrixManipulator manipulator = new MatrixManipulator(matrix);

        Console.WriteLine("Исходная матрица:");
        manipulator.PrintMatrix();

        manipulator.SwapColumnsIfFirstGreaterThanSecond();

        Console.WriteLine("\nМатрица после замены столбцов:");
        manipulator.PrintMatrix();
    }
}