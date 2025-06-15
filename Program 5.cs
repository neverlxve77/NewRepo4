using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FileReader
{
    public static char[,] ReadFileToArray(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        int rows = lines.Length;
        int maxCols = lines.Max(line => line.Length);
        char[,] result = new char[rows, maxCols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                result[i, j] = lines[i][j];
            }
        }

        return result;
    }

    static void Main()
    {
        string filePath = @"C:\Users\timofei\Desktop\text.txt";
        char[,] contentArray = ReadFileToArray(filePath);

        for (int i = 0; i < contentArray.GetLength(0); i++)
        {
            for (int j = 0; j < contentArray.GetLength(1); j++)
            {
                if (j >= contentArray.GetLength(1) || contentArray[i, j] == '\0')
                    continue;

                Console.Write(contentArray[i, j]);
            }
            Console.WriteLine();
        }
    }
}