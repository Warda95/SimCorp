using System.Collections.Concurrent;
using System.Text.RegularExpressions;

public class WordCounter
{
    private readonly Regex _regex = new Regex(@"\W+");

    public WordCounter() { }

    public ConcurrentDictionary<string, int> CountWordCountsInFiles(string folderPath)
    {
        var wordCounts = new ConcurrentDictionary<string, int>(StringComparer.Ordinal);
        string[] files = Directory.GetFiles(folderPath, "*.txt");

        Parallel.ForEach(files, file =>
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] subStrings = _regex.Split(line);
                    foreach (var subString in subStrings)
                    {
                        if (subString.Length > 0)
                        {
                            wordCounts.AddOrUpdate(subString, 1, (key, count) => count + 1);
                        }
                    }
                }
            }
        });

        return wordCounts;
    }

    public void PrintWordCounts(ConcurrentDictionary<string, int> wordCounts)
    {
        if (wordCounts == null || wordCounts.IsEmpty)
        {
            Console.WriteLine("No words found.");
            return;
        }
        else
        {
            Console.WriteLine("Words count: ");
            foreach (var pair in wordCounts)
            {
                Console.WriteLine($"{pair.Value}: {pair.Key}");
            }
        }
    }
}