class Program
{
    private static readonly string[] excludedWords = { "the", "a", "an", "and", "or", "but" };
    private static Dictionary<string, int> wordAndCountPairs = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (!excludedWords.Contains(word, StringComparer.InvariantCultureIgnoreCase))
            {
                if (wordAndCountPairs.ContainsKey(word))
                {
                    wordAndCountPairs[word]++;
                }
                else
                {
                    wordAndCountPairs[word.ToLower()] = 1;
                }
            }
        }

        var sortedWordAndCountPairs = wordAndCountPairs.OrderByDescending(pair => pair.Value);

        foreach (var pair in sortedWordAndCountPairs)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value}");
        }
    }
}