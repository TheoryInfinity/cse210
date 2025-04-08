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
    public override string ToDisplayString()
    {
        string systemStatus = _isSystemOn ? "On" : "Off";
        return base.ToDisplayString() + $" | Humidity: {_targetHumidity}% | System: {systemStatus}";
    }

    public override string RepSaveString()
    {
        return $"Humid~{_unitID}~{_size}~{_width}~{_length}~{_height}~{_costPerMonth}~{_targetHumidity}~{_humidityVarianceRange}~{_isSystemOn}";
    }
}