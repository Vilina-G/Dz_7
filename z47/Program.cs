Console.WriteLine(
            "Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
var numbers = GetEnteredNumbers("Введите число строк и число колонок : ", true);
Console.WriteLine();
if (numbers[0] != 0 && numbers[1] != 0)
{
    double[,] doubleArray = GenerateDoubleArray(numbers[0], numbers[1]);
    PrintDoubleTable(doubleArray);
}
else
{
    Console.WriteLine("Заданные числа =^_^= ");
}

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
