

public class Word {
    private string _text;
    private bool _hidden;

    public Word() {
        _text = "";
        _hidden = false;
    }

    public Word(string text) {
        _text = text;
        _hidden = false;
    }

    public bool GetHidden() {
        return _hidden;
    }

    public bool Hide() {
        if (_hidden == true) {
            return false;
        }
        else {
            _hidden = true;
            return true;
        }
    }

    public string GetText() {
        if (_hidden) {
            return new string('_', _text.Length);
        }
        return _text;
    }

}