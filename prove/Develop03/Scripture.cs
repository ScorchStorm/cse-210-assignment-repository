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
    private List<Reference> references = new List<Reference>();
    private string stringReference;
    // private List<float> RealWordCounts = new List<float>();
    private List<float> nonHiddenWordCounts = new List<float>();

    public Scripture(string Book, int Chapter, int verse, string text)
    {
        book = Book;
        chapter = Chapter;
        stringReference = book + ' ' + chapter + ':' + verse;
        verses.Add(verse);
        Reference reference = new Reference(text);
        references.Add(reference);
        // RealWordCounts.Add(reference.GetRealWordCount());
        nonHiddenWordCounts.Add(reference.GetNonHiddenWords().Count);
    }
    public Scripture(string Book, int Chapter, List<int> Verses, List<string> texts)
    {
        book = Book;
        chapter = Chapter;
        verses = Verses;
        stringReference = book + ' ' + chapter + ':' + verses[0] + '-' + verses.Last();
        chapter = Chapter;
        for (int i = 0; i < verses.Count; i++)
        {
            Reference reference = new Reference(texts[i]);
            references.Add(reference);
            nonHiddenWordCounts.Add(reference.GetNonHiddenWords().Count);
        }
        // GetRealWordCounts();
    }

    // public List<float> GetRealWordCounts()
    // {
    //     for (int i = 0; i < verses.Count(); i++)
    //     {
    //         RealWordCounts[i] = references[i].GetRealWordCount();
    //     }
    //     return RealWordCounts;
    // }

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
        for (int i = 0; i < verses.Count; i++)
        {
            if (i == 0)
            {
                Console.Write($"{verses[i]}. ");
            }
            else
            {
                Console.WriteLine();
                Console.Write($"{verses[i]}. ");
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

    public int HideWords(int number) // Hides a number of words in each verse proportional to the number of unhidden words in each verse
    {
        int numNonHiddenWords = 0;
        for (int i = 0; i < references.Count; i++)
        {
            nonHiddenWordCounts[i] = references[i].GetNonHiddenWords().Count;
        }
        for (int i = 0; i < references.Count; i++)
        {
            float numberToRound = number*nonHiddenWordCounts[i]/nonHiddenWordCounts.Sum();
            int hideNumber = (int)Math.Round(numberToRound); // the number of words to hide in each verse
            numNonHiddenWords += (int)Math.Round(nonHiddenWordCounts[i]-hideNumber);
            Reference reference = references[i];
            reference.HideWords(hideNumber);
        }
        return numNonHiddenWords;
    }
}