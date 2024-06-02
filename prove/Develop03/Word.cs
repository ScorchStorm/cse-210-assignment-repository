// ===============================
//           Word
// -------------------------------
//     - string text
//     - boolean hidden
//     - boolean firstLetterHidden
// -------------------------------
//     + Hide(boolean hide)
//     + HideFirstLetter(boolean hide)
//     + Show()
// ===============================

class Word
{
    private string text;
    private bool hidden;
    private bool firstLetterHidden;
    private List<char> punctuation = new List<char>{'(', '?', '<', '=', '[', '.', ',', ';', ']', ')', '!', '-', ':', ' '};

    public Word(string Text)
    {
        text = Text;
        firstLetterHidden = false;
        if (punctuation.Contains(Text[0]))
        {
            hidden = true;
        }
        else
        {
            hidden = false;
        }
    }

    public void Hide()
    {
        hidden = true;
    }

    public void HideFirstLetter()
    {
        firstLetterHidden = true;
    }

    public bool GetIsHidden()
    {
        return hidden;
    }

    public void Show()
    {
        if (!punctuation.Contains(text[0]) && hidden == true)
        {
            if (firstLetterHidden)
            {
                Console.Write(text[0]);
                for (int i=1; i<text.Length; i++)
                {
                    Console.Write("_");
                }
            }
            else
            {
                for (int i=0; i<text.Length; i++)
                {
                    Console.Write("_");
                }

            }
        }
        else
        {
            Console.Write(text);
        }
    }
}