using System.Diagnostics.Contracts;

public class User {

    private string _userID;
    private string _name;
    private string _password;

    private List<Contract> _activeContracts = new List<Contract>();

    public User() {
        _name = "John Doe";
        _password = "NA";
    }   

    public bool Login() {
        //Code to actually log in
        bool logSucess = false;
        return logSucess;
    }

    public void Logout() {

    }

    public int CalculatePriceTotal() {
        int PriceTotal = 0;
        return PriceTotal;
    }

    public void AddContract() {

    }

    public void RemoveContract() {

    }

    public void ListContracts() {

    }

    public void Display() {
        
    }
}