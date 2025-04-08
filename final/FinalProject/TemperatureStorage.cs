public class TemperatureControlledUnit : Storage
{

    private int _targetTemperature;
    private int _tempVarianceRange;
    private bool _isSystemOn;

    public TemperatureControlledUnit(string size, int unitID, int tempPremium)
        : base(size, unitID, "Temperature-Controlled")
    {
        _costPerMonth += tempPremium;
        _targetTemperature = 70;
        _tempVarianceRange = 2;
        _isSystemOn = true;
    }

    public override string ToDisplayString()
    {
        string systemStatus = _isSystemOn ? "On" : "Off";
        return base.ToDisplayString() + $" | Temp: {_targetTemperature}° | System: {systemStatus}";
    }

    public override string RepSaveString()
    {
        return $"Temperature~{_unitID}~{_size}~{_width}~{_length}~{_height}~{_costPerMonth}~{_targetTemperature}~{_tempVarianceRange}~{_isSystemOn}";
    }

    public TemperatureControlledUnit(int id, string size, int width, int length, int height, int cost, int targetTemp, int range, bool isOn) {
        _unitType = "Temperature-Controlled";
        _unitID = id;
        _size = size;
        _width = width;
        _length = length;
        _height = height;
        _costPerMonth = cost;
        _targetTemperature = targetTemp;
        _tempVarianceRange = range;
        _isSystemOn = isOn;
    }

}