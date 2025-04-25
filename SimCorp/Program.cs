using System.Collections.Concurrent;

WordCounter wordCounter = new WordCounter();

Console.WriteLine("Enter the path to your folder with txt files, for example: C:\\Users\\UserName\\Desktop\\Files ");
string folderPath = Console.ReadLine();

if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
{
    Console.WriteLine("Invalid path. Please enter a valid folder path.");
    return;
}

try
{
    var txtFiles = Directory.EnumerateFiles(folderPath, "*.txt");
    if (!txtFiles.Any())
    {
        Console.WriteLine("The specified folder does not contain any .txt files.");
        return;
    }

    ConcurrentDictionary<string, int> wordCounts = wordCounter.CountWordCountsInFiles(folderPath);
    wordCounter.PrintWordCounts(wordCounts);
}
catch (DirectoryNotFoundException)
{
    Console.WriteLine("The specified directory was not found. Please check the path and try again.");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("You do not have permission to access one or more files in the specified directory.");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}