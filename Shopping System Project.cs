using System.Net;
using System.Runtime.CompilerServices;

namespace Shopping_System_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> _products = new Dictionary<string, double>();//list of product 
            _products.Add("Milk", 20.0);
            _products.Add("cake", 51.60);
            _products.Add("Chocolate", 10.0);
            _products.Add("Sugar", 20.0);
            _products.Add("Cookie", 12.30);
            _products.Add("Chips", 5.70);
            _products.Add("ice cream", 5.0);
            _products.Add("Meat", 200.0);
            _products.Add("Rice", 30.0);
            _products.Add("Tea", 13.50);

          
           

            bool running = true;
            Stack<KeyValuePair<string, double>> d = new Stack<KeyValuePair<string, double>>();
            
                while (running)
                {

                    Console.Clear();
                    //opreationtodo.displayitems(_products);
                     Console.WriteLine("Welcome to our small store. Please choose one to start your shopping.\n");
                    Console.WriteLine("1-Add Items to Cart");
                    Console.WriteLine("2-View Cart");
                    Console.WriteLine("3-Remove Items");
                    Console.WriteLine("4-Checkout");
                    Console.WriteLine("5-Undo Last Action");
                    Console.WriteLine("6-View Total Price");
                    Console.WriteLine("7-Exit");
                    string choice = Console.ReadLine();
                    switch (Convert.ToInt32(choice))
                    {
                        case 1:
                            opreationtodo.displayitems(_products);
                            opreationtodo.add(d, _products);
                            break;
                        case 2:
                            Console.Clear();
                            opreationtodo.viewcart(d);
                            Console.WriteLine("\nPress any key to go back to the main menu...");
                            Console.ReadKey();
                            break;
                        case 3:
                            opreationtodo.remove(d);
                            break;

                        case 4:
                            opreationtodo.checkout(d);
                            Console.WriteLine("\nPress any key to go back to the main menu...");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            opreationtodo.undo(d);
                            Console.WriteLine("\nPress any key to go back to the main menu...");
                            Console.ReadKey();
                            break;
                        case 6:
                            opreationtodo.totalprice(d);
                            Console.WriteLine("\nPress any key to go back to the main menu...");
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Do you sure about Exiting the program ? y/n");
                            string a=Console.ReadLine();
                            if(a=="y")
                            {
                                running=false;
                            }
                            else
                            {
                                running = true;
                            }
                            break;

                    }
                }

            }
        }
    
   
    public static class opreationtodo
    {
        private static KeyValuePair<string, double> Lastremoved;
        private static int Countbefore=-1;
        private static int Countafter = 0;
       public static void displayitems(Dictionary<string, double> d1)
        {
            Console.Clear();
            int count = 0;
            Console.WriteLine("Here are our products:");
            foreach (var item in d1)
            {
                count++;
                Console.WriteLine($"{count}- {item.Key,-12} {item.Value}LE");

            }
        }
        public static void add(Stack<KeyValuePair<string, double>> d, Dictionary<string, double> d1)
        {
           
            bool running = true;
            while (running)
            {
                Countbefore++;
               
                Console.WriteLine("Please choose one product to add");
                string chooise = Console.ReadLine();


                switch (Convert.ToInt32(chooise))
                {
                    case 1:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Milk")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 2:
                        foreach (var item in d1)
                        {
                            if (item.Key == "cake")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 3:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Chocolate")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 4:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Sugar")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 5:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Cookie")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 6:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Chips")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 7:
                        foreach (var item in d1)
                        {
                            if (item.Key == "ice cream")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 8:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Meat")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 9:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Rice")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;

                    case 10:
                        foreach (var item in d1)
                        {
                            if (item.Key == "Tea")
                            {
                                d.Push(item);
                                break;
                            }
                        }
                        break;


                }
                Countafter=d.Count;
                Console.WriteLine("product added successfully,Do you want to add any thing additional ? y/n");
                string ans = Console.ReadLine();
                if (ans == "n")
                {
                    running = false;
                }
                else { running = true; }
            }
        }

        public static void viewcart(Stack<KeyValuePair<string, double>> d)
        {
            Console.Clear();
            if (d.Count == 0)
            {
                Console.WriteLine("Cart is empty,please go to shopping first ");
                return;
            }
            List<KeyValuePair<string, double>> g = new List<KeyValuePair<string, double>>();
            foreach (var item in d)
            {
                g.Add(item);
            }
            Console.WriteLine("Here are the product you added to your cart:\n");
            int count = 0;
            for (int i = g.Count - 1; i >= 0; i--)
            {
                count++;
                Console.WriteLine($"{count}-{g[i].Key,-12}{g[i].Value}LE");
            }

        }

        public static void remove(Stack<KeyValuePair<string, double>> d)
        {
            if (d.Count == 0)
            {
                Console.WriteLine("Cart is empty,please go to shopping first ");
                return;
            }
            viewcart(d);
            while (true)
            {
                Countbefore = d.Count;
                Console.WriteLine("Choose one to remove **Enter it's Name**");
                string ans = Console.ReadLine();
                List<KeyValuePair<string, double>> l = new List<KeyValuePair<string, double>>();

                foreach (var item in d)
                {
                    if (item.Key != ans)
                    {
                        l.Add(item);
                    }
                    else
                    {
                        Lastremoved = item;
                    }

                }

                d.Clear();
                Countafter=l.Count;
                foreach (var item in l)
                {
                    d.Push(item);
                }

                Console.WriteLine("the opreation done successfully , your cart after removing : ");
                viewcart(d);
                Console.WriteLine("Do you want to remove another product ? y/n");
                string h = Console.ReadLine();
                if (h == "n")
                {
                    break;
                }

            }
        }

        public static void totalprice(Stack<KeyValuePair<string, double>> d)
        {
            viewcart(d);
            double sum = 0;
            foreach (var item in d)
            {
                sum+= item.Value;   
            }
            Console.WriteLine($"\nTotal price:{sum}");
        }
        public static void checkout(Stack<KeyValuePair<string, double>> d)
        {
            if(d.Count == 0)
            {
                Console.WriteLine("Cart is empty,please go to shopping first ");
                return;
            }
           totalprice(d);
            Console.WriteLine("\nDo you want to proceed with the checkout? (y/n)");
            string confirm = Console.ReadLine();
            if(confirm == "y")
            {
                Console.WriteLine("\nThank you for your purchase! Your order has been placed.");
                d.Clear ();
            }
            else if(confirm == "n")
            {
                Console.WriteLine("\nCheckout cancelled. You can continue shopping");


            }

        }
        public static void undo(Stack<KeyValuePair<string, double>> d)
        {
            if(Countbefore<Countafter)
            {
                Console.WriteLine($"the last opreation is adding {d.Peek().Key},do you sure about undo ? y/n");
                string j=Console.ReadLine();
                if(j == "y")
                {
                    d.Pop();
                    Console.WriteLine("The undo done successfully :)");
                }
            }
            else if(Countbefore>Countafter)
            {
                Console.WriteLine($"the last opreation is removing {Lastremoved.Key},do you sure about undo ? y/n");
                string j = Console.ReadLine();
                if (j == "y")
                {
                 
                    d.Push(Lastremoved);
                    Console.WriteLine("The undo done successfully :)");
                }
            }
        }

    }
}


