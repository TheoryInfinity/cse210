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
        throw new NotImplementedException();
    }
}