public class StandardStorageUnit : Storage
{
    public StandardStorageUnit(string size, int unitID) : base(size, unitID, "Standard")
    {
        // Same as base
    }

    public override string ToDisplayString(string availabilityStatus = "[Pending]")
    {
        return $"Unit {_unitID} | {_size} | Volume {(int)GetTotalVolume()} ft³ | Area {(int)GetTotalArea()} ft² | Dimensions: {_length}x{_width}x{_height} | {_unitType} | {availabilityStatus}";
    }

    public override string RepSaveString()
    {
        return $"Standard~{_unitID}~{_size}~{_width}~{_length}~{_height}~{_costPerMonth}";
    }

    public StandardStorageUnit(int id, string size, int width, int length, int height, int cost)
    {
        _unitType = "Standard";
        _unitID = id;
        _size = size;
        _width = width;
        _length = length;
        _height = height;
        _costPerMonth = cost;
    }

}