using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Grocery_Bill_Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool flag = true;
            double Totalamount = 0;

            //Dictionary for Storing the name,priceand quantity//
            Dictionary<string, (double price, int quantity)> Products = new Dictionary<string, (double, int)>();

            Console.WriteLine("*****Grocery Bill Calculation*****");
            while (flag)
            {

                //Getting the product name by user//
                bool replace_product = false;
            GettingProductName:
                Console.WriteLine("Enter the Product Name:");
                string product_name = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(product_name))
                {
                    Console.WriteLine("**Product Name should not be Empty**");
                    goto GettingProductName;
                }
                else if (!product_name.Any(char.IsLetter))
                {
                    Console.WriteLine("**Product name must have Minimum '1' Alphabet**");
                    goto GettingProductName;

                }
                //checking the name is already exist in dictionary//
                if (Products.ContainsKey(product_name) && Products.Count() > 0)
                {
                    replace_product = true;

                }
                //getting the product price by user//
                double product_price = 0;
                if (!replace_product)
                {
                GettingProductPrice:



                    Console.WriteLine($"Enter the Price for {product_name}:");
                    string product_price_instring = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(product_price_instring))
                    {
                        Console.WriteLine("**Product price should not be Empty**");
                        goto GettingProductPrice;
                    }
                    try
                    {
                        product_price = double.Parse(product_price_instring);
                        if (product_price <= 0)                             //price must greater than 0
                        {
                            Console.WriteLine("Price Must Greater than '0'");
                            goto GettingProductPrice;
                        }

                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("\n**Invalid Input**");
                        goto GettingProductPrice;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("The Price amount is too Large");
                        goto GettingProductPrice;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        goto GettingProductPrice;
                    }
                }
            //Getting product quantity by user//
            GettingProductQuantity:
                Console.WriteLine($"\nEnter the Quantity for {product_name}");
                string product_quantity_instring = Console.ReadLine();
                int product_quantity;
                if (string.IsNullOrWhiteSpace(product_quantity_instring))
                {
                    Console.WriteLine("**Product Quantity should not be Empty**");
                    goto GettingProductQuantity;
                }
                try
                {
                    product_quantity = int.Parse(product_quantity_instring);
                    if (product_quantity <= 0)
                    {
                        Console.WriteLine("Product Quantity Not should be '0' and Negative");
                        goto GettingProductQuantity;
                    }

                }
                catch (FormatException)
                {

                    Console.WriteLine("**Inavalid input**");
                    goto GettingProductQuantity;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("**Product Quantity is too large ");
                    goto GettingProductQuantity;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto GettingProductQuantity;
                }
            FlagLoop:
                Console.WriteLine("\nNeed to Continue (Y/N)");  ///for continue or add another product 
                bool flag_Consdition = char.TryParse(Console.ReadLine(), out char newflag);
                if (flag_Consdition)
                {
                    if (newflag == 'y' || newflag == 'Y' || newflag == 'N' || newflag == 'n')
                    {
                        if (newflag == 'y' || newflag == 'Y')
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*****Invalid Input****");
                        Console.ResetColor();
                        Console.WriteLine("\nEnter only (y/n):");
                        goto FlagLoop;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n******Enter the Valid Input*****");
                    Console.ResetColor();
                    goto FlagLoop;
                }
                //Adding the Products ,price and quantity in dictionary
                if (replace_product) // the product already exist
                {
                    var item = Products[product_name];
                    item.quantity += product_quantity;
                    Products[product_name] = item;
                }
                if (!replace_product)  ///adding new product
                {

                    Products.Add(product_name, (product_price, product_quantity));

                }





            }

            Console.Clear();
            Console.WriteLine("\n\tProduct Name\tQuantity\tPrice\t\tTotal ");

            foreach (string product_name in Products.Keys)    //printing the name ,price ,quantity from the dictionary and calculating the total amount for each and grand total//
            {
                double total_price = Products[product_name].price * Products[product_name].quantity;
                Totalamount += total_price;
                Console.WriteLine($"\n\t{product_name}\t\t{Products[product_name].quantity}\t\t{Products[product_name].price}\t\t{total_price}");




            }
            Console.WriteLine("\n\tGrand Total\t\t\t\t\t:" + Totalamount);











        }
    }
}
