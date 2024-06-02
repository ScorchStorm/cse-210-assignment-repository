// ===============================
//           Scripture
// -------------------------------
//     - string ref
//     - List<Word> words
// -------------------------------
//     + Scripture(string text, string reference)
//     + HideWords()
//     + HideFirstLetters()
//     + Show()
// ===============================

class Scripture
{
    private List<int> verses = new List<int>();
    private int chapter;
    private string book;
    List<Reference> references = new List<Reference>();
    string stringReference;
    List<int> RealWordCounts = new List<int>();

    public Scripture(string Book, int Chapter, int verse, string text)
    {
        book = Book;
        chapter = Chapter;
        stringReference = book + ' ' + chapter + ':' + verse;
        Console.WriteLine($"stringReference = {stringReference}");
        verses.Add(verse);
        Reference reference = new Reference(text);
        references.Add(reference);
        RealWordCounts.Add(reference.GetRealWordCount());
    }
    public Scripture(string Book, int Chapter, List<int> Verses, List<string> texts)
    {
        book = Book;
        chapter = Chapter;
        verses = Verses;
        stringReference = book + ' ' + chapter + ':' + verses[0] + '-' + verses[-1];
        chapter = Chapter;
        for (int i = 0; i < verses.Count(); i++)
        {
            verses.Add(verses[i]);
            Reference reference = new Reference(texts[i]);
            references.Add(reference);
            RealWordCounts.Add(reference.GetRealWordCount());
        }
    }

    public void HideFirstLetters()
    {
        foreach (Reference reference in references)
        {
            reference.HideFirstLetters();
        }
    }

    public void ShowWords()
    {
        Console.WriteLine();
        Console.WriteLine(stringReference);
        for (int i = 0; i < verses.Count(); i++)
        {
            if (i == 0)
            {
                Console.Write($"{verses[i]}. ");
            }
            else
            {
            Console.WriteLine($"{verses[i]}. ");
            }
            references[i].ShowWords();
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    public string ReturnStringReference()
    {
        return stringReference;
    }

    public void HideWords(int number)
    {
        for (int i = 0; i < references.Count(); i++)
        {
            Reference reference = references[i];
            float numberToRound = number*(RealWordCounts[i]/RealWordCounts.Sum());
            Console.WriteLine($"numberToRound = {numberToRound}");
            int hideNumber = (int)Math.Round(numberToRound); // the number of words to hide in each verse
            // Console.WriteLine("5.5");
            // reference.ShowWords();
            reference.HideWords(hideNumber);
            // Console.WriteLine("5.75");
            reference.ShowWords();
        }
    }
}