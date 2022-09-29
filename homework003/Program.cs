// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
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
    var array = new int[lines, columns];
    for (var i = 0; i < array.GetLength(0); i++)
    {
        for (var j = 0; j < array.GetLength(1); j++)
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

int[,] MultiplicationArray(int[,] arrayA, int[,] arrayB)
{
    int[,] arrayC = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            for (int k = 0; k < arrayB.GetLength(0); k++)
            {
                arrayC[i,j] += arrayA[i,k] * arrayB[k,j];
            }
        }
    }
    return arrayC;
}

void PrintMultiplicationArray(int[,] arrayC)
{
    System.Console.WriteLine("Произведение матриц = ");
    for (int i = 0; i < arrayC.GetLength(0); i++)
    {
        for (int j = 0; j < arrayC.GetLength(1); j++)
        {
            System.Console.Write($"{arrayC[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

void Check(int[,] arrayA, int[,] arrayB)
{
    if (arrayA.GetLength(1) != arrayB.GetLength(0)) 
    {
        System.Console.WriteLine("Матрицы нельзя перемножить");
    }
    else PrintMultiplicationArray(MultiplicationArray(arrayA, arrayB));
}

var lines = Prompt("Введите количество строк матрицы А -> ");
var columns = Prompt("Введите количество столбцов матрицы А-> ");
var lines2 = Prompt("Введите количество строк матрицы B -> ");
var columns2 = Prompt("Введите количество столбцов матрицы B -> ");
System.Console.WriteLine();
var arrayA = GenerateArray(lines, columns);
System.Console.WriteLine();
var arrayB = GenerateArray(lines2, columns2);
PrintArray(arrayA);
System.Console.WriteLine();
PrintArray(arrayB);
System.Console.WriteLine();
Check(arrayA, arrayB);