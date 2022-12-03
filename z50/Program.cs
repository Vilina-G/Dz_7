Console.WriteLine(
            "Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве," +
            " и возвращает значение этого элемента или же указание, что такого элемента нет.");
var rowsCols = GetEnteredNumbers("Введите числа строк и столбцов " +
                                         "для генерации массива (пример 5, 9): ", true);
Console.WriteLine();
double[,] generatedTable;
if (rowsCols.Length == 2)
    generatedTable = GenerateDoubleArray(rowsCols[0], rowsCols[1], false);
else
    generatedTable = GenerateDoubleArray(9, 9, false);
PrintDoubleTable(generatedTable);
var enteredNumber = GetEnteredNumbers("Введите число для поиска по массиву :");
var findedElement = FindElement(generatedTable, enteredNumber[0]);
Console.WriteLine(findedElement);
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

static int[] GetEnteredNumbers(string outputText = "", bool inline = false)
{
    var arrayInts = Array.Empty<int>();
    if (inline)
        Console.Write(outputText);
    else
        Console.WriteLine(outputText);

    char[] separators = { ' ', ',' };
    var arrayOfEnteredText = Console.ReadLine()
        ?.Split(separators,
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    if (arrayOfEnteredText != null)
        arrayInts = Array.ConvertAll(arrayOfEnteredText, s => int.Parse(s));

    return arrayInts;
}

static double[,] GenerateDoubleArray(int m, int n, bool type = true, int from = -9, int to = 10)
{
    var tableArray = new double[m, n];
    var rand = new Random();
    double randomizedNumber;
    for (int i = 0; i < tableArray.GetLength(0); i++)
    {
        for (int j = 0; j < tableArray.GetLength(1); j++)
        {
            if (type)
            {
                randomizedNumber = rand.Next(from, to) +
                                   Math.Round(rand.NextDouble(), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                randomizedNumber = rand.Next(from, to);
            }

            tableArray[i, j] = randomizedNumber;
        }
    }

    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // tableArray = new double[,] { { 1, 4, 7, 2 }, { 5, 9, 2, 3 }, { 8, 4, 2, 4 } };

    return tableArray;
}


static void PrintDoubleTable(double[,] generatedTable)
{
    for (int i = 0; i < generatedTable.GetLength(0); i++)
    {
        for (int j = 0; j < generatedTable.GetLength(1); j++)
        {
            Console.Write($"{String.Format("{0:0.#}", generatedTable[i, j])} ");
        }

        Console.WriteLine();
    }
}

static string FindElement(double[,] arrayTable, double searched = 0)
{
    double findedNumber = 0;
    double findedCount = 0;
    for (int i = 0; i < arrayTable.GetLength(0); i++)
    {
        for (int j = 0; j < arrayTable.GetLength(1); j++)
        {
            // if (Math.Abs(arrayTable[i, j]) == Math.Abs(searched))
            if (arrayTable[i, j] == searched)
            {
                findedNumber = arrayTable[i, j];
                findedCount++;
            }
        }
    }

    return findedNumber != 0
        ? $"Найденное число: {findedNumber} -> найдено таких чисел {findedCount}"
        : $"{searched} -> такого числа в массиве нет";
}
