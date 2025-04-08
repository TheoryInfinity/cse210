public class HumidityControlledUnit : Storage
{
    private int _targetHumidity;
    private int _humidityVarianceRange;
    private bool _isSystemOn;

    public HumidityControlledUnit(string size, int unitID, int humidityPremium) : base(size, unitID, "Humidity-Controlled")
    {
        _costPerMonth += humidityPremium;
        _targetHumidity = 50;           // %
        _humidityVarianceRange = 5;
        _isSystemOn = true;
    }
    public override string ToDisplayString(string availabilityStatus = "[Pending]")
    {
        return $"Unit {_unitID} | {_size} | Volume {(int)GetTotalVolume()} ft³ | Area {(int)GetTotalArea()} ft² | Dimensions: {_length}x{_width}x{_height} | {_unitType} | Target Humidity: {_targetHumidity}% ± {_humidityVarianceRange}% | System: {(_isSystemOn ? "On" : "Off")} | {availabilityStatus}";
    }
    public override string RepSaveString()
    {
        return $"Humid~{_unitID}~{_size}~{_width}~{_length}~{_height}~{_costPerMonth}~{_targetHumidity}~{_humidityVarianceRange}~{_isSystemOn}";
    }

    public HumidityControlledUnit(int id, string size, int width, int length, int height, int cost, int targetHumidity, int range, bool isOn)
    {
        _unitType = "Humidity-Controlled";
        _unitID = id;
        _size = size;
        _width = width;
        _length = length;
        _height = height;
        _costPerMonth = cost;
        _targetHumidity = targetHumidity;
        _humidityVarianceRange = range;
        _isSystemOn = isOn;
    }
}