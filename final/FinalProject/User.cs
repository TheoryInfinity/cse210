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
        return _password;
    }

    public int GetID()
    {
        return _userID;
    }
    public List<Contract> GetContracts()
    {
        return new List<Contract>(_contracts);
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

    public User(string saveLine)
    {
        string[] parts = saveLine.Split(" :||: ");

        _userID = int.Parse(parts[0]);
        _name = parts[1];
        _password = parts[2];

        _contracts = new List<Contract>();

        if (parts.Length > 3 && !string.IsNullOrWhiteSpace(parts[3]))
        {
            string[] contractStrings = parts[3].Split(" :|: ");
            foreach (string c in contractStrings)
            {
                string[] values = c.Split('~');
                int unitID = int.Parse(values[0]);
                string start = values[1];
                string end = values[2];
                int multiplier = int.Parse(values[3]);
                int scalar = int.Parse(values[4]);
                bool active = bool.Parse(values[5]);
                bool canceled = bool.Parse(values[6]);
                string cancelDate = values[7];

                Contract contract = new Contract(unitID, start, end, multiplier, scalar, active, canceled, cancelDate);
                _contracts.Add(contract);
            }
        }
    }
}