using System.Collections.Concurrent;

namespace SimCorp.Tests
{
    public class TestSimCorp
    {
        [Fact]
        public void CountWordsInFiles_ShouldReturnCorrectWordCounts()
        {
            var wordCounter = new WordCounter();
            string testFolderPath = @"C:\Users\Warda\Desktop\Files";

            var result = wordCounter.CountWordCountsInFiles(testFolderPath);

            Assert.Equal(1, result["so"]);
            Assert.Equal(2, result["do"]);
        }

        [Fact]
        public void PrintWordCounts_ShouldPrintCorrectly()
        {
            var wordCounter = new WordCounter();
            var wordCounts = new ConcurrentDictionary<string, int>
            {
                ["Test1"] = 1,
                ["Test2"] = 2
            };

            string output;
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                wordCounter.PrintWordCounts(wordCounts);
                output = writer.ToString();
            }

            Assert.Contains("1: Test1", output);
            Assert.Contains("2: Test2", output);
        }
    }
}