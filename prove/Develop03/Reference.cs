
using System.Text.RegularExpressions;
        
class Reference
{
    private List<Word> words = new List<Word>();
    private List<char> punctuation = new List<char>{'(', '?', '<', '=', '[', '.', ',', ';', ']', ')', '!', '-', ':', ' '};
    private int realWordCount = 0; // Does not include punctuation
    List<int> nonHiddenWordIndexes = new List<int>();
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
    
    public List<int> GetNonHiddenWords() // returns the indexes of the words that are not hidden
    {
        nonHiddenWordIndexes.Clear(); // removes all items from the list
        for (int i = 0; i < words.Count; i++)
        {
            if (!words[i].GetIsHidden())
            {
                nonHiddenWordIndexes.Add(i);
            }
        }
        return nonHiddenWordIndexes;
    }

    public int HideWords(int number)
    {
        int hideNumber;
        nonHiddenWordIndexes = GetNonHiddenWords();
        if (nonHiddenWordIndexes.Count==0)
        {
            return 0;
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
        return nonHiddenWordIndexes.Count;
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