// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке 
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка


int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],4}, ");
            else Console.Write($"{matrix[i, j],4}");
        }
        Console.WriteLine("  |");
    }
}

int[] FindSumInRows(int[,] matrix)
{
    int[] findSum = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            findSum[i] += matrix[i, j];
        }
    }
    return findSum;
}

void FindRowWithMinSum(int[] sum)
{
    int min = sum[0];
    int index = 0;
    for (int i = 0; i < sum.Length; i++)
    {
        if (sum[i] < min)
        {
            min = sum[i];
            index = i;
        }
    }
    Console.WriteLine($"Минимальная сумма в строке {index+1}");
}

int[,] array2D = CreateMatrixRndInt(3, 4, 0, 9);
PrintMatrix(array2D);
int[] sumsInRows = FindSumInRows(array2D);
FindRowWithMinSum(sumsInRows);
