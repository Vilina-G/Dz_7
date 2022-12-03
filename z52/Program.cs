Console.WriteLine(
            "Задача 52. Задайте двумерный массив из целых чисел. " +
            "Найдите среднее арифметическое элементов в каждом столбце.");
var rowsCols = GetEnteredNumbers("Введите числа строк и столбцов для " +
                                         "генерации массива (пример 5, 9): ", true);
Console.WriteLine();
double[,] generatedTable;
if (rowsCols.Length == 2)
    generatedTable = GenerateDoubleArray(rowsCols[0], rowsCols[1], false, from: 1, to: 10);
else
    generatedTable = GenerateDoubleArray(9, 9, false, from: 1, to: 10);
PrintDoubleTable(generatedTable);
var average = GetArrayAverage(generatedTable);
Console.WriteLine();
Console.Write("Среднее арифметическое элементов в каждом столбце -> ");
PrintArrayDouble(average);
//     Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.


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

static double[] GetArrayAverage(double[,] arrayTable)
{
    double[] findedNumber = new double[arrayTable.GetLength(0)];
    for (int i = 0; i < arrayTable.GetLength(0); i++)
    {
        double sumElements = 0;
        for (int j = 0; j < arrayTable.GetLength(1); j++)
        {
            sumElements += arrayTable[i, j];
        }

        findedNumber[i] = sumElements / arrayTable.GetLength(1);
    }

    return findedNumber;
}
static void PrintArrayDouble(double[] array)
{
    foreach (var item in array)
    {
        Console.Write($"{String.Format("{0:0.#}", item)} ");
    }
}