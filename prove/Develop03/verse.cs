public class Verse {
        private List<Word> _words = new List<Word>();

        private Random rnd = new Random();

    public Verse() {
        //empty list already initialized
    }

    public Verse(string text) {
            string[] verseArray = text.Split(' ');
            foreach (string word in verseArray) {
                _words.Add(new Word(word));
            }
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