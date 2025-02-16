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

        foreach (string verseText in verseTexts) {
            if (!string.IsNullOrWhiteSpace(verseText)) {
                _verses.Add(new Verse(verseText.Trim()));
            }
        }
    }

    public void Display() {
        Console.WriteLine(_reference);
        for (int i = 0; i < _verses.Count; i++) {
            Console.WriteLine($"{_verses[i].GetText()}");
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

    public bool HideVerse() {
        int hidecount = 3;
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