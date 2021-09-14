using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        BankDatabase bankDB = new BankDatabase();

        // variables we will need
        int option;
        string name;
        double accountBalance = 0;
        double amount = 0;
        double currentBalance = 0;

        do 
        {
             Console.WriteLine(
                "|----------------------------------------------------|\n"+
                "|          Menu Options                              | \n" +
                "|          1. Create Account                         |  \n" +
                "|          2. Deposit                                |  \n" +
                "|          3. Withdraw                               |  \n" +
                "|          4. Print                                  | \n" +
                "|          5. Exit                                   |  \n" +
                "|----------------------------------------------------|");

            option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                // create account
                Console.WriteLine("Enter Account Name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter Starting Balance:");
                accountBalance = Convert.ToInt32(Console.ReadLine());

                if (bankDB.InsertRow(name, accountBalance) == true)
                {
                    Console.WriteLine("Account successfully created");
                }
                else
                {
                    Console.WriteLine("Acount has not been succesfully created");
                }

            }
            else if (option == 2)
            {
                // deposit funds
                Console.WriteLine("Enter Account Name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter Amount to Deposit:");
                amount = Convert.ToInt32(Console.ReadLine());
                
                // get current balance
                currentBalance = bankDB.FindAccountBalance(name);
                accountBalance = amount + currentBalance;
                // update record with new balance
                if(bankDB.UpdateBalance(name, accountBalance) == true)
                {
                    Console.WriteLine("Deposit Successful");
                }
                else
                {
                    Console.WriteLine("Deposit Unsuccessful");
                }
                

            }
            else if (option == 3)
            {
                // withdraw fund
                Console.WriteLine("Enter Account Name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter Amount to Withdraw:");
                amount = Convert.ToInt32(Console.ReadLine());
                
                // get current balance
                currentBalance = bankDB.FindAccountBalance(name);
                accountBalance = currentBalance - amount;
                // update record with new balance
                if(bankDB.UpdateBalance(name, accountBalance) == true)
                {
                    Console.WriteLine("Withdraw Successful");
                }
                else
                {
                    Console.WriteLine("Withdraw Unsuccessful");
                }
            }
            else if (option == 4)
            {
               // print accounts
               bankDB.Print();
            }
             
        } while (option != 5);
    }

}
