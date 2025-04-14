WordCounter wordCounter = new WordCounter();
var words = wordCounter.CountWordCountsInFiles(@"C:\Users\Warda\Desktop\Files"); // Enter the path to your folder with txt files
wordCounter.PrintWordCounts(words);