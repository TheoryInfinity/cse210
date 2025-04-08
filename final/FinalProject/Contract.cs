using System.Data;
using System.Data.Common;
using System.Diagnostics.Tracing;
using System.Net;

public class Contract
{
    private int _renterID;
    private int _unitID;
    private string _startDate;
    private string _endDate;
    private double _costMultiplier;
    private int _costAdditiveScalar;
    private bool _isActive;
    private bool _isCanceled;
    private string _effectiveCancelDate;

    public Contract()
    {
        _renterID = -1;
        _unitID = -1;
        _startDate = "none";
        _endDate = "none";
        _costMultiplier = 1;
        _costAdditiveScalar = 0;
        _isActive = false;
        _isCanceled = false;
        _effectiveCancelDate = "none";
    }

    public Contract(int renter, int unit, int durationMonths, double costMultiplier = 1, int addition = 0, bool isActive = true)
    {

        _renterID = renter;
        _unitID = unit;
        DateTime startDate = DateTime.Today;
        _startDate = startDate.ToString("yyyy-MM-dd");
        DateTime endDate = startDate.AddDays(30 * durationMonths);
        _endDate = endDate.ToString("yyyy-MM-dd");
        _costMultiplier = costMultiplier;
        _costAdditiveScalar = addition;
        _isActive = isActive;
        _isCanceled = false;
        _effectiveCancelDate = "none";
    }

    public void UpdateStatus()
    {
        DateTime today = DateTime.Today;
        DateTime end = DateTime.ParseExact(_endDate, "yyyy-MM-dd", null);

        if (today > end)
        {
            _isActive = false;
        }
        else if (_isCanceled)
        {
            DateTime cancel = DateTime.ParseExact(_effectiveCancelDate, "yyyy-MM-dd", null);
            if (today > cancel)
            {
                _isActive = false;
            }
        }

    }

    public string ToDisplayString(int baseMonthlyCost)
    {
        string contractstatus;

        if (_isCanceled)
        {
            contractstatus = "Canceled";
        }
        else if (!_isActive)
        {
            contractstatus = "Expired";
        }
        else
        {
            contractstatus = "Active";
        }

        string displayString = $"Contract for Unit {_unitID} | Renter ID {_renterID} | {_startDate} -- {_endDate} | Status: {contractstatus} | Monthly Cost: ${CalculateMonthlyCost(baseMonthlyCost):F2}";
        return displayString;
    }

    public double CalculateMonthlyCost(int baseMonthlyCost)
    {
        double CalculatedCost = (double)baseMonthlyCost * (double)_costMultiplier + (double)_costAdditiveScalar;
        return CalculatedCost;
    }

    public void CancelContract()
    {
        if (!_isCanceled)
        {
            _isCanceled = true;

            // I wanted to give people time to get thier stuff out or undo the cancellation.
            DateTime effectiveDate = DateTime.Today.AddDays(5);
            _effectiveCancelDate = effectiveDate.ToString("yyyy-MM-dd");
        }
    }

    public void UndoCancellation()
    {
        if (_isCanceled)
        {
            DateTime today = DateTime.Today;
            DateTime cancelDeadline = DateTime.ParseExact(_effectiveCancelDate, "yyyy-MM-dd", null);

            if (today <= cancelDeadline)
            {
                _isCanceled = false;
                _effectiveCancelDate = "none";
            }
            else
            {
                Console.WriteLine("Cancellation can no longer be reversed.");
            }
        }
    }

    public int GetUnitID()
    {
        return _unitID;
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public bool RentContract(int unitToClaim, List<Contract> existingContracts)
    {
        foreach (Contract contract in existingContracts)
        {
            if (contract._isActive && contract.GetUnitID() == unitToClaim)
            {
                return false;
            }
        }

        _unitID = unitToClaim;
        _isActive = true;
        return true;
    }

    public string RepSaveString()
    {
        return $"{_unitID}~{_startDate}~{_endDate}~{_costMultiplier}~{_costAdditiveScalar}~{_isActive}~{_isCanceled}~{_effectiveCancelDate}";
    }

    public Contract(int unitID, string startDate, string endDate, double costMultiplier, int costAdditiveScalar, bool isActive, bool isCanceled, string cancelDate)
    {
        _unitID = unitID;
        _startDate = startDate;
        _endDate = endDate;
        _costMultiplier = costMultiplier;
        _costAdditiveScalar = costAdditiveScalar;
        _isActive = isActive;
        _isCanceled = isCanceled;
        _effectiveCancelDate = cancelDate;
    }

}