// Задача 2: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
int Prompt(string msg)
{
    Console.Write(msg);
    bool count = int.TryParse(Console.ReadLine(), out int number);
    if (count)
    {
        return number;
    }
    throw new Exception("Вы ввели не число");
}

int[,] GenerateArray(int lines, int columns)
{
    int[,] array = new int[lines, columns];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1, 10);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

int[] SumLines(int[,] array)
{

    int[] sumlines = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i, j];
        }
        sumlines[i] = sum;
    }
    return sumlines;
}

void PrintSumLines(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.WriteLine($"Сумма элементов {i + 1} строки = {array[i]}");
    }
}

int FindStringMinSum(int[] array)
{
    int min = array[0];
    int index = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] < min)
        {
            min = array[i];
            index = i;
        }
    }
    return index;
}

int[] StringMinSum(int[,] array, int index)
{
    int[] temparray = new int[array.GetLength(1)];
    for (int j = 0; j < array.GetLength(1); j++)
    {
        temparray[j] = array[index, j];
    }
    return temparray;
}

void PrintStringMinSum(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.Write($"{array[i]}\t");
    }
}

int lines = Prompt("Введите количество строк -> ");
int columns = Prompt("Введите количество столбцов -> ");
int[,] array = GenerateArray(lines, columns);
PrintArray(array);
System.Console.WriteLine();
PrintSumLines(SumLines(array));
int index = FindStringMinSum(SumLines(array));
System.Console.WriteLine();
System.Console.WriteLine($"Строка {index + 1} имеет наименьшую сумму элементов");
PrintStringMinSum(StringMinSum(array, index));


