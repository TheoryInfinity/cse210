public class Verse {
        private List<Word> _words = new List<Word>();
        private int _verseNumber;
        private Random rnd = new Random();

    public Verse() {
        _verseNumber = 1;
    }

    public Verse(string text, int verseNumber) {
        _verseNumber = verseNumber;
        string[] verseArray = text.Split(' ');
        foreach (string word in verseArray) {
            _words.Add(new Word(word));
        }
    }

    public int GetVerseNumber() {
        return _verseNumber;
    }

    public bool IsFinished() {
        foreach (Word word in _words) {
            if (!word.GetHidden()) {
                return false;
            }
        }
        return true;
    } 

    public bool HideWord() {
        if (IsFinished()) {
            return false;
        }
        int randWord = rnd.Next(_words.Count);
        return _words[randWord].Hide();
    }

    public string GetText() {
        return string.Join(" ", _words.Select(word => word.GetText()));
    }

}