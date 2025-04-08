using System.Formats.Asn1;
using System.Xml.Linq;

public abstract class Storage
{

    protected int _unitID;
    protected int _height;
    protected int _length;
    protected int _width;
    protected int _costPerMonth;
    protected string _size;
    protected string _unitType;

    public Storage()
    {
        _unitID = -1;
        _height = 0;
        _width = 0;
        _length = 0;
        _costPerMonth = 0;
        _size = "none";
        _unitType = "none";
    }

    public Storage(int ident, int height, int length, int width, int cost, string unitType, string size = "custom")
    {
        _unitID = ident;
        _height = height;
        _width = width;
        _length = length;
        _costPerMonth = cost;
        _unitType = unitType;
        _size = size;
    }

    public Storage(string size, int unitID, string unitType)
    {
        _unitID = unitID;
        _size = size;
        _unitType = unitType;


        if (!SetDimensionsBySize(size))
        {
            Console.WriteLine("Invalid size input.");
        }
    }

    private bool SetDimensionsBySize(string size)
    {
        switch (size.ToLower())
        {
            case "small":
                _width = 5;
                _length = 5;
                _height = 8;
                _costPerMonth = 50;
                return true;
            case "medium":
                _width = 10;
                _length = 10;
                _height = 8;
                _costPerMonth = 100;
                return true;
            case "large":
                _width = 10;
                _length = 20;
                _height = 8;
                _costPerMonth = 150;
                return true;
            default:
                return false;
        }
    }

    public double GetTotalArea()
    {
        double Area = (double)_length * (double)_width;
        return Area;
    }

    public double GetTotalVolume()
    {
        double Area = (double)_height * (double)_length * (double)_width;
        return Area;
    }

    public int GetBaseCost()
    {
        return _costPerMonth;
    }

    public virtual string ToDisplayString(string availabilityStatus = "[Pending]")
    {
        return $"Unit {_unitID} | {_size} | Volume {(int)GetTotalVolume()} ft³ | Area {(int)GetTotalArea()} ft² | Dimensions: {_length}x{_width}x{_height}  | {_unitType} | {availabilityStatus}";
    }

    public int GetUnitID()
    {
        return _unitID;
    }

    public abstract string RepSaveString();

}