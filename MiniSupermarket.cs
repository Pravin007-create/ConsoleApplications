
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Minisupermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> Cart = new Dictionary<int, int>();
            Dictionary<int, (string product, double price)> ProductsAvailable = new Dictionary<int, (string product, double price)>();
            ProductsAvailable.Add(101, ("Rice", 500.0));
            ProductsAvailable.Add(102, ("Sugar", 200.0));
            ProductsAvailable.Add(103, ("Oil", 100.0));
            ProductsAvailable.Add(104, ("Cookies", 50.50));
            ProductsAvailable.Add(105, ("Butter", 40.20));
        MarketChoiceLoop:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t--------MINI SUPERMARKET-------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t______________________________");
            Console.WriteLine("\n\tEnter '1' for Seller");
            Console.WriteLine("\n\tEnter '2' for Customer");
            Console.WriteLine("\t______________________________");
            Console.ResetColor();


            string name_seller_add;
            double seller_price_add;
            int id_seler_add;

            bool market_condition = int.TryParse(Console.ReadLine(), out int market);
            if (market_condition)
            {

                if (market == 1)
                {
                    Console.WriteLine($"\tID\tProduct\t\tPrice");
                    Console.WriteLine("\t------------------------------");
                    foreach (int id in ProductsAvailable.Keys)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n\t{id}\t{ProductsAvailable[id].product}\t\t{ProductsAvailable[id].price:F2}");
                        Console.ResetColor();
                    }
                SellerOption:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\nEnter '1' for Add Product");
                    Console.WriteLine("\nEnter '2' for remove Product");
                    Console.WriteLine("\nEnter '3' for exit");
                    Console.ResetColor();
                    bool add_con = int.TryParse(Console.ReadLine(), out int add_);
                    if (add_con)
                    {
                        if (add_ == 1)
                        {
                        ProductAddingId:



                            Console.WriteLine("\nEnter the Produuct ID");
                            Console.WriteLine();
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                if (ProductsAvailable.ContainsKey(id))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nThe Product ID is Already Exist");
                                    Console.ResetColor();
                                    goto ProductAddingId;
                                }
                                else
                                {
                                    id_seler_add = id;
                                }
                            }
                            else
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("***Invalid Input****");
                                Console.ResetColor();
                                goto ProductAddingId;
                            }
                        ProductAddingName:
                            Console.WriteLine("\nEnter the Product Name");
                            string product_name_add = Console.ReadLine();
                            if (string.IsNullOrEmpty(product_name_add))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Product Name Not be Empty");
                                Console.ResetColor();
                                goto ProductAddingName;
                            }
                            else if (ProductsAvailable.Values.Any(p => p.product == product_name_add))
                            {
                                Console.WriteLine("Product name already exists.");
                                goto ProductAddingName;
                            }
                            else
                            {
                                name_seller_add = product_name_add;

                            }
                        ProductAddingPrice:
                            Console.WriteLine("Enter the Product Price :");
                            bool price_con = double.TryParse(Console.ReadLine(), out double price_);
                            if (price_con)
                            {
                                seller_price_add = price_;
                            }
                            else
                            {
                                Console.WriteLine("****Invalid Input****");
                                goto ProductAddingPrice;
                            }

                            ProductsAvailable.Add(id_seler_add, (name_seller_add, seller_price_add));
                            Console.WriteLine("Product Added Successfully");
                            Console.WriteLine($"\tID\tProduct\t\tPrice");
                            Console.WriteLine("\t------------------------------");
                            foreach (int ids in ProductsAvailable.Keys)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\t{ids}\t{ProductsAvailable[ids].product}\t\t{ProductsAvailable[ids].price:F2}");
                                Console.ResetColor();
                            }
                            goto SellerOption;



                        }
                        else if (add_ == 2)
                        {
                        RemoveProduct:
                            Console.WriteLine("\nEnter the Product ID for remove the Product ");
                            if (int.TryParse(Console.ReadLine(), out int remove_id_table))
                            {
                                if (!ProductsAvailable.ContainsKey(remove_id_table))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nThe Product ID in Not Available");
                                    goto RemoveProduct;
                                }
                                else
                                {
                                    string product_name_removed = ProductsAvailable[remove_id_table].product;
                                    ProductsAvailable.Remove(remove_id_table);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"\n{product_name_removed} is Removed Successfully");
                                    Console.ResetColor();
                                    Console.WriteLine($"\tID\tProduct\t\tPrice");
                                    Console.WriteLine("\t------------------------------");
                                    foreach (int id in ProductsAvailable.Keys)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n\t{id}\t{ProductsAvailable[id].product}\t\t{ProductsAvailable[id].price:F2}");
                                        Console.ResetColor();
                                    }
                                    goto SellerOption;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid Input");
                                Console.ResetColor();
                                goto RemoveProduct;
                            }



                        }
                        else if (add_ == 3)
                        {
                            goto MarketChoiceLoop;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***Inavalid Input***");
                        Console.ResetColor();
                        goto SellerOption;

                    }




                }
                else if (market == 2)
                {
                }



                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n***Invalid option***");
                    Console.ResetColor();
                    goto MarketChoiceLoop;

                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***Invalid Input***");
                Console.ResetColor();
                goto MarketChoiceLoop;


            }


        AddProduct:
            double total_amount = 0;
            char loop_condition = 'n';
            while (loop_condition == 'N' || loop_condition == 'n')
            {
                Console.WriteLine();
                Console.WriteLine($"\tID\tProduct\t\tPrice");
                Console.WriteLine("\t------------------------------");
                foreach (int id in ProductsAvailable.Keys)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n\t{id}\t{ProductsAvailable[id].product}\t\t{ProductsAvailable[id].price:F2}");
                    Console.ResetColor();
                }

                Console.WriteLine("\t------------------------------");
                if (Cart.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nEnter 1 for Exit and Proceed to final Bill (or)");
                    Console.ResetColor();
                }
                Console.WriteLine("\nEnter the Product code :");
                int product_id;
                int product_quantity;
                while (true)
                {
                    bool id_cond = int.TryParse(Console.ReadLine(), out int id);
                    if (id_cond)
                    {
                        if (id == 1 && Cart.Count > 0)
                        {
                            goto Exitloop;
                        }
                        else if (ProductsAvailable.ContainsKey(id))
                        {
                            product_id = id;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nID You Enter is Not Available");
                            Console.ResetColor();
                            Console.WriteLine("\nSelect ID Number from the Table:");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nEnter the valid Number :");
                        Console.ResetColor();
                    }

                }
                Console.WriteLine("------------------------------");
                Console.WriteLine($"\nEnter the Quantity of the {ProductsAvailable[product_id].product} :");
                while (true)
                {
                    bool quantity_cond = int.TryParse(Console.ReadLine(), out int quantity);
                    if (quantity_cond)
                    {
                        if (quantity > 0)
                        {
                            product_quantity = quantity;
                            break;
                        }
                        else if (quantity == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nQuantity not to be 0");
                            Console.ResetColor();
                            Console.WriteLine("\nEnter the Quantity :");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nQuantity Must be Possitive number");
                            Console.ResetColor();
                            Console.WriteLine("Enter the Quantity :");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("****Enter the valid Number****");
                        Console.ResetColor();
                        Console.WriteLine("Enter the Quantity :");

                    }
                }
                if (!Cart.ContainsKey(product_id))
                {
                    Cart.Add(product_id, product_quantity);

                }
                else
                {
                    Cart[product_id] += product_quantity;
                }
                while (true)
                {
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nProseed to Final Bill(y/n)");
                    Console.ResetColor();
                    bool loop_con = char.TryParse(Console.ReadLine(), out char loopc);
                    if (loop_con)
                    {
                        if (loopc == 'y' || loopc == 'Y' || loopc == 'N' || loopc == 'n')
                        {
                            loop_condition = loopc;
                            break;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n*****Invalid Input****");
                            Console.ResetColor();
                            Console.WriteLine("\nEnter only (y/n):");

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("******Enter the Valid Input*****");

                        Console.ResetColor();
                    }

                }
            }
        Exitloop:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tID\tProduct\t\tPrice\tQuantity\tTotal");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t__________________________________________________________");
            foreach (int item in Cart.Keys)
            {
                total_amount += Cart[item] * ProductsAvailable[item].price;
                double product_total = Cart[item] * ProductsAvailable[item].price;

                Console.WriteLine($"\t{item}\t{ProductsAvailable[item].product}\t\t{ProductsAvailable[item].price}\t{Cart[item]}\t\t{product_total:F2}");
                Console.WriteLine();
            }

            Console.WriteLine("\t__________________________________________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tTOTAL AMOUNT\t\t\t\t\t:{total_amount:F2}");
            Console.ResetColor();
        choiceLoop:
            Console.WriteLine("\nEnter '1' to confirm ");
            Console.WriteLine("\nEnter '2' to Add Product ");
            Console.WriteLine("\nEnter '3' to Remove Product Quantity ");
            int remove_id;
            int remove_quantity_value;

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1)
                {

                }
                else if (choice == 2)
                {
                    loop_condition = 'n';
                    goto AddProduct;

                }
                else if (choice == 3)
                {
                RemoveQuantity:
                    Console.WriteLine("\nEnter the Id for remove Quantity:");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Input cannot be empty or just spaces.");
                        Console.ResetColor();
                        goto RemoveQuantity;
                    }

                    try
                    {
                        if (Cart.ContainsKey(int.Parse(input)))
                        {
                            remove_id = int.Parse(input);

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nID is not Available in your Cart");
                            Console.ResetColor();
                            goto RemoveQuantity;
                        }


                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("**Invalid Format**");
                        Console.ResetColor();
                        goto RemoveQuantity;
                    }
                QuantityRemove:
                    Console.WriteLine($"\nEnter the Quantity for remove the {ProductsAvailable[remove_id].product}");
                    bool remove_quant_con = int.TryParse(Console.ReadLine(), out int remove_quantity);
                    if (remove_quant_con)
                    {
                        if (remove_quantity <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Quantity not be Negative or '0'");
                            Console.ResetColor();
                            goto QuantityRemove;
                        }
                        else
                        {
                            remove_quantity_value = remove_quantity;

                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid format for Quantity");
                        Console.ResetColor();
                        goto QuantityRemove;
                    }

                    if (Cart[remove_id] == remove_quantity_value)
                    {
                        Cart.Remove(remove_id);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n{ProductsAvailable[remove_id].product} is Removed Successfully");
                        Console.ResetColor();
                        total_amount = 0;
                        goto Exitloop;
                    }
                    else if (Cart[remove_id] < remove_quantity_value)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nThe Quantity you Entered for remove {ProductsAvailable[remove_id].product} is more than your cart");
                        Console.ResetColor();
                        goto QuantityRemove;
                    }
                    else
                    {
                        Cart[remove_id] -= remove_quantity_value;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{remove_quantity_value} {ProductsAvailable[remove_id].product} is Removed Successfully");
                        Console.ResetColor();
                        total_amount = 0;
                        goto Exitloop;
                    }






                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***Invalid option***");
                    Console.ResetColor();
                    goto choiceLoop;

                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***Inavalid input***");
                Console.ResetColor();
                goto choiceLoop;
            }


        }
    }
}