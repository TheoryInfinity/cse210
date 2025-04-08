public class StandardStorageUnit : Storage
{
    public StandardStorageUnit(string size, int unitID): base(size, unitID, "Standard") {
        // Same as base
    }

    public override string ToDisplayString()
    {
        return base.ToDisplayString();
    }

    public override string RepSaveString()
    {
        // Placeholder
        return $"Standard,{_unitID},{_size},{_width},{_length},{_height},{_costPerMonth}";
    }
}