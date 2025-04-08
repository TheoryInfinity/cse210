using System.Diagnostics.Contracts;

public class User
{

    private int _userID;
    private string _name;
    private string _password;

    private List<Contract> _contracts = new List<Contract>();

    public User()
    {
        _userID = -1;
        _name = "John Doe";
        _password = "NA";
        _contracts = new List<Contract>();
    }

    public User(int id, string name, string password)
    {
        _userID = id;
        _name = name;
        _password = password;
        _contracts = new List<Contract>();
    }

    public bool Login(string passwordAttempt)
    {
        return passwordAttempt == _password;
    }

    public double CalculatePriceTotal(Dictionary<int, int> unitBaseCosts)
    {
        double total = 0;

        foreach (Contract contract in _contracts)
        {
            if (contract.IsActive())
            {
                int unitID = contract.GetUnitID();

                if (unitBaseCosts.ContainsKey(unitID))
                {
                    int baseCost = unitBaseCosts[unitID];
                    total += contract.CalculateMonthlyCost(baseCost);
                }
            }
        }

        return total;
    }

    public void AddContract(Contract newContract)
    {
        _contracts.Add(newContract);
    }

    public bool CancelContract(int unitID)
    {
        foreach (Contract contract in _contracts)
        {
            if (contract.IsActive() && contract.GetUnitID() == unitID)
            {
                contract.CancelContract();
                return true;
            }
        }
        return false;
    }

    public void ListActiveContracts(Dictionary<int, int> unitBaseCosts)
    {
        foreach (Contract contract in _contracts)
        {
            if (contract.IsActive())
            {
                Console.WriteLine(contract.ToDisplayString(unitBaseCosts[contract.GetUnitID()]));
            }
        }
    }

    public void ListInactiveContracts(Dictionary<int, int> unitBaseCosts)
    {
        foreach (Contract contract in _contracts)
        {
            if (!contract.IsActive())
            {
                Console.WriteLine(contract.ToDisplayString(unitBaseCosts[contract.GetUnitID()]));
            }
        }
    }

    public string GetName()
    {
        return _name;
    }

    public string GetPassword()
    {
        return _name;
    }

    public int GetID()
    {
        return _userID;
    }

    public void Display(Dictionary<int, int> unitBaseCosts)
    {
        int activeCount = 0;
        foreach (Contract contract in _contracts)
        {
            if (contract.IsActive())
            {
                activeCount++;
            }
        }

        double total = CalculatePriceTotal(unitBaseCosts);

        Console.WriteLine($"User ID: {_userID} | Name: {_name} | Active Contracts: {activeCount} | Total Monthly Cost: ${total:F2}");
    }

    public string RepSaveString()
    {
        List<string> contractStrings = new List<string>();

        foreach (Contract contract in _contracts)
        {
            contractStrings.Add(contract.RepSaveString());
        }

        string contractsPart = string.Join(" :|: ", contractStrings);

        return $"{_userID} :||: {_name} :||: {_password} :||: {contractsPart}";
    }
}