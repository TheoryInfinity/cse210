using System.Xml.Linq;

public abstract class Storage {

    protected string _identifier;
    //maybe make the identifier an integer
    protected int _height;
    protected int _width;
    protected int _cost;
    // make this a list of storages.
    // maybe allow storage units to record and list thier contents.
    // Alow users to enable digital inventory in order to keep track of objects inside thier storage unit

    public Storage() {
        _identifier = "Does Not Exist";
        _height = 0;
        _width = 0;
        _cost = 0;
    }

    public Storage(string ident, int height, int width, int cost) {
        _identifier = ident;
        _height = height;
        _width = width;
        _cost = cost;
    }

    public abstract string RepString();


}