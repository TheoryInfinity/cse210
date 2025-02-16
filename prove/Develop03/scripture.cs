public class Scripture {
    private List<Verse> _verses = new List<Verse>();
    private string _reference;
    private Random rnd = new Random();

    public Scripture() {
        _reference = "none";
    }

    public Scripture(string reference, string text) {
        _reference = reference;
        string[] verseTexts = text.Split('\n');
        
        int startVerse = 1;
        if (reference.Contains(":")) {
            string verseSection = reference.Split(':')[1];
            if (verseSection.Contains("-")) {
                startVerse = int.Parse(verseSection.Split('-')[0]);
            } else {
                startVerse = int.Parse(verseSection);
            }
        }

        for (int i = 0; i < verseTexts.Length; i++) {
            if (!string.IsNullOrWhiteSpace(verseTexts[i])) {
                _verses.Add(new Verse(verseTexts[i].Trim(), startVerse + i));
            }
        }
    }

    public void Display() {
        Console.WriteLine(_reference);
        for (int i = 0; i < _verses.Count; i++) {
            Console.WriteLine($"Verse {_verses[i].GetVerseNumber()}: {_verses[i].GetText()}");
        }
    }

    public bool IsFinished() {
        foreach (Verse verse in _verses) {
            if (!verse.IsFinished()) {
                return false;
            }
        }
        return true;
    }

    public bool HideVerse(int wordCount = 3) {
        // Default to 3 and then accept a word count to change the difficulty
        int hidecount = wordCount;
        bool anyWordsHidden = false;
        while(hidecount > 0 && !IsFinished()) {
            int randVerse = rnd.Next(_verses.Count);
            if (_verses[randVerse].HideWord()) {
                hidecount--;
                anyWordsHidden = true;
            }
        }
        return anyWordsHidden;
    }
}