
using System.Text.RegularExpressions;
        
class Reference
{
    private List<Word> words = new List<Word>();
    private List<char> punctuation = new List<char>{'(', '?', '<', '=', '[', '.', ',', ';', ']', ')', '!', '-', ':', ' '};
    private int realWordCount = 0; // Does not include punctuation
    public Reference(string text)
    {
        List<string> parts = new List<string>();
        string pattern = @"\w+|[^\w\s]| "; // \w+: One or more word characters (letters, digits, underscore), [^\w\s]: Any character that is not a word character or a whitespace character (i.e., punctuation)., : Space character.
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            parts.Add(match.Value);
        }
        foreach (string part in parts)
        {
            Word word = new Word(part);
            words.Add(word);
            if (!punctuation.Contains(text[0]))
            {
                realWordCount+=1;
            }
        }
    }
    
    public void HideWords(int number)
    {
        int hideNumber = 0;
        List<int> nonHiddenWordIndexes = new List<int>();
        for (int i = 0; i < words.Count(); i++)
        {
            if (!words[i].GetIsHidden())
            {
                nonHiddenWordIndexes.Add(i);
            }
        }
        if (nonHiddenWordIndexes.Count==0)
        {
            Console.WriteLine("Congratulations on memorizing a new scripture! Feel free to select another scripture to continue your scripture memorization journey!");
            Environment.Exit(1);
        }
        else if (nonHiddenWordIndexes.Count>= number)
        {
            hideNumber = number;
        }
        else
        {
            hideNumber = nonHiddenWordIndexes.Count;
        }
        for (int i = 0; i < hideNumber; i++)
        {
            Random rand = new Random();
            int index = rand.Next(nonHiddenWordIndexes.Count);
            Word word = words[nonHiddenWordIndexes[index]];
            nonHiddenWordIndexes.RemoveAt(index);
            word.Hide();
        }
    }

    public void HideFirstLetters()
    {
        foreach (Word word in words)
        {
            word.HideFirstLetter();
        }
    }

    public void ShowWords()
    {
        foreach (Word word in words)
        {
            word.Show();
        }
    }

    public int GetRealWordCount()
    {
        return realWordCount;
    }
}