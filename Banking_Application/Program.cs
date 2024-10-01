using System;

namespace Banking_Application
{

    class BankApplication
    {

        private long Bank_Acc_no;

        private string Holder_Name;

        private long MobileNumber;

        private long AdharNumber;

        private double Bank_Balance = 0;

        private double withdraw;

        private double diposite;

        // for holder name 
        public string Holdername
        {
            get
            {
                return Holder_Name;

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Enter valide name ");
                }
                else
                {
                    Holder_Name = value;
                }
            }
        }

        //for mobile number 

        public long mobileNumber
        {
            get
            {
                return MobileNumber;
            }
            set
            {
                if (value.ToString().Length < 10)
                {
                    Console.WriteLine("Mobile number must be contain 10 digits");
                }
                else
                {
                    MobileNumber = value;
                }
            }
        }

        //for adharNumber

        public long Adharnumber
        {
            get
            {
                return AdharNumber;
            }
            set
            {
                if (value.ToString().Length < 12)
                {
                    Console.WriteLine(" Enter valid Adhar number ! Adhar number must contain 12 digits ");
                }
                else
                {
                    AdharNumber = value;
                }
            }
        }


        //for bank acccount number 

        public long Bank_Acc_No
        {
            get
            {
                return Bank_Acc_no;
            }
            set
            {
                if (value.ToString().Length == 12)
                {
                    Bank_Acc_no = value;
                }
            }
        }

        // for account balance 
        public double bankBalance
        {
            get
            {
                return Bank_Balance;
            }
            set
            {
                Bank_Balance = value;
            }

        }

        // for diposite
        public double Deposit(double depositAmount)
        {
            if (depositAmount <= 0)
            {
                Console.WriteLine("Invalid amount. Deposit must be greater than 0.");
                return bankBalance;
            }

            bankBalance += depositAmount;
            Console.WriteLine($"Successfully deposited: {depositAmount}. New balance: {bankBalance}");
            return bankBalance;
        }

        // for withdraw
        public double Withdraw(double withdrawAmount)
        {


            if (withdrawAmount <= 0)
            {
                Console.WriteLine("enter valid amount !! ");
            }
            else if (bankBalance < withdrawAmount)
            {
                Console.WriteLine("Insufficient balance !! ");
            }
            else
            {
                bankBalance = bankBalance - withdrawAmount;

                Console.WriteLine("Amount withdraw");
            }
            return bankBalance;
        }
        public void AccDetails()
        {
            Console.WriteLine($"Holder Name : {Holdername}");

            Console.WriteLine($"Adhar number : {AdharNumber.ToString().Substring(0, 4) + "XXXX"}");
            Console.WriteLine($"Mobile number  : {mobileNumber.ToString().Substring(0, 4) + "XXXX"}");
            Console.WriteLine($"Bank account number  : {Bank_Acc_no.ToString().Substring(0, 4) + "XXXX"}");
            Console.WriteLine($"Bank Balance : {bankBalance}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            BankApplication app = new BankApplication();
            Random random = new Random();

            int ch;
            do
            {

                Console.WriteLine();
                Console.WriteLine("-----wellcome to my bank-----");
                Console.WriteLine();
                Console.WriteLine("--------BANK SERVICE--------");
                Console.WriteLine();
                Console.WriteLine(" 1 : Create acount ");
                Console.WriteLine(" 2 : Diposite");
                Console.WriteLine(" 3 : withdraw");
                Console.WriteLine(" 4 : check balance");
                Console.WriteLine(" 5 : diplay account details");
                Console.WriteLine(" 6 : Exit");


                Console.Write(" select option : ");

                //ch = int.Parse(Console.ReadLine());
                while (!int.TryParse(Console.ReadLine(), out ch) || ch < 1 || ch > 6)
                {
                    Console.WriteLine("Invalid choice, please select again.");
                }
                Console.WriteLine();
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("You want to create new account ");
                        Console.WriteLine();
                        Console.WriteLine("Enter the Details : ");
                        Console.WriteLine();

                        Console.Write("Enter your name (First and Last) : ");
                        string holderaname = Console.ReadLine();
                        app.Holdername = holderaname;

                        Console.Write("Enter your mobile number : ");
                        long mobileNo = long.Parse(Console.ReadLine());
                        app.mobileNumber = mobileNo;

                        Console.Write("Enter your Adhar number : ");
                        long adhar = long.Parse(Console.ReadLine());
                        app.Adharnumber = adhar;


                        long acc = (long)(random.NextDouble() * 1_000_000_000_000);
                        //Console.WriteLine(acc.ToString("D12"));
                        app.Bank_Acc_No = acc;

                        if (!string.IsNullOrWhiteSpace(holderaname) && mobileNo != 0 && mobileNo.ToString().Length == 10 && adhar != 0 && adhar.ToString().Length == 12 && acc != 0)
                        {
                            Console.WriteLine("Account Created succesfully");
                        }
                        else
                        {
                            Console.WriteLine("Account is not Created");
                            break;
                        }

                        Console.WriteLine();
                        break;

                    case 2:
                        Console.Write("Enter amount to diposite : ");
                        double diposite = double.Parse(Console.ReadLine());
                        app.Deposit(diposite);

                        break;
                    case 3:
                        Console.Write("enter amount to withdraw : ");
                        double withdraw = double.Parse(Console.ReadLine());
                        app.Withdraw(withdraw);

                        break;
                    case 4:
                        Console.WriteLine($"your bank balance is {app.bankBalance}");


                        break;
                    case 5:
                        app.AccDetails();
                        break;

                    case 6: break;

                    default: Console.WriteLine("Invalid choise"); break;
                }
            } while (ch != 6);



        }
    }
}
