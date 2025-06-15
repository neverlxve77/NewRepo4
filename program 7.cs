using System;

class MultiplicationTable
{
    static void Main()
    {
        Console.WriteLine("=== Генератор таблицы умножения ===");

        // Ввод размера таблицы с проверкой
        int tableSize;
        do
        {
            Console.Write("Введите размер таблицы (например, 10): ");
        } while (!int.TryParse(Console.ReadLine(), out tableSize) || tableSize <= 0);

        Console.WriteLine($"\nТаблица умножения {tableSize}x{tableSize}:\n");

        // Вывод таблицы с фиксированным форматированием
        for (int i = 1; i <= tableSize; i++)
        {
            for (int j = 1; j <= tableSize; j++)
            {
                // Фиксированная ширина = 4 символа
                Console.Write($"{i * j,4}");
            }
            Console.WriteLine();
        }
    }
}