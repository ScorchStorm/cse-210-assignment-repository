
using System.Text.RegularExpressions;
        
class Reference
{
    private List<Word> words = new List<Word>();
    private List<char> punctuation = new List<char>{'(', '?', '<', '=', '[', '.', ',', ';', ']', ')', '!', '-', ':', ' '};
    private int realWordCount = 0; // Does not include punctuation
    public Reference(string text)
    {
        // string[] parts = Regex.Split(text, @"(?<=[.,;])!- "); // doesn't split
        // string[] parts = Regex.Split(text, @" "); // splits
        // string[] parts = Regex.Split(text, @" (?<=[.,;])!-"); // doesn't split
        // string[] parts = Regex.Split(text, @" ."); // confusing mixed results // parts = And, t, ame, o, ass, hat, ,, ephi,, aid, nto, y, ather:, 
        // string[] parts = Regex.Split(text, @" :"); // doesn't split
        // string pattern = @" (?<=[.,;])!-)"; //'Invalid pattern ' (?<=[.,;])!-)' at offset 14. Too many )'s.'
        // string pattern = @" ?<=[.,;]!-"; // doesn't split
        // string pattern = @" "; // splits
        // string pattern = @" ."; // parts = And, t, ame, o, ass, hat, ,, ephi,, aid, nto, y, ather:,
        // string pattern = @" .:";  // doesn't split
        // string pattern = @"( )|(?)|(<)|(=)|([)|(.)|(,)|(;)|(])|(!)|(-)"; // 'Invalid pattern '( )|(?)|(<)|(=)|([)|(.)|(,)|(;)|(])|(!)|(-)' at offset 6. Quantifier '?' following nothing.
        // string pattern = @"( )|(?)"; // 'Invalid pattern '( )|(?)' at offset 6. Quantifier '?' following nothing.'
        // string pattern = @"(?<=[.,;])!-)"; // 'Invalid pattern '(?<=[.,;])!-)' at offset 13. Too many )'s.'
        // string pattern = @"(?<=[.,;]!-)"; // doesn't split
        // string pattern = @"( ?<=[.,;]!-)"; // doesn't split
        // string pattern = @"( )"; // splits
        // string pattern = @"( )"; // doesn't split
        // string pattern = @"( )(:)"; // doesn't split
        // string pattern = @"( )|(:)"; // splits
        // string pattern = @"( )|(:)|(;)|(.)|(?)|(,)"; // 'Invalid pattern '( )|(:)|(;)|(.)|(?)|(,)' at offset 18. Quantifier '?' following nothing.'
        // string pattern = @"( )|(:)|(;)|(.)|(,)"; // 'Index was outside the bounds of the array.'
        // string pattern = @"( )|(:)|(;)|(.)"; // 'Index was outside the bounds of the array.'
        // string[] parts = Regex.Split(text, " "); // splits
        // string[] parts = Regex.Split(text, @"( )"); // splits
        // string pattern = @"( )|(:)|(;)|(.)"; // 'Index was outside the bounds of the array.'
        // string pattern = @":|( )|;|."; // 'Index was outside the bounds of the array.'
        // string[] parts = Regex.Split(text, pattern);
        // string[] parts = Regex.Split(Regex.Split(text, " "), ":"); // invalid syntax... =(

        List<string> parts = new List<string>();
        string pattern = @"\w+|[^\w\s]| "; // \w+: One or more word characters (letters, digits, underscore), [^\w\s]: Any character that is not a word character or a whitespace character (i.e., punctuation)., : Space character.
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            parts.Add(match.Value);
        }
        // Console.WriteLine(string.Join(", ", parts));

        // Console.WriteLine("parts = "); // Remove this line
        foreach (string part in parts)
        {
            Word word = new Word(part);
            // Console.Write('"'+part+'"'+','); // Remove this line
            words.Add(word);
            if (!punctuation.Contains(text[0]))
            {
                realWordCount+=1;
            }
        }
        // Console.WriteLine($"words = {words}");
    }
    
    public void HideWords(int number)
    {
        // Console.WriteLine("5.6");
        // ShowWords();
        int hideNumber = 0;
        List<int> nonHiddenWordIndexes = new List<int>();
        // Console.WriteLine("5.7");
        // ShowWords();
        for (int i = 0; i < words.Count(); i++)
        {
            // Console.WriteLine($"!words[i].GetIsHidden() = {!words[i].GetIsHidden()}");
            // Console.Write($", words[i].GetIsHidden() = {words[i].GetIsHidden()}");
            // Console.WriteLine(", word = ");
            // words[i].Show();
            if (!words[i].GetIsHidden())
            {
                nonHiddenWordIndexes.Add(i);
            }
        }
        Console.WriteLine("5.8");
        ShowWords();
        if (nonHiddenWordIndexes.Count==0)
        {
            Console.WriteLine("nonHiddenWordIndexes.Count==0");
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
        // Console.WriteLine("5.9");
        // ShowWords();
        for (int i = 0; i < hideNumber; i++)
        {
            Random rand = new Random();
            int index = rand.Next(words.Count);
            Word word = words[nonHiddenWordIndexes[index]];
            word.Hide();
        }
        // Console.WriteLine("5.95");
        // ShowWords();
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