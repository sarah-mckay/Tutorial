using System;
using SplashKitSDK;

public class BankDatabase
{
    private Database _bankDB;
    private QueryResult _result;

    public BankDatabase()
    {
        // create the database object
        _bankDB = new Database("bank","bankFile");

        // create the table if it doesn't exist already
        SplashKit.RunSql(_bankDB, "CREATE TABLE account(name TEXT, amount DOUBLE);");
    }

    public bool InsertRow(string name, double accountBalance)
    {
        _result = SplashKit.RunSql(_bankDB, "INSERT INTO account VALUES(\"" + name + "\", " + accountBalance + ");");

        return SplashKit.QuerySuccess(_result);
    }

    public void Print()
    {
        string column1;
        double column2 = 0;

        _result = SplashKit.RunSql(_bankDB, "SELECT * FROM account;");

        do
        {
            column1 = SplashKit.QueryColumnForString(_result, 0);
            column2 = SplashKit.QueryColumnForDouble(_result, 1);

            Console.WriteLine("Account: " + column1 + "     balance: " + column2);

        } while (SplashKit.GetNextRow(_result));
    }

    public bool UpdateBalance(string name, double accountBalance)
    {
        _result = SplashKit.RunSql(_bankDB, "UPDATE account SET amount = " + accountBalance +" WHERE name =\"" + name + "\"; ");
        return SplashKit.QuerySuccess(_result);
    }

    public double FindAccountBalance(string name)
    {
        _result = SplashKit.RunSql(_bankDB, "SELECT * FROM account WHERE name =\"" + name + "\";");
        return SplashKit.QueryColumnForDouble(_result, 1);
    }
}