namespace Utilities;

public class StringUtilities
{
    public static int ToWords(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;


        string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


        HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);


        foreach (string word in words)
        {
            uniqueWords.Add(word);
        }


        return uniqueWords.Count;
    }
}

    }