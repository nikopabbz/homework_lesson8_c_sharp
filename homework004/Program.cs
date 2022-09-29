// Задача 4: * Напишите программу, которая заполнит спирально квадратный массив. 
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

int[,] SpiralInput(int size)
{
    int[,] array = new int[size, size];
    int row = 0, col = 0, dx = 1, dy = 0, dirChanges = 0, gran = size;
    for (int i = 0; i < array.Length; i++)
    {
        array[col, row] = i + 1;
        if (--gran == 0)
        {
            gran = size * (dirChanges % 2) + size * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;
            int temp = dx;
            dx = -dy;
            dy = temp;
            dirChanges++;
        }
        col += dx;
        row += dy;
    }
    return array;
}


void PrintSpiralArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int size = Prompt("Введите размер массива -> ");
System.Console.WriteLine();
int[,] spiralarray = SpiralInput(size);
System.Console.WriteLine();
PrintSpiralArray(spiralarray);
