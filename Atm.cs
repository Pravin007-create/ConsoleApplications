using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Exercise: ATM Menu (Switch + If-Else)
Write a program with a loop that:

Displays options: Check Balance, Deposit, Withdraw, Exit.

Uses switch to handle menu choices.

Uses if-else for validation like minimum balance check.

Maintains the balance using a variable.
 
 */

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            double main_balance = 500; // Main balance

            while (true)
            {
            AtmMenu:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("**************ATM*****************");
                Console.WriteLine("* For Check Balance Enter   - 1  *");
                Console.WriteLine("* For Deposit Amount Enter  - 2  *");
                Console.WriteLine("* For Withdraw Amount Enter - 3  *");
                Console.WriteLine("* For Exit Enter            - 4  *");
                Console.WriteLine("**********************************");
                Console.ResetColor();

                bool Condition = int.TryParse(Console.ReadLine(), out int input);
                if (input == 4)
                    break;
                if (Condition)
                {
                    switch (input)
                    {


                        case 1:          ////Printing the Main balance
                            Console.WriteLine($"\nYour Bank Balance : {main_balance:f2}");
                            break;

                        //Deposit amount
                        case 2:

                            Console.WriteLine("\n***For Exit Enter Enter (0)***");
                            Console.WriteLine("\nEnter the Deposit Amount :  ");

                            bool deposit_condition = double.TryParse(Console.ReadLine(), out double deposit_amount);
                            if (deposit_condition)
                            {
                                if (deposit_amount == 0)
                                {
                                    goto AtmMenu;
                                }
                                else if (deposit_amount > 0)
                                {
                                    main_balance += deposit_amount;
                                    Console.WriteLine($"\nYour Main Balance : {main_balance:f2}");
                                }
                                else
                                {
                                    Console.WriteLine("\nDeposit Amount Must be Greater than Zero(0)");
                                    goto case 2;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nEnter the valid amount");
                                goto case 2;
                            }
                            break;

                        //withdraw amount
                        case 3:
                            Console.WriteLine("\n***For Exit Enter Enter (0)***");
                            Console.WriteLine("\nEnter the Withdraw amount : ");

                            bool withdraw_condition = double.TryParse(Console.ReadLine(), out double withdraw_amount);
                            if (withdraw_condition)
                            {
                                if (withdraw_amount == 0)
                                {
                                    goto AtmMenu;
                                }

                                else if (withdraw_amount <= 0)
                                {
                                    Console.WriteLine("\nWithdraw Amount Must be Greater than Zero(0)");
                                    goto case 3;
                                }
                                else if (withdraw_amount > main_balance)
                                {
                                    Console.WriteLine("\nInsufficient balance");
                                    Console.WriteLine($"\nAvailable Balance :{main_balance:f2}");
                                    goto case 3;
                                }
                                else if ((main_balance - withdraw_amount) < 500)
                                {
                                    Console.WriteLine("Mimum Balance Must be Rs.500");
                                    Console.WriteLine($"\nYour Main Balance : {main_balance:f2}");
                                    goto case 3;

                                }
                                else
                                {
                                    main_balance -= withdraw_amount;
                                    Console.WriteLine($"\nYour Main Balance :{main_balance:f2}");
                                    Console.WriteLine($"\nYour Withdraw Amount :{withdraw_amount:f2}");

                                }

                            }
                            else
                            {
                                Console.WriteLine("\nEnter the valid amount");

                                goto case 3;
                            }
                            break;
                        default:
                            Console.WriteLine("\nEnter the Valid Number(1,2,3,4)");
                            break;
                    }


                }
                else
                {
                    Console.WriteLine("\nEnter the Valid Number");
                }
            }

        }
    }
}
