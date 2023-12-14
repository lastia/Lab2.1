try
{
    /// <summary>
    /// Укажите путь к вашему текстовому файлу
    /// </summary>
    string filePath = "C:\\Users\\kkupr\\source\\repos\\лаба\\Lab2.1\\mat\\2.1.txt";

    /// Загрузка предложений из файла ///
    string[] sentences = LoadSentences(filePath);

    /// Проверка, достаточно ли предложений в файле ///
    if (sentences.Length >= 3)
    {
        /// Выбор первых трех предложений, их обратное упорядочивание и вывод ///
        var firstThreeSentences = sentences.Take(3).Reverse();

        Console.WriteLine("Первые три предложения в обратном порядке:");

        /// Вывод предложений ///
        foreach (var sentence in firstThreeSentences)
        {
            Console.WriteLine(sentence);
        }
    }
    else
    {
        Console.WriteLine("Файл содержит менее трех предложений. Задача не может быть выполнена.");
    }
}
/// Перехват ошибки ///
catch (Exception ex)
{
    Console.WriteLine($"Произошла ошибка: {ex.Message}");
}

/// <summary>
/// Загружает предложения из текстового файла.
/// </summary>
/// <param name="filePath">Путь к текстовому файлу.</param>
/// <returns>Массив строк, представляющих предложения.</returns>
static string[] LoadSentences(string filePath)
{
    /// Чтение строк из файла ///
    string[] lines = File.ReadAllLines(filePath);

    /// Разделение строк на предложения ///
    char[] separators = { '.', '!', '?' };
    var sentences = lines.SelectMany(line => line.Split(separators, StringSplitOptions.RemoveEmptyEntries));

    return sentences.Select(sentence => sentence.Trim()).ToArray();
}